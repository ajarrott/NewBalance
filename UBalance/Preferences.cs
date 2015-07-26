using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using UBalance.Library.Classes;
using UBalance.Library.Events;
using UBalance.Properties;

namespace UBalance
{
    public partial class Preferences : Form
    {
        public delegate void EventHandler(object sender, PreferenceCloseEventArgs e);
        public event EventHandler CloseEvent = delegate { };
        public string Path;

        // Serial Port preferences
        public string ComPort = String.Empty;
        public int BaudRate = 110;
        public StopBits StopBits = StopBits.None;
        public int DataBits = 7;
        public Parity Parity = Parity.None;

        // for population of ComboBoxes
        private List<string> parityItems = new List<string>()
        {
            Parity.Even.ToString(),
            Parity.Mark.ToString(),
            Parity.None.ToString(),
            Parity.Odd.ToString(),
            Parity.Space.ToString()
        };

        private List<string> stopBitItems = new List<string>
        {
            StopBits.None.ToString(),
            StopBits.One.ToString(),
            StopBits.OnePointFive.ToString(),
            StopBits.Two.ToString()
        };

        private List<int> dataBitItems = new List<int>()
        {
            7,8
        };

        private List<int> baudRates = new List<int>()
        {
            110, 150, 300, 1200, 2400, 4800, 9600, 19200, 38400
        };

        public Preferences()
        {
            InitializeComponent();

            GetDefaults();
            PopulateLists();
            CheckPreferences();
        }

        private void GetDefaults()
        {
            ComPort = Settings.Default.COMPort;
            BaudRate = Settings.Default.BaudRate;
            Enum.TryParse(Settings.Default.StopBits, out StopBits);
            DataBits = Settings.Default.DataBits;
            Enum.TryParse(Settings.Default.Parity, out Parity);
            Path = Settings.Default.DefaultPath;
        }

        private void CheckPreferences()
        {
            // get the previous path
            DefaultPath.Text = Settings.Default.DefaultPath;

            if (ComPort.Length > 0)
            {
                // find item
                foreach (string s in ComPortList.Items)
                {
                    if (s != ComPort) continue;
                    ComPortList.SelectedItem = s;
                    ComPort = s;
                    break;
                }
            }

            if (BaudRate > 0)
            {
                foreach (int i in baudRateList.Items)
                {
                    if (i == BaudRate)
                    {
                        baudRateList.SelectedItem = i;
                    }
                }
            }

            foreach (string s in stopBitItems)
            {
                if (StopBits.ToString() == s)
                {
                    stopBitsList.SelectedItem = s;
                }
            }

            foreach (string s in parityItems)
            {
                if (Parity.ToString() == s)
                {
                    parityList.SelectedItem = s;
                }
            }

            foreach (int i in dataBitItems)
            {
                if (DataBits == i)
                {
                    dataBitsList.SelectedItem = i;
                }
            }

        }

        private void PopulateLists()
        {
            foreach (string s in BalanceReader.GetPortNames())
            {
                ComPortList.Items.Add(s);
            }

            // Populate BaudRate ListBox
            foreach (int i in baudRates)
            {
                baudRateList.Items.Add(i);
            }

            // Populate Parity ListBox
            foreach (string s in parityItems)
            {
                parityList.Items.Add(s);
            }

            // Populate StopBits ListBox
            foreach (string s in stopBitItems)
            {
                stopBitsList.Items.Add(s);
            }

            // Populate DataBits ListBox
            foreach (int i in dataBitItems)
            {
                dataBitsList.Items.Add(i);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get the new path
            FolderBrowserDialog f = new FolderBrowserDialog();

            f.ShowDialog();

            Path = f.SelectedPath;
            DefaultPath.Text = f.SelectedPath;

            UBalance.App.UpdatePath(f.SelectedPath);
            
            Show();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            //
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent(this, new PreferenceCloseEventArgs(DefaultPath.Text));
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Settings.Default.BaudRate = BaudRate;
            Settings.Default.COMPort = ComPort;
            Settings.Default.DataBits = DataBits;
            Settings.Default.DefaultPath = Path;
            Settings.Default.Parity = Parity.ToString();
            Settings.Default.StopBits = StopBits.ToString();

            Settings.Default.Save();
            Close();
        }

        private void ComPortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null) ComPort = c.SelectedItem.ToString();
        }

        private void baudRateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null) BaudRate = (int)c.SelectedItem;
        }

        private void parityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null) Enum.TryParse(c.SelectedItem.ToString(), out Parity);
        }

        private void stopBitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null) Enum.TryParse(c.SelectedItem.ToString(), out StopBits);
        }

        private void dataBitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c = sender as ComboBox;

            if (c != null) DataBits = (int)c.SelectedItem;
        }
    }
}
