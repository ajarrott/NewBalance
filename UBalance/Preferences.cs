using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBalance.Library.Events;

namespace UBalance
{
    public partial class Preferences : Form
    {
        public delegate void EventHandler(object sender, PreferenceCloseEventArgs e);
        public event EventHandler CloseEvent = delegate { };
        public string Path;

        public Preferences()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get the previous path
            textBox1.Text = UBalance.App.GetPath();

            // get the new path
            FolderBrowserDialog f = new FolderBrowserDialog();

            f.ShowDialog();

            Path = f.SelectedPath;
            textBox1.Text = f.SelectedPath;

            UBalance.App.UpdatePath(f.SelectedPath);
            
            Show();
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            textBox1.Text = UBalance.App.GetPath();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent(this, new PreferenceCloseEventArgs(textBox1.Text));
        }
    }
}
