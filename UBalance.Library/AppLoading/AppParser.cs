using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            _openFileStream.Close();
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
                List<string> newList = test.Where(s => s.Length > 0 && !s.ToLower().Contains("newscreen")).ToList();

                if ( newList.Count == 5)
                    _parsedFile.Add(newList);
            }

            strReader.Close();
        }

        public List<Cell> ReturnCellsInRow(int rowNumber)
        {
            List<Cell> cols = new List<Cell>();
            int colIndex = 0;
            foreach (List<string> l in _parsedFile)
            {
                // there will be 5 items in each .APP file
                if (l.Count != 5) break;
              
                string label = l[0];
                string type = l[1];
                int digits;  // not really necessary for this application, but leaving for reverse compatibility
                int.TryParse(l[2], out digits);

                int precision;
                int.TryParse(l[3], out precision);
                string connectionInfo = l[4];

                switch (type)
                {
                    // keyboard cell
                    case "K":
                        KCell k = new KCell(label, digits, precision, connectionInfo, rowNumber, colIndex);
                        cols.Add(k);
                        break;
                    // weight cell
                    case "W":
                        WCell w = new WCell(label, digits, precision, connectionInfo, rowNumber, colIndex);
                        cols.Add(w);
                        break;
                    // calculation cell
                    case "C":
                        List<string> names =
                            connectionInfo.Split(new char[] { '(', ')', '+', '-', '*', '/', '^' }).ToList();

                        // need for TryParse
                        double n;

                        List<string> dependencyNamesPossibleDupes = (from name in names
                            where name.Length > 0 &&
                            !double.TryParse(name, out n)     // make sure the value isn't an integer
                            select name).ToList();

                        List<string> dependencyNames = dependencyNamesPossibleDupes.Distinct().ToList();
                                                       
                            
                        List<Cell> dependencies = new List<Cell>();

                        foreach (string name in dependencyNames)
                        {
                            Cell dependency = cols.First(x => x.Label == name);

                            if(dependency != null)
                                dependencies.Add(dependency);
                        }

                        CCell c = new CCell(label, digits, precision, connectionInfo, rowNumber, colIndex, dependencies);
                        cols.Add(c);
                        break;
                    // mirror cell
                    case "M":
                        // find cell to mirror
                        var columnToMirror = cols.FirstOrDefault(x => x.Label == connectionInfo);
                        MCell m = new MCell(label, digits, precision, connectionInfo, rowNumber, colIndex, columnToMirror);
                        cols.Add(m);
                        break;
                }

                colIndex++;
            }

            return cols;
        }
    }
}
