using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBalance.Library.AppLoading;
using UBalance.Library.Classes;
using UBalance.Library.Events;
using UBalance.Properties;

namespace UBalance
{
    public partial class UBalance : Form
    {
        public static AppLoader App = new AppLoader();
        public static FolderBrowserDialog FolderBroswer = new FolderBrowserDialog();
        public GridData ViewData;
        public BalanceReader Balance;

        public UBalance()
        {
            Balance = DefaultBalance();
            // update command being sent to the balance on click
            Balance.UpdateCommand();

            InitializeComponent();
            addRowButton.Enabled = false;

            readBalanceButton.Enabled = Balance.IsBalanceConnected();
        }

        private BalanceReader DefaultBalance()
        {
            // Get default settings and create balance reader off of those options
            string comPort = Settings.Default.COMPort;          //1 - position in constructor
            int baudRate = Settings.Default.BaudRate;           //2
            int dataBits = Settings.Default.DataBits;           //4
            StopBits stopBits;                                  //3
            Parity parity;                                      //5
            string sicsCommand = Settings.Default.SICSCommand;  //6

            //Send sicsCommand to scale to update the value

            Enum.TryParse(Settings.Default.StopBits, out stopBits);
            Enum.TryParse(Settings.Default.Parity, out parity);

            return new BalanceReader(comPort, baudRate, stopBits, dataBits, parity, sicsCommand);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAndUpdateAppFiles();
        }

        public void LoadAndUpdateAppFiles()
        {
            // remove the old toolstrip menu items if they exist
            if (appsToolStripMenuItem.DropDownItems.Count > 0)
            {
                while (appsToolStripMenuItem.DropDownItems.Count != 0)
                {
                    appsToolStripMenuItem.DropDownItems.RemoveAt(0);
                }
                //foreach (ToolStripMenuItem t in appsToolStripMenuItem.DropDownItems)
                //{
                //    appsToolStripMenuItem.DropDownItems.Remove(t);
                //}
            }

            List<string> itemsToAddToMenu = App.GetFileNames();

            if (itemsToAddToMenu.Count == 0)
            {
                // no .APP files found in the directory, adding useful info for the user
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Enabled = false;
                item.Text = "No app items found";
                this.appsToolStripMenuItem.DropDownItems.Insert(0, item);
            }
            else
            {
                int i = 0;
                foreach (string s in itemsToAddToMenu)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Enabled = true;
                    item.Text = Path.GetFileNameWithoutExtension(s);
                    item.Click += item_Click;
                    this.appsToolStripMenuItem.DropDownItems.Insert(i, item);
                    i++;
                }
            }
            //this.appsToolStripMenuItem.Enabled = true;
        }

        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = sender as ToolStripMenuItem;

            //find item in app
            int index = App.GetFileNames().IndexOf(t.Text);

            AppParser a = new AppParser(App.GetDirectoryNames()[index]);
            ViewData = new GridData(a.ReturnDefaultRow());


            List<string> columnHeaders = ViewData.ColumnHeaders();

            int count = columnHeaders.Count;

            UBalanceDataGridView.ColumnCount = count;
            if (UBalanceDataGridView.Rows.Count < 1)
            {
                UBalanceDataGridView.Rows.Add();
                ViewData.AddRow();
            }
            
            for (int i = 0; i < count; i++)
            {
                UBalanceDataGridView.Columns[i].HeaderText = columnHeaders[i];
            }

            addRowButton.Enabled = true;
            //textBox1.Text = app.GetDirectoryNames()[index];
            //.ShowDialog();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pref = new Preferences();

            pref.CloseEvent += pref_CloseEvent;

            pref.Show();
        }

        private void pref_CloseEvent(object sender, PreferenceCloseEventArgs e)
        {
            App.UpdatePath(e.Text);
            // update balance settings
            if(Balance != null)
                Balance.Dispose();
            Balance = DefaultBalance();
            
            LoadAndUpdateAppFiles();

            readBalanceButton.Enabled = Balance.IsBalanceConnected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UBalanceDataGridView.Rows.Add();
            ViewData.AddRow();
        }

        private void readBalanceButton_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            try
            {
                cell = UBalanceDataGridView.SelectedCells[0];
            }
            catch (Exception ex)
            {
                //ignore, keep cell null
            }
                

            if (cell != null)
            {
                cell.Value = Balance.GetBalanceValue();
            }
        }
    }
}
