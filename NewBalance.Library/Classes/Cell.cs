using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace NewBalance.Library.Classes
{
    // Cell for when one is defined as name[optionValue]
    // All of these cells will have the same row/column value, but not the same internal value
    public class MultipleCell : Cell
    {
        private List<Cell> _CellOptions;
        private List<string> _OptionNames;
        private Cell _SelectedCell;
        private string _baseName;
        public event EventHandler NotifyHeaderNameChange = delegate { };

        public MultipleCell(Cell c, List<Cell> cells ) : base(c, true)
        {
            _CellOptions = new List<Cell>();
            _OptionNames = new List<string>();
            AddCellToOptions(c, cells, true);
            _baseName = c.Label.Substring(0, c.Label.IndexOf('['));
            _CellType = CellType.Multiple;

            // set selected cell to first option in list of cells
            _SelectedCell = _CellOptions[0];
        }

        public MultipleCell(MultipleCell multiple, List<Cell> cells) : base(multiple, false)
        {
            _CellOptions = new List<Cell>();
            _OptionNames = new List<string>();
            _baseName = multiple.BaseName;
            _CellType = CellType.Multiple;

            foreach (Cell c in multiple.CellOptions)
            {
                AddCellToOptions(c, cells, false);
            }

            // set selected cell to the first item in the list of cells
            _SelectedCell = _CellOptions[0];
        }

        public void AddCellToOptions(Cell c, List<Cell> cells, bool newMultiCellRow)
        {
            var kCell = c as KCell;
            var cCell = c as CCell;
            var mCell = c as MCell;
            var wCell = c as WCell;
            if (kCell != null)
            {
                KCell kc = new KCell(kCell, newMultiCellRow);
                AddOptionCell(kc);
            }
            else if (cCell != null)
            {
                List<string> names = cCell.ConnectionInfo.Split(new char[] { '(', ')', '+', '-', '*', '/', '^' }).ToList();

                // need for TryParse
                double n;

                List<string> dependencyNamesPossibleDupes = (from name in names
                                                                where name.Length > 0 &&
                                                                !double.TryParse(name, out n)     // make sure the value isn't a direct value
                                                                select name).ToList();

                List<string> dependencyNames = dependencyNamesPossibleDupes.Distinct().ToList();


                List<Cell> dependencies = new List<Cell>();

                foreach (string name in dependencyNames)
                {
                    Cell dependency = cells.First(x => x.Label == name);

                    if (dependency != null)
                        dependencies.Add(dependency);
                }

                CCell cc = new CCell(cCell, dependencies, newMultiCellRow);
                    
                AddOptionCell(cc);
            }
            else if (mCell != null)
            {
                MCell mc = new MCell(mCell, newMultiCellRow);

                AddOptionCell(mc);
            }
            else if (wCell != null)
            {
                WCell wc = new WCell(wCell, newMultiCellRow);

                AddOptionCell(wc);
            }
        }

        public double? SelectedValue
        {
            get
            {
                if (_SelectedCell.Value == null) return null;
                return Math.Round((double)_SelectedCell.Value, _SelectedCell.Precision);
            }
        }

        public List<Cell> CellOptions
        {
            get { return _CellOptions; }
        }

        public string BaseName
        {
            get { return _baseName; }
        }

        public List<string> OptionStrings
        {
            get{ return _OptionNames; }
        } 

        private void AddOptionCell(Cell c)
        {
            var kCell = c as KCell;
            var mCell = c as MCell;
            var wCell = c as WCell;
            var cCell = c as CCell;
            if (kCell != null)
                _CellOptions.Add(kCell);
            else if (mCell != null)
                _CellOptions.Add(mCell);
            else if (wCell != null)
                _CellOptions.Add(wCell);
            else if (cCell != null)
                _CellOptions.Add(cCell);

            OptionStrings.Add(c.Label.Substring(c.Label.IndexOf('[') + 1, c.Label.IndexOf(']') - c.Label.IndexOf('[') - 1));
        }

        public static bool IsMultiCell(string s)
        {
            return s.Contains('[') && s.Contains(']');
        }

        public Cell SelectedCell
        {
            get { return _SelectedCell; }
        }

        public void UpdateSelectedCell(int index)
        {
            try
            {
                _SelectedCell = _CellOptions[index];
            }
            catch (Exception)
            {
                // ignored
            }
        }

        /// <summary>
        /// Check if you can this the current multiple cell
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public bool CanAddToOption(string label)
        {
            return label.Substring(0, label.IndexOf('[')) == _baseName;
        }

        public void ChangeOption(string optName)
        {
            int indexOf = OptionStrings.IndexOf(optName);

            try
            {
                _SelectedCell = _CellOptions[indexOf];
                NotifyHeaderNameChange(this, new EventArgs());
                OnValueChanged(new PropertyChangedEventArgs("Value"));
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    // Calculation Column
    public class CCell : Cell
    {
        private Calculation _Calculation;
        private Dictionary<Cell, bool> _Dependencies; 

        public CCell(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex, List<Cell> dependencies ) : 
        base(label, digits, precision, connectionInfo, rowIndex, columnIndex)
        {
            _Calculation = new Calculation(ConnectionInfo);
            _Dependencies = new Dictionary<Cell, bool>();
            _CellType = CellType.C;

            foreach (Cell dependency in dependencies)
            {
                //Tuple<Cell, bool> t = new Tuple<Cell, bool>(dependency, false);
                _Dependencies.Add(dependency, false);
            }
        }

        public CCell(CCell c, List<Cell> dependencies, bool multiCell = false ) : base(c, multiCell)
        {
            _Calculation = new Calculation(ConnectionInfo);
            _Dependencies = new Dictionary<Cell, bool>();
            _CellType = CellType.C;

            // need to call copy contructors for dependencies passed from old cells


            foreach (Cell dependency in dependencies )
            {
                _Dependencies.Add(dependency, false);
            }
        }

        /// <summary>
        /// Returns the calculation in double format
        /// </summary>
        /// <returns></returns>
        public void RunCalculation()
        {
            Value = _Calculation.ReEval();
        }

        /// <summary>
        /// figure out if cell is a dependency
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsDependency(Cell c)
        {
            return _Dependencies.ContainsKey(c);
        }

        /// <summary>
        /// Pass tuple of strings to this function to set varaibles in the equation
        /// </summary>
        /// <param name="variables">Item1 is the variable name, Item2 is the value in string format</param>
        public void SetVariables(List<Tuple<string, string>> variables)
        {
            foreach (Tuple<string, string> variable in variables)
            {
                _Calculation.SetVar(variable.Item1, variable.Item2);    
            }   
        }

        public string DisplayValue
        {
            get
            {
                return String.Format("{0:F" + Precision + "}", Value);
            } 
        }

        public void OverrideValue(double newValue)
        {
            Value = newValue;
            OnValueChanged(new PropertyChangedEventArgs("Value"));
        }

        public Dictionary<Cell, bool> Dependencies
        {
            get { return _Dependencies;}
        }

        public void CheckDependencies()
        {
            if (!_Dependencies.ContainsValue(false))
            {
                List <Tuple<string, string>> variableValues = new List<Tuple<string, string>>();
                foreach (Cell c in _Dependencies.Keys)
                {
                    variableValues.Add(new Tuple<string, string>(c.Label, c.Value.ToString()));
                }
                SetVariables(variableValues);

                RunCalculation();
            }
        }
    }

    // Keyboard Column
    public class KCell : Cell
    {
        private KConnection _KConnection;
        private string _KValue = String.Empty;

        public KCell(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex) : 
        base(label, digits, precision, connectionInfo, rowIndex, columnIndex)
        {
            KConnection tempConnection;
            Enum.TryParse(ConnectionInfo, out tempConnection);
            KConnectionType = tempConnection;

            _CellType = CellType.K;
        }

        public KCell(KCell c, bool MultipleCell = false) : base(c, MultipleCell)
        {
            KConnection tempConnection;
            Enum.TryParse(ConnectionInfo, out tempConnection);
            KConnectionType = tempConnection;

            _CellType = CellType.K;
        }

        public string KValue
        {
            get
            {
                if(_KValue != String.Empty) return _KValue;
                if (Value != null)
                {
                    return Math.Round((double)Value, Precision).ToString();
                }
                return null;
            }
            set
            {
                double d;

                if (double.TryParse(value, out d))
                {
                    _KValue = String.Empty;
                    Value = d;
                }
                else
                {
                    _KValue = value;
                    Value = null;
                    OnValueChanged(new PropertyChangedEventArgs("String"));
                }

                if (value == null) ValueChanged = false;
                else ValueChanged = true;
            }
        }

        public KConnection KConnectionType
        {
            get { return _KConnection; }
            set
            {
                _KConnection = value;
            }
        }
    }

    // Mirror Column
    // will automatically mirror column, needs name of associated column
    public class MCell : Cell
    {
        private Cell _MirroredCell;
        private string _MValue;

        public MCell(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex, Cell columnToMirror) : 
        base(label, digits, precision, connectionInfo, rowIndex, columnIndex)
        {
            MirroredCell = columnToMirror;
            _CellType = CellType.M;
        }

        public MCell(MCell c, bool multiCell = false) : base(c, false)
        {
            MirroredCell = c.MirroredCell;

            MirroredCell.RowIndex = RowIndex + 1;
            _CellType = CellType.M;
        }

        public Cell MirroredCell 
        { 
            get { return _MirroredCell; }
            private set
            {
                _MirroredCell = value;
                ValueChanged = true;
            } 
        }

        public void OverrideValue(double newValue)
        {
            Value = newValue;
            OnValueChanged(new PropertyChangedEventArgs("Value"));
        }

        public string MValue
        {
            get { return _MValue; }
            set
            {
                _MValue = value;
                OnValueChanged(new PropertyChangedEventArgs("String"));
            }
        }

        public bool IsDependent(Cell c)
        {
            return c == _MirroredCell;
        }
    }

    public class WCell : Cell
    {
        private string _AdvanceToCell = String.Empty;

        public WCell(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex) :
            base(label, digits, precision, connectionInfo, rowIndex, columnIndex)
        {
            _CellType = CellType.W;
            if (ConnectionInfo == "NULL") return;
            
            _AdvanceToCell = connectionInfo;
        }

        public WCell(WCell c, bool multiCell = false) : base(c, multiCell)
        {
            _CellType = CellType.W;
            if (ConnectionInfo == "NULL") return;

            _AdvanceToCell = ConnectionInfo;
        }
    }

    public class NewScreen : Cell
    {
        public NewScreen(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex) :
            base(label, digits, precision, connectionInfo, rowIndex, columnIndex)
        {
            _CellType = CellType.NewScreen;
        }

        public NewScreen(NewScreen ns, bool multiCell = false) : base(ns, multiCell)
        {
            _CellType = CellType.NewScreen;
        }
    }

    public class Cell : ICloneable
    {
        private string _Label;
        private int _Digits;
        private int _Precision;
        private string _ConnectionInfo;
        private int _ColumnIndex;
        private int _RowIndex;
        private double? _Value;
        private bool _ValueChanged;
        protected CellType _CellType;
        public event EventHandler NotifyDependents = delegate { };

        public event PropertyChangedEventHandler CellValueChanged = delegate { };

        public Cell(string label, int digits, int precision, string connectionInfo, int rowIndex, int columnIndex)
        {
            Label = label;
            Digits = digits;
            Precision = precision;
            ConnectionInfo = connectionInfo;
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            ValueChanged = false;
        }

        // copy constructor for next row
        public Cell(Cell c, bool multiCell = false)
        {
            Label = c.Label;
            Digits = c.Digits;
            Precision = c.Precision;
            ConnectionInfo = c.ConnectionInfo;
            if (multiCell)
            {
                RowIndex = c.RowIndex;
            }
            else
            {
                RowIndex = c.RowIndex + 1;
            }
            ColumnIndex = c.ColumnIndex;
            ValueChanged = false;
        }

        // getters
        public int Digits
        {
            get { return _Digits; }
            private set { _Digits = value; }
        }

        public int Precision
        {
            get { return _Precision; }
            private set { _Precision = value; }
        }

        public string Label
        {
            get { return _Label; }
            private set { _Label = value; }
        }

        public string ConnectionInfo
        {
            get { return _ConnectionInfo; }
            private set { _ConnectionInfo = value; }
        }

        public virtual double? Value
        {
            get
            {
                if (_Value == null) return null;
                return Math.Round((double) _Value, Precision);
            }
            set
            {
                _Value = value;

                if (_Value == null)
                {
                    ValueChanged = false;
                }
                else
                {
                    ValueChanged = true;
                    CellValueChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
 
        }

        public int ColumnIndex
        {
            get { return _ColumnIndex; }
            private set { _ColumnIndex = value; }
        }

        public int RowIndex
        {
            get { return _RowIndex; }
            set { _RowIndex = value; }
        }

        public bool ValueChanged
        {
            get { return _ValueChanged; }
            protected set
            {
                // only notify on change for valuechanged
                if(value == !_ValueChanged) OnMirrorValueChanged(EventArgs.Empty);
                _ValueChanged = value;
            }
        }

        protected virtual void OnValueChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = CellValueChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnMirrorValueChanged(EventArgs e)
        {
            EventHandler handler = NotifyDependents;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public CellType CellType
        {
            get { return _CellType; }
        }

        // 'K' type elements can have 'AUTO', 'DITTO', or 'NULL'.  'AUTO' will automatically generate numbers                     
        // 'W' type element may have an 'Advance-to-Element' option or 'NULL'.
            // An 'Advance-to-Element' is an element name in the application file that becomes the next data entry cell
            // after weight data has been entered for the current cell. 
        // 'C' type element requires a calculation to be defined for this component.
        // 'M' type element requires the mirrored element name.                                                                       

        public object Clone()
        {
            return new Cell(this);
        }

        public void RemoveSubscriptions()
        {
            NotifyDependents = null;
            CellValueChanged = null;
        }
    }

    public enum KConnection
    {
        AUTO, // row num = n+1 where n is the row number above
        DITTO,  // copy the value from this column to the new ones
        NULL    // no specification, enterned manually
    }

    public enum WConnection
    {
        AdvanceToElement, // just to element name after weight was entered, any name other than NULL is valid
        NULL
    }

    public enum CellType
    {
        K,
        W,
        C,
        M,
        Multiple,
        NewScreen
    }
}
