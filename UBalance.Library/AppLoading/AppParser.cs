using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBalance.Library.Classes;

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
            string line;
            _parsedFile = new List<List<string>>();
            line = strReader.ReadToEnd();

            string[] lines = line.Split(new char[]{'\n', '\r'});
            List<string> noBlankLines = lines.Where(s => s.Length > 0).ToList();

            foreach(string str in noBlankLines)
            {
                string[] test = str.Split(null);
                List<string> newList = test.Where(s => s.Length > 0).ToList();

                if ( newList.Count == 5 )
                    _parsedFile.Add(newList);
            }


        }

        public Row ReturnDefaultRow()
        {
            List<Column> cols = new List<Column>();
            foreach (List<string> l in _parsedFile)
            {
                // there will be 5 items in each .APP file
                string label = l[0];
                Column.ColumnType type;
                Column.ColumnType.TryParse(l[1], out type);
                string digits = l[2];
                string precision = l[3];
                string connection = l[4];
                Column c = new Column(label, type, digits, precision, connection);
                cols.Add(c);
            }
            Row r = new Row(cols, 0);

            return r;
        }
    }
}
