using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBalance.Library.Classes
{
    public class BalanceReader
    {
        private readonly SerialPort _port;

        /*
         *         public string ComPort = String.Empty;
        public int BaudRate = 110;
        public StopBits StopBits = StopBits.None;
        public int DataBits = 7;
        public Parity Parity = Parity.None;
         * */
        public BalanceReader(string comPort = "COM1", int baudRate = 110, StopBits stopBits = StopBits.One, int dataBits = 7, Parity parity = Parity.Even)
        {       
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

        }

        public static List<string> GetPortNames()
        {
            return SerialPort.GetPortNames().ToList();
        } 

        public double ReadBalance()
        {
            
            //string temp = _port.ReadLine();
            //_port.ReadBufferSize = 128;
            //string t1 = _port.ReadBufferSize = 

            //string t2 = _port.ReadExisting();
            //string t3 = _port.BytesToRead.ToString();

            List<string> forShitsAndGigs = GetPortNames();

            return 0.0;
        }
    }
}
