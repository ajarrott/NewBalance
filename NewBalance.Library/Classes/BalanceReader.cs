﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBalance.Library.Classes
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
        public BalanceReader(string comPort = "COM1", int baudRate = 9600, StopBits stopBits = StopBits.One,
            int dataBits = 7, Parity parity = Parity.Even, string sicsCommand = "SI", bool rts = false)
        {
            _sicsCommand = sicsCommand;

            if (comPort == String.Empty) comPort = "COM1";
            _port = new SerialPort
            {
                PortName = comPort,
                BaudRate = baudRate,
                StopBits = stopBits,
                DataBits = 7,
                Parity = Parity.Even,
                RtsEnable = rts
            };

            // from Page 39 of NewClassic Balances METTLER TOLEDO manual for MS-S / MS-L Models
            //_port.Handshake = Handshake.XOnXOff;

            if (_port.IsOpen == false)
            {
                try
                {
                    _port.Open();
                }
                catch (Exception)
                {
                    // port will not be open, therefore will become null
                }
            }
                
            _port.DataReceived += _port_DataReceived;
        }

        void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort s = sender as SerialPort;

            if (s != null)
            {
                byte[] buffer = new byte[256];
                try
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
                catch (Exception)
                {
                    //
                }//string str = System.Text.ASCIIEncoding.Default.GetString(buffer);//.ToString();


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
