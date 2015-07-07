using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.AppLoading
{
    public class AppParser
    {
        private FileStream _openFileStream;
        private List<List<string>> _parsedFile;
        
        public AppParser(string pathToFile)
        {
            _openFileStream = new FileStream(pathToFile, FileMode.Open);
            ParseFile();
        }

        private void ParseFile()
        {
            StreamReader strReader = new StreamReader(_openFileStream);
            int i = 0;
            int j = 0;
            string line;
            _parsedFile = new List<List<string>>();
            line = strReader.ReadToEnd();

            string[] lines = line.Split(new char[]{'\n', '\r'});
            List<string> noBlankLines = lines.Where(s => s.Length > 0).ToList();

            foreach(string str in noBlankLines)
            {
                string[] test = str.Split(null);
                List<string> newList = test.Where(s => s.Length > 0).ToList();

                _parsedFile.Add(newList);
            }
        }
    }
}
