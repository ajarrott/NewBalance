using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBalance.Logic.AppLoading;

namespace UBalance.Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            AppLoader app = new AppLoader();

            List<string> l = app.GetFileNames("C:\\Users\\anthony\\Desktop\\Balance");

            foreach (string s in l)
            {
                string temp = Path.GetFileNameWithoutExtension(s);
                Console.WriteLine(temp);
                Console.ReadKey();
            }
        }
    }
}
