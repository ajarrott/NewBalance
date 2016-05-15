using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBalance.Library.Classes
{
    public class ColorMeter : IDisposable
    {
        private SerialPort _port;
        private string _colorCommand;

        public double L { get { return _L; } }
        public double a { get { return _a; } }
        public double b { get { return _b; } }

        private double _L;
        private double _a;
        private double _b;

        public delegate void SendColorData(ColorMeter sender, EventArgs e);
        public event SendColorData sendData = delegate { };

        // ColorReader's serial communcation is defined specifically in the manual
        // the only options will be for the COMPORT and Command
        public ColorMeter(string comPort = "COM1", string colorCommand = "SI")
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
                catch (Exception)
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
                string output = temp.ReadLine();
                char[] separators = {' ', '\n', '\r', '+'};
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
                    if (!double.TryParse(validValues[validValues.IndexOf("L") + 1], out _L)) _L = 0.0;
                    if (!double.TryParse(validValues[validValues.IndexOf("a") + 1], out _a)) _a = 0.0;
                    if (!double.TryParse(validValues[validValues.IndexOf("b") + 1], out _b)) _b = 0.0;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return;
                }

                if (_L == 0.0 || _a == 0.0 || _b == 0.0) return;

                // send event if successful read completed
                sendData(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            _port.Close();
            _port.Dispose();
            sendData = delegate { };
        }
    }
}
