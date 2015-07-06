using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBalance.Library.Classes;

namespace UBalance.Library.AppLoading
{
    public class AppLoader
    {
        private List<AppItem> _appFiles;
        private string _defaultDirectory = "C:\\Users\\anthony\\Desktop\\Balance";
        public AppLoader()
        {
            GetAppFiles();
        }

        private void GetAppFiles()
        {
            _appFiles = new List<AppItem>();
            List<string> fileNames = Directory.GetFiles(_defaultDirectory, "*.APP").ToList();

            foreach (string filename in fileNames)
            {
                AppItem a = new AppItem(filename);
                _appFiles.Add(a);
            }
        }

        public List<string> GetFileNames()
        {
            return _appFiles.Select(a => a.GetName()).ToList();
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
