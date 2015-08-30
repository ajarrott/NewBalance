using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBalance
{
    public partial class SingleSerialPopup : Form
    {
        public SerialType PortType{ get; set; }
        public string PortName { get; set; }

        public SingleSerialPopup()
        {
            InitializeComponent();
            try
            {
                PortName = SerialPort.GetPortNames().ToList()[0];
            }
            catch
            {
                // no ports connected should not get here
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PortType = SerialType.Balance;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PortType = SerialType.ColorMeter;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PortType = SerialType.Neither;
        }
    }

    public enum SerialType
    {
        Balance,
        ColorMeter,
        Neither
    }
}
