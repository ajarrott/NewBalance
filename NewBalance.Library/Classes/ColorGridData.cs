using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBalance.Library.Classes
{
    public class ColorGridData
    {
        // column count will always be the same
        private List<List<string>> _colorData;

        public delegate void ColorDataValueChange(ColorGridData sender, EventArgs e);
        public event ColorDataValueChange sendData = delegate { };

        public ColorGridData(string[] rowData)
        {
            _colorData = new List<List<string>>();

            _colorData.Add(rowData.ToList());
        }

        public void ColorGridAddRow(string[] rowData)
        {
            _colorData.Add(rowData.ToList());
        }

        public string GetValue(int row, int col) //GridViewLocation col)
        {
            try
            {
                
                return _colorData[row][col];
            }
            catch(IndexOutOfRangeException)
            {
                return "";
            }
        }

        private string FormatValue(string value, int col)//GridViewLocation col)
        {
            ColorValue c = FindColorValue(col);
            StringBuilder sb = new StringBuilder();
            double n;

            if(double.TryParse(value, out n))
            {
                if (n < 0 && (c == ColorValue.a || c == ColorValue.b))
                {
                    sb.Append('-');
                }
                else if (n != 0.0 && c == ColorValue.a || c == ColorValue.b)
                {
                    sb.Append('+');
                }
            }

            sb.Append(value);

            return sb.ToString();
        }

        private ColorValue FindColorValue(int col)
        {
            if(col ==  (int) GridViewLocation.a_1 || 
               col == (int) GridViewLocation.a_2 || 
               col == (int) GridViewLocation.a_3)
            {
                return ColorValue.a;
            }

            if (col == (int) GridViewLocation.b_1 ||
                col == (int) GridViewLocation.b_2 ||
                col == (int) GridViewLocation.b_3)
            {
                return ColorValue.b;
            }

            // No matter what we do not format L or any other values, add + or - to a/b
            return ColorValue.L;
        }

        public void UpdateValue(int row, int col, string value)
        {
            try
            {
                _colorData[row][col] = FormatValue(value, col);
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public enum ColorValue
        {
            L,
            a,
            b,
        }

        public enum GridViewLocation
        {
            Nursery = 0,
            Sample,
            Noodle,
            L_1,
            a_1,
            b_1,
            L_2,
            a_2,
            b_2,
            L_3,
            a_3,
            b_3,
            L_avg,
            a_avg,
            b_avg
        }
    }
}
