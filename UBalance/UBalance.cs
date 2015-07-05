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

namespace UBalance
{
    public partial class UBalance : Form
    {
        AppLoader app = new AppLoader();

        public UBalance()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> itemsToAddToMenu = app.GetFileNames();

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

            int index = app.GetFileNames().IndexOf(t.Text);

            Popup p = new Popup();

            p.Text = t.Text;
            p.ChangeTextBox1Text(app.GetDirectoryNames()[index]);

            p.Show();

            //textBox1.Text = app.GetDirectoryNames()[index];
            //.ShowDialog();
        }
    }
}
