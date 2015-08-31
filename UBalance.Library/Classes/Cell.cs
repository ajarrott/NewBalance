using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
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

        public CCell(CCell c) : base(c)
        {
            _Calculation = new Calculation(ConnectionInfo);
            _Dependencies = new Dictionary<Cell, bool>();
            _CellType = CellType.C;

            foreach (Cell dependency in c.Dependencies.Keys)
            {
                _Dependencies.Add(new Cell(dependency), false);
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
            bool returnValue;

            _Dependencies.TryGetValue(c, out returnValue);

            return returnValue;
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

        public KCell(KCell c) : base(c)
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
            private set
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

        public MCell(MCell c) : base(c)
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

        public WCell(WCell c) : base(c)
        {
            _CellType = CellType.W;
            if (ConnectionInfo == "NULL") return;

            _AdvanceToCell = ConnectionInfo;
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
        public Cell(Cell c)
        {
            Label = c.Label;
            Digits = c.Digits;
            Precision = c.Precision;
            ConnectionInfo = c.ConnectionInfo;
            RowIndex = c.RowIndex + 1;
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

        public double? Value
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
                    CellValueChanged(this, new PropertyChangedEventArgs("Value"));
                    ValueChanged = true;
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
        M
    }
}
