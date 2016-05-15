using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NewBalance.Library.Events;

namespace NewBalance.Library.Classes
{
    public class GridData
    {
        private List<List<Cell>> _Cells = new List<List<Cell>>();
        private List<CCell> _CalculationCells = new List<CCell>(); 
        private string _AppName;

        public GridData(List<Cell> defaultRow, string nameOfApp)
        {
            foreach (Cell c in defaultRow)
            {
                if (c.CellType == CellType.K)
                {
                    KCell kc = c as KCell;
                    if (kc.KConnectionType != KConnection.AUTO) continue;

                    // initialize auto value to 1, user can respecify at a later time
                    kc.Value = 1;
                }
                else if (c.CellType == CellType.C)
                {
                    CCell cc = c as CCell;

                    if (cc != null)
                    {
                        _CalculationCells.Add(cc);
                    }
                }
            }
            _Cells.Add(defaultRow);
            _AppName = nameOfApp;
        }

        public void AddRow()
        {
            int nextRow = _Cells.Count;

            // check each cell

            List <Cell> cells = new List<Cell>();

            foreach (Cell c in _Cells[nextRow - 1])
            {
                if (c.CellType == CellType.C)
                {
                    CCell cc = c as CCell;

                    List<string> names = cc.ConnectionInfo.Split(new char[] { '(', ')', '+', '-', '*', '/', '^' }).ToList();

                    // need for TryParse
                    double n;

                    List<string> dependencyNamesPossibleDupes = new List<string>(); /* = (from name in names
                                                                 where name.Length > 0 &&
                                                                 !double.TryParse(name, out n)     // make sure the value isn't an integer
                                                                 select name).ToList(); */
                

                    foreach (string name in names)
                    {
                        if (name.Length > 0 && !double.TryParse(name, out n))
                        {
                            dependencyNamesPossibleDupes.Add(name);
                        }
                    }

                    // quicker way to get distinct values
                    HashSet<string> dependencyNames = new HashSet<string>(dependencyNamesPossibleDupes);

                    //List<string> dependencyNames = dependencyNamesPossibleDupes.Distinct().ToList();


                    List<Cell> dependencies = new List<Cell>();

                    foreach (string name in dependencyNames)
                    {
                        Cell dependency = cells.First(x => x.Label == name);

                        if (dependency != null)
                            dependencies.Add(dependency);
                    }

                    CCell copyWithCorrectRow = new CCell(cc, dependencies);
                    _CalculationCells.Add(copyWithCorrectRow);
                    cells.Add(copyWithCorrectRow);
                }
                else if (c.CellType == CellType.W)
                {
                    WCell wc = c as WCell;
                    cells.Add(new WCell(wc));
                }
                else if (c.CellType == CellType.K)
                {
                    KCell kc = c as KCell;

                    KCell kcToAdd = new KCell(kc);

                    if (kcToAdd.KConnectionType == KConnection.AUTO)
                        kcToAdd.Value = kc.Value + 1;
                    if (kcToAdd.KConnectionType == KConnection.DITTO)
                        kcToAdd.KValue = kc.KValue;
                    cells.Add(kcToAdd);
                }
                else if(c.CellType == CellType.M)
                {
                    MCell mc = c as MCell;
                    cells.Add(new MCell(mc));
                }
                else if (c.CellType == CellType.Multiple)
                {
                    MultipleCell multiple = c as MultipleCell;
                    cells.Add(new MultipleCell(multiple, cells));
                }
                else if (c.CellType == CellType.NewScreen)
                {
                    NewScreen ns = c as NewScreen;
                    cells.Add(new NewScreen(ns));
                }
                
            }
            _Cells.Add(cells);
        }

        public bool UpdateValue(int rowNumber, int columnNumber, double value)
        {
            //_DataLayerRows[rowNumber].UpdateValue(columnNumber, value);
            _Cells[rowNumber][columnNumber].Value = value;

            return true;
        }

