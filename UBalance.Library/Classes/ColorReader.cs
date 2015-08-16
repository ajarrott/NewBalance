using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class ColorReader
    {
        private SerialPort _port;
        private string _colorCommand;
        private double _L;
        private double _a;
        private double _b;

        // ColorReader's serial communcation is defined specifically in the manual
        // the only options will be for the COMPORT and Command
        public ColorReader(string comPort = "COM1", string colorCommand = "SI")
        {
            _colorCommand = colorCommand;

            _port = new SerialPort
            {
                PortName = comPort,
                BaudRate = 4800,
                StopBits = StopBits.Two,
                DataBits = 7,
                Parity = Parity.Even,
                RtsEnable = true,
            };

            if (_port.IsOpen == false)
            {
                try
                {
                    _port.Open();
                }
                catch (Exception ex)
                {
                    //
                }
            }

            _port.DataReceived += _port_DataReceived;
        }

        void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort temp = sender as SerialPort;

            if (temp != null)
            {
                string output = temp.ReadExisting();
                char[] separators = {' ', '\n', '\r'};
                string[] strings = output.Split(separators);
                List<string> validValues = new List<string>();

                // line number will be the first string
                for (int i = 1; i < strings.Length; i++)
                {
                    if (strings[i].Length > 0)
                    {
                        validValues.Add(strings[i]);    
                    }
                }
                //double result = 0.0;

                try
                {
                    double.TryParse(validValues[validValues.IndexOf("L") + 1], out _L);
                    double.TryParse(validValues[validValues.IndexOf("a") + 1], out _a);
                    double.TryParse(validValues[validValues.IndexOf("b") + 1], out _b);
                }
                catch (Exception ex)
                {
                    // exception, most likely out of range, set all values to zero, there was an issue
                    // with reading from the color meter
                    _L = _a = _b = 0.0;
                }
            }
        }
    }
}
