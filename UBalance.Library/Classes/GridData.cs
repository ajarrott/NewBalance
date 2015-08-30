using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class GridData
    {
        //private List<Cell> _DefaultRow;
        //private List<Row> _DataLayerRows; 

        // get rid or rows
        private List<List<Cell>> _Cells = new List<List<Cell>>(); 

        public GridData(List<Cell> defaultRow)
        {
            //_DefaultRow = defaultRow;
            //_DataLayerRows = new List<Row>();
            _Cells.Add(defaultRow);
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
                    cells.Add(new CCell(cc));
                }
                else if (c.CellType == CellType.W)
                {
                    WCell wc = c as WCell;
                    cells.Add(new WCell(wc));
                }
                else if (c.CellType == CellType.K)
                {
                    KCell kc = c as KCell;
                    cells.Add(new KCell(kc));
                }
                else
                {
                    MCell mc = c as MCell;
                    cells.Add(new MCell(mc));
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
    }
}
