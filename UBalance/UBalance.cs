using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBalance.Library.AppLoading;
using UBalance.Library.Events;

namespace UBalance
{
    public partial class UBalance : Form
    {
        public static AppLoader App = new AppLoader();
        public static FolderBrowserDialog FolderBroswer = new FolderBrowserDialog();
        

        public UBalance()
        {
            InitializeComponent();
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

            Popup p = new Popup();

            p.Text = t.Text;
            p.ChangeTextBox1Text(App.GetDirectoryNames()[index]);

            p.Show();

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
            LoadAndUpdateAppFiles();
        }
    }
}
