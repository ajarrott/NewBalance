using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    class MultiCellPrototype
    {
        private string _Header;
        private List<string> _Options;
 
        public MultiCellPrototype(string header, List<string> options)
        {
            _Header = header;
            _Options = options;
        }

        public void AddToList(string s)
        {
            _Options.Add(s);
        }

        public string Header
        {
            get { return _Header; }
        }

        public List<string> Options
        {
            get { return _Options; }
        }


    }
}
