using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UBalance.Library.Events;

namespace UBalance.Library.Classes
{
    public class Row
    {
        private List<double> _Values; 
        private List<Column> _Columns;
        private int _RowNumber;

        // event handlers
        public delegate void AllColumnsPopulatedEventHandler(object sender, AllColumnsPopulatedEventArgs e);
        public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

        // events
        public event AllColumnsPopulatedEventHandler ColumnsPopulated = delegate { };
        public event ValueChangedEventHandler ValueChanged = delegate { };

        public Row(List<Column> columns, int rowNumber)
        {
            _Values = new List<double>();
            _Columns = new List<Column>();
            _RowNumber = rowNumber;

            foreach (Column c in columns)
            {
                _Values.Add(0.0);
                _Columns.Add(c);
            }
        }

        public void UpdateValue(int column, double value)
        {
            _Values[column] = value;
            // fire value changed event, need to check if value is a calcuation or not
            ValueChanged(this, new ValueChangedEventArgs(column));

            if (CheckIfColumnsPopulated())
            {
                // fire all columns populated event to update calculation
                ColumnsPopulated(this, new AllColumnsPopulatedEventArgs(_RowNumber));
            }
        }

        private bool CheckIfColumnsPopulated()
        {
            if (_Values.Any(v => !v.Equals(0.0)))
            {
                return false;
            }
            return true;
        }
    }
}
