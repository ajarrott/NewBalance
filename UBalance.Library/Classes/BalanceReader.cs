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

        public BalanceReader()
        {
            _port = new SerialPort(); //"COM3", 9600);

            _port.PortName = "COM3";
            _port.BaudRate = 9600;
            // from Page 39 of NewClassic Balances METTLER TOLEDO manual for MS-S / MS-L Models
            _port.StopBits = StopBits.One;
            //_port.Handshake = Handshake.XOnXOff;
            _port.NewLine = System.Environment.NewLine;
            _port.DataBits = 7;
            _port.Parity = Parity.Even;

            if (_port.IsOpen == false)
                _port.Open();

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
