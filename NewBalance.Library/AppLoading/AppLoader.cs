using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBalance.Library.Classes;

namespace NewBalance.Library.AppLoading
{
    public class AppLoader
    {
        private List<AppItem> _appFiles;
        private string _defaultDirectory;
        public AppLoader(string directoryName)
        {
            _defaultDirectory = directoryName;
            GetAppFiles();
        }

        private void GetAppFiles()
        {
            _appFiles = new List<AppItem>();
            List<string> fileNames = new List<string>();

            try
            {
                fileNames = Directory.GetFiles(_defaultDirectory, "*.APP").ToList();
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch(Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                fileNames = null;
            }

            foreach (string filename in fileNames)
            {
                AppItem a = new AppItem(filename);
                _appFiles.Add(a);
            }
        }

        /// <summary>
        /// Get the file names associated in the directory chosen
        /// </summary>
        /// <returns>A list of all lowercase values in the filename</returns>
        public List<string> GetFileNames()
        {
            return _appFiles.Select(a => a.GetName().ToLower()).ToList();
        }

        public List<string> GetDirectoryNames()
        {
            return _appFiles.Select(a => a.GetDirectory()).ToList();
        }

        public void UpdatePath(string s)
        {
            _defaultDirectory = s;

            GetAppFiles();
        }

        public string GetPath()
        {
            return _defaultDirectory;
        }
    }
}
