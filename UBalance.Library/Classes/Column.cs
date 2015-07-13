using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class Column
    {
        private string _Label;
        private ColumnType _Type;
        private string _Digits;
        private string _Precision;
        private string _Connection;

        public enum ColumnType 
        {
            K, // Keyboard
            W, // Weight
            C, // Calculation
            M  // Mirror
        }

        // getters
        public Column(string label, ColumnType type, string digits, string precision, string connection)
        {
            _Label = label;
            _Type = type;
            _Digits = digits;
            _Precision = precision;
            _Connection = connection;
        }

        public int Digits
        {
            get
            {
                try
                {
                    int returnValue;
                    int.TryParse(_Digits, out returnValue);
                    return returnValue;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public int Precision
        {
            get
            {
                try
                {
                    int returnValue;
                    int.TryParse(_Precision, out returnValue);
                    return returnValue;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public string Label
        {
            get { return _Label; }
        }

        public ColumnType Type
        {
            get { return _Type; }
        }

        public string Connection
        {
            get { return _Connection; }
        }
        // 'K' type elements can have 'AUTO', 'DITTO', or 'NULL'.  'AUTO' will automatically generate numbers                     
        // 'W' type element may have an 'Advance-to-Element' option or 'NULL'.
            // An 'Advance-to-Element' is an element name in the application file that becomes the next data entry cell
            // after weight data has been entered for the current cell. 
        // 'C' type element requires a calculation to be defined for this component.
        // 'M' type element requires the mirrored element name.                                                                       
    }
}
