using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Events
{
    public class AllColumnsPopulatedEventArgs : EventArgs
    {
        private readonly int _RowNumber;

        public AllColumnsPopulatedEventArgs(int rowNumber)
        {
            _RowNumber = rowNumber;
        }

        public int RowNumber
        {
            get { return _RowNumber; }
        }
    }
}
