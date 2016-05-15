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
    public partial class wCellForm : Form
    {
        public string connection { get; private set; }
        public string name { get; private set; }
        public string precision { get; private set; }
        public string digits { get; private set; }

        public wCellForm(List<string> possibleAdvanceCells)
        {
            InitializeComponent();
            nameSetDefaultText();
            this.FormClosing += WCellForm_FormClosing;
            this.advanceToCellComboBox.SelectedIndex = 0;
            addToComboBox(possibleAdvanceCells);
        }

        public wCellForm(string conn, string n, string p, string d, List<string> possibleAdvanceCells)
        {
            InitializeComponent();
            nameInput.ForeColor = Color.Black;
            this.FormClosing += WCellForm_FormClosing;
            this.advanceToCellComboBox.SelectedIndex = 0;
            addToComboBox(possibleAdvanceCells);

            connection = conn;
            advanceToCellComboBox.SelectedItem = conn;

            name = n;
            nameInput.Text = n;

            precision = p;
            precisionInput.Text = p;

            digits = d;
            digitsInput.Text = d;
        }

        private void addToComboBox(List<string> toAdd)
        {
            foreach(string s in toAdd)
            {
                advanceToCellComboBox.Items.Add(s);
            }
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

        public void FixNameText()
        {
            this.nameInput.Text = this.nameInput.Text.Replace(' ', '_').ToUpper();
            name = nameInput.Text;
        }

        private void WCellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // make sure we have values for everything
            digits = digitsInput.Text;
            precision = precisionInput.Text;
            FixNameText();
            name = nameInput.Text;
            connection = advanceToCellComboBox.SelectedItem.ToString();
        }
    }
}
