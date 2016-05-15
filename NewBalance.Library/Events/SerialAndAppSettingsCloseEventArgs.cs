using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBalance.Library.Events
{
    public class SerialAndAppSettingsCloseEventArgs : EventArgs
    {
        private readonly string _path;

        public SerialAndAppSettingsCloseEventArgs(string text)
        {
            _path = text;
        }

        public string Text
        {
            get { return _path; }
        }
    }
}