        public CellType? GetCellType(int rowNumber, int columnNumber)
        {
            Cell c = _Cells[rowNumber][columnNumber];

            if (c is KCell) return CellType.K;
            if (c is CCell) return CellType.C;
            if (c is MCell) return CellType.M;
            if (c is WCell) return CellType.W;
            if (c is MultipleCell) return CellType.Multiple;
            return null;
        }

        public Cell GetCell(int rowNumber, int columnNumber)
        {
            if (rowNumber >= _Cells.Count) return null;
            if (columnNumber >= _Cells[0].Count) return null;
            return _Cells[rowNumber][columnNumber];
        }

        public List<string> ColumnHeaders()
        {
            return _Cells[0].Select(x => x.Label).ToList();
        }

        //public void DatFileAppendLoop(StringBuilder sb, string str, int length)
        //{
        //    // don't go beyond the amount of digits allowed in the cell
        //    for (int i = 0; i < length; i++)
        //    {
        //        // need to get all characters from the string
        //        if (i < str.Length)
        //        {
        //            sb.Append(str[i]);
        //        }
        //        // then start adding spaces
        //        else
        //        {
        //            sb.Append(' ');
        //        }
        //    }
        //}

        //public string SaveDatFile()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    // header is the name of the app file
        //    sb.AppendLine(_AppName);

        //    // get the row
        //    foreach (List<Cell> listOFCells in _Cells)
        //    {
        //        string str = "";
        //        // get the cell
        //        foreach (Cell c in listOFCells)
        //        {
        //            if (c is KCell)
        //            {
        //                str = (c as KCell).KValue;

        //                DatFileAppendLoop(sb, str, c.Digits);
        //            }
        //            else
        //            {
        //                str = c.Value.ToString();
        //                DatFileAppendLoop(sb, str, c.Digits);
        //            }
                    
        //            sb.Append(',');
        //        }

        //        sb.Append("\r\n");
        //    }

        //    return sb.ToString();
        //}

        public string Save()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(_AppName);

