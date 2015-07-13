using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class GridData
    {
        private Row _DefaultRow;
        private List<Row> _DataLayerRows; 

        public GridData(Row r)
        {
            _DefaultRow = r;
            _DataLayerRows = new List<Row>();
        }

        public void AddRow()
        {
            _DataLayerRows.Add(_DefaultRow);
        }

        public bool UpdateValue(int rowNumber, int column, double value)
        {
            _DataLayerRows[rowNumber].UpdateValue(column, value);

            return true;
        }

        public List<string> ColumnHeaders()
        {
            return _DefaultRow.RowHeaders();
        }


        
    }
}
