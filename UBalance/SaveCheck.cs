using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBalance
{
    public partial class SaveCheck : Form
    {
        public SaveCheck()
        {
            InitializeComponent();
        }

        public void LabelCorrectlyFromLoad()
        {
            saveFileText.Text += "before opening a new file?";
        }

        public void LabelCorrectlyFromChangeApp()
        {
            saveFileText.Text += "before loading a new app?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
