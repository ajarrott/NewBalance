using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Events
{
    public class PreferenceCloseEventArgs : EventArgs
    {
        private readonly string _path;

        public PreferenceCloseEventArgs(string text)
        {
            _path = text;
        }

        public string Text
        {
            get { return _path; }
        }
    }
}
