using NewBalance.Library.Classes;
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
    public partial class cCellForm : Form
    {
        public string connection { get; private set; }
        public string name { get; private set; }
        public string precision { get; private set; }
        public string digits { get; private set; }

        public cCellForm(List<string> possibleCalcCells)
        {
            InitializeComponent();
            OnLoad(possibleCalcCells);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn">Connection String</param>
        /// <param name="n">Name String</param>
        /// <param name="p">Precision</param>
        /// <param name="d">Digits</param>
        /// <param name="possibleCalcCells"></param>
        public cCellForm(string conn, string n, string p, string d, List<string> possibleCalcCells)
        {
            connection = conn;
            equationTextBox.Text = conn;

            name = n;
            nameInput.Text = n;

            precision = p;
            precisionInput.Text = p;

            digits = d;
            digitsInput.Text = d;

            OnLoad(possibleCalcCells);

            variableCellListBox.DoubleClick += VariableCellListBox_DoubleClick;
        }

        private void VariableCellListBox_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnLoad(List<string> possibleCalcCells)
        {
            nameSetDefaultText();

            variableCellListBox.DataSource = possibleCalcCells;

            this.FormClosing += CCellForm_FormClosing;
        }

        private void CCellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // make sure we have values for everything
            int n;
            /*if (digits.Length == 0 && int.TryParse(digitsInput.Text, out n))
            {
                digits = digitsInput.Text;
            }

            if (precision.Length == 0 && int.TryParse(precisionInput.Text, out n))
            {
                precision = precisionInput.Text;
            }

            if (name.Length == 0 && nameInput.Text.Length > 0)
            {
                name = nameInput.Text;
            }

            if (connection.Length == 0 && equationTextBox.Text.Length > 0)
            {
                connection = equationTextBox.SelectedText;
            }*/

            digits = digitsInput.Text;
            precision = precisionInput.Text;
            name = nameInput.Text;
            connection = equationTextBox.Text;
        }

        private void nameSetDefaultText()
        {
            this.nameInput.Text = "16 Characters Max";
            this.nameInput.ForeColor = Color.Gray;
        }

        private void name_leave(object sender, EventArgs e)
        {
            if (this.nameInput.Text.Trim() == "") nameSetDefaultText();

            this.nameInput.Text.Replace(' ', '_');
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

        private void equationTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                Calculation c = new Calculation(equationTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Parenthesis Error", MessageBoxButtons.OK);
                return;
            }

            connection = equationTextBox.Text;
        }

        private void MCellForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // make sure we have values for everything
            int n;
            if(digits.Length == 0 && int.TryParse(digitsInput.Text, out n))
            {
                digits = digitsInput.Text;
            }

            if(precision.Length == 0 && int.TryParse(precisionInput.Text, out n))
            {
                precision = precisionInput.Text;
            }

            if (name.Length == 0 && nameInput.Text.Length > 0)
            {
                name = nameInput.Text;
            }

            if (connection.Length == 0 && equationTextBox.Text.Length > 0)
            {
                connection = equationTextBox.Text;
            }
        }

        private void variableCellListBox_DoubleClick(object sender, MouseEventArgs e)
        {

            equationTextBox.AppendText(variableCellListBox.SelectedItem.ToString());
        }
    }
}