            foreach (List<Cell> listOfCells in _Cells)
            {
                foreach (Cell c in listOfCells)
                {
                    if (c.ValueChanged)
                    {
                        if (c is KCell)
                        {
                            //sb.Append((c as KCell).KValue + ",");
                            KCell kc = c as KCell;
                            for(int i = 0; i < kc.Digits; i++)
                            {
                                // add characters for the full length of the string, do not add
                                sb.Append(i < kc.KValue.Length ? kc.KValue[i] : ' ');
                            }
                        }
                        else
                        {
                            //sb.Append(c.Value + ",");
                            for (int i = 0; i < c.Digits; i++)
                            {
                                // add characters for the full length of the string, do not add
                                sb.Append(i < c.Value.ToString().Length ? c.Value.ToString()[i] : ' ');
                            }
                        }    
                    }
                    else
                    {
                        // no value entered or changed, do not change.
                        for (int i = 0; i < c.Digits; i++)
                        {
                            sb.Append(' ');
                        }
                        
                    }
                    sb.Append(",");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void CheckAndUpdateDependency(Cell cell)
        {
            int row = cell.RowIndex;

            List<Cell> rowValues = _Cells[row];

            List<CCell> calcCells = (from calculation in rowValues
                where calculation is CCell
                select calculation as CCell).ToList();

            foreach (CCell cc in calcCells)
            {
                // update dependency to make sure if value is changed
                // and has an actual value
                if (cc.IsDependency(cell))
                {
                    cc.Dependencies[cell] = cell.ValueChanged;
                    cc.CheckDependencies();
                }
            }

            // need to check multiple cells for dependencies as well
            List<MultipleCell> multiCells = (from multi in rowValues
                where multi is MultipleCell
                select multi as MultipleCell).ToList();

            foreach (MultipleCell mc in multiCells)
            {
                foreach (Cell c in mc.CellOptions)
                {
                    CCell calc = c as CCell;
                    if (calc == null) continue;

                    if (calc.IsDependency(cell))
                    {
                        calc.Dependencies[cell] = cell.ValueChanged;
                        calc.CheckDependencies();
                    }
                }
            }
        }

        public void CheckAndUpdateMultipleDependency(Cell cell, MultipleCell mc)
        {
            int row = mc.RowIndex;

            List<CCell> calcCells = mc.CellOptions.OfType<CCell>().Select(c => c).ToList();

            foreach (CCell cc in calcCells)
            {
                if (cc.IsDependency(cell))
                {
                    cc.Dependencies[cell] = cell.ValueChanged;
                    cc.CheckDependencies();
                }
            }
        }

        private void BasicNextCell(Cell c, out int row, out int column)
        {
            int columnCount = _Cells[0].Count;

            // left to right advance
            int nextCol = c.ColumnIndex + 1;

            if (nextCol < columnCount)
            {
                row = c.RowIndex;
                column = nextCol;
            }
            else
            {
                row = c.RowIndex + 1;
                column = 0;
            }
        }

        private void WeightFindNextCell(Cell c, out int row, out int column)
        {
            // if there is no advance-to-element type go to next cell in line
            if (c.ConnectionInfo.ToLower() == "null")
            {
                BasicNextCell(c, out row, out column);
                return;
            }

            // otherwise find the cell to advance to
            // current row we're on
            List<Cell> cells = _Cells[c.RowIndex];

            Cell nextCell = cells.First(x => String.Equals(x.Label, c.ConnectionInfo, StringComparison.CurrentCultureIgnoreCase));

            // if nextCell isn't a weight cell, find the next weight cell on that line
            if (!(nextCell is WCell))
            {
                // check if they keyboard cell is auto or ditto
                int index = cells.IndexOf(nextCell);

                while (index < cells.Count)
                {
                    if (cells[index] is WCell)
                    {
                        nextCell = cells[index];
                        break;
                    }

                    // only go to KCell if the type is "null", meaning a comment
                    if (cells[index] is KCell)
                    {
                        if (cells[index].ConnectionInfo.ToLower() == "null")
                        {
                            nextCell = cells[index];
                            break;
                        }
                    }
                    index++;
                }
            }

            // go to next line if it is behind the current cell
            if (nextCell.ColumnIndex <= c.ColumnIndex)
            {
                row = c.RowIndex + 1;
                column = nextCell.ColumnIndex;
            }
            // otherwise move to the next cell accordingly
            else
            {
                row = nextCell.RowIndex;
                column = nextCell.ColumnIndex;
            }
        }

        public void NextCell(Cell c, out int row, out int column)
        {
            // get cell type
            int rowValue = -1, colValue = -1;

            switch (c.CellType)
            {
                // Calculation, Mirror Type, and Keyboard Cells will just progress to the next cell as normal 
                case CellType.C:
                    BasicNextCell(c, out rowValue, out colValue);
                    break;
                case CellType.M:
                    BasicNextCell(c, out rowValue, out colValue);
                    break;
                case CellType.K:
                    BasicNextCell(c, out rowValue, out colValue);
                    break;
                case CellType.W:
                    WeightFindNextCell(c, out rowValue, out colValue);
                    break;
                case CellType.Multiple:
                    BasicNextCell(c, out rowValue, out colValue);
                    break;
            }

            row = rowValue;
            column = colValue;
        }

        public void RemoveSubscriptions()
        {
            foreach (List<Cell> lc in _Cells)
            {
                foreach (Cell c in lc)
                {
                    c.RemoveSubscriptions();
                }
            }
        }

        public bool HasMultipleCells()
        {
            foreach (Cell c in _Cells[0])
            {
                if (c is MultipleCell)
                    return true;
            }
            return false;
        }
    }
}
