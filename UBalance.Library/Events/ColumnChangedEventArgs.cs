using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Events
{
    public class ValueChangedEventArgs
    {
        private int _Column;

        public ValueChangedEventArgs(int column)
        {
            _Column = column;
        }

        public int Column
        {
            get { return _Column; }
        }
    }
}
