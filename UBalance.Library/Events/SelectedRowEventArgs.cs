using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBalance.Library.Events
{
    public class SelectedRowEventArgs : EventArgs
    {
        private readonly int _rowNumber;

        public SelectedRowEventArgs(int rowNumber)
        {
            _rowNumber = rowNumber;
        }

        public int RowNumber
        {
            get { return _rowNumber; }
        }

    }
}
