using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    class AppItem
    {
        private readonly string _name;
        private readonly string _directory;

        /// <summary>
        /// Create Items using the full path to directory, the name of the .APP file will be set automatically
        /// </summary>
        /// <param name="path">Full path to filename, including the filename</param>
        public AppItem(string path)
        {
            _name = Path.GetFileNameWithoutExtension(path);
            _directory = path;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDirectory()
        {
            return _directory;
        }
    }
}
