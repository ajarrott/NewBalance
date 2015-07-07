using System;
using System.Collections.Generic;
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

        private 
        enum ColumnType 
        {
            K, // Keyboard
            W, // Weight
            C, // Calculation
            M  // Mirror
        }

        // 'K' type elements can have 'AUTO', 'DITTO', or 'NULL'.  'AUTO' will automatically generate numbers                     
        // 'W' type element may have an 'Advance-to-Element' option or 'NULL'.
            // An 'Advance-to-Element' is an element name in the application file that becomes the next data entry cell
            // after weight data has been entered for the current cell. 
        // 'C' type element requires a calculation to be defined for this component.
        // 'M' type element requires the mirrored element name.                                                                       
    }
}
