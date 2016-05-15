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
    public partial class kCellForm : Form
    {
        public string connection { get; private set; }
        public string name { get; private set; }
        public string precision { get; private set; }
        public string digits { get; private set; }

        public kCellForm()
        {
            InitializeComponent();
            nameSetDefaultText();
            this.FormClosing += KCellForm_FormClosing;
            this.connectionTypeComboBox.SelectedIndex = 0;
        }

        public kCellForm(string conn, string n, string p, string d)
        {
            InitializeComponent();
            nameInput.ForeColor = Color.Black;
            this.FormClosing += KCellForm_FormClosing;
            this.connectionTypeComboBox.SelectedIndex = 0;

            connection = conn;
            connectionTypeComboBox.SelectedItem = conn;

            name = n;
            nameInput.Text = n;

            precision = p;
            precisionInput.Text = p;

            digits = d;
            digitsInput.Text = d;
        }

        private void nameSetDefaultText()
        {
            this.nameInput.Text = "16 Characters Max";
            this.nameInput.ForeColor = Color.Gray;
        }

        private void name_leave(object sender, EventArgs e)
        {
            if (this.nameInput.Text.Trim() == "") nameSetDefaultText();
            FixNameText();
        }

        public void FixNameText()
        {
            this.nameInput.Text = this.nameInput.Text.Replace(' ', '_').ToUpper();
            name = nameInput.Text;
        }

        private void name_enter(object sender, EventArgs e)
        {
            if (nameInput.ForeColor == Color.Black) return;

            nameInput.Text = "";
            nameInput.ForeColor = Color.Black;
        }

        private void precision_leave(object sender, EventArgs e)
        {
            int n;

            if (!int.TryParse(precisionInput.Text, out n))
            {
                MessageBox.Show("Please use only numbers in the precision textbox.", "Error", MessageBoxButtons.OK);

                precisionInput.Text = "";

                return;
            }

            precision = precisionInput.Text;
        }

        private void digits_leave(object sender, EventArgs e)
        {
            int n;

            if (!int.TryParse(digitsInput.Text, out n))
            {
                MessageBox.Show("Please use only numbers in the digits textbox.", "Error", MessageBoxButtons.OK);

                precisionInput.Text = "";

                return;
            }

            digits = digitsInput.Text;
        }

        private void KCellForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // make sure we have values for everything
            digits = digitsInput.Text;
            precision = precisionInput.Text;
            FixNameText();
            name = nameInput.Text;
            connection = connectionTypeComboBox.SelectedItem.ToString();
        }
    }
}
