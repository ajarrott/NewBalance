using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class BalanceReader : IDisposable
    {
        private readonly SerialPort _port;
        private string _sicsCommand;
        private double _reading = 0.0;

        /*
         *         public string ComPort = String.Empty;
        public int BaudRate = 110;
        public StopBits StopBits = StopBits.None;
        public int DataBits = 7;
        public Parity Parity = Parity.None;
         * */
        public BalanceReader(string comPort = "COM1", int baudRate = 110, StopBits stopBits = StopBits.One,
            int dataBits = 7, Parity parity = Parity.Even, string sicsCommand = "SI")
        {
            _sicsCommand = sicsCommand;

            _port = new SerialPort
            {
                PortName = comPort,
                BaudRate = baudRate,
                StopBits = stopBits,
                //NewLine = System.Environment.NewLine,
                DataBits = 7,
                Parity = Parity.Even
            }; //"COM3", 9600);

            // from Page 39 of NewClassic Balances METTLER TOLEDO manual for MS-S / MS-L Models
            //_port.Handshake = Handshake.XOnXOff;

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
            SerialPort s = sender as SerialPort;

            if (s != null)
            {
                string str = s.ReadLine();
                string[] items = str.Split();

                foreach (string item in items)
                {
                    double temp = 0.0;
                    double.TryParse(item, out temp);

                    if (!temp.Equals(0))
                    {
                        _reading = temp;
                    }
                }

            }
            // need to parse the data to find the string
        }

        public static List<string> GetPortNames()
        {
            return SerialPort.GetPortNames().ToList();
        } 

        public void UpdateCommand()
        {
            if (_port.IsOpen)
            {
                _port.WriteLine(_sicsCommand);
            }
        }

        public double GetBalanceValue()
        {
            return _reading;
        }

        public bool IsBalanceConnected()
        {
            return _port.IsOpen;
        }


        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_port.IsOpen)
                _port.Close();
        }
    }
}
