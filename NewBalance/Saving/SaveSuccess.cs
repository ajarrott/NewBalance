using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewBalance
{
    public partial class SaveSuccess : Form
    {
        public SaveSuccess(string filename)
        {
            InitializeComponent();

            label1.Text += filename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closing_event(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
