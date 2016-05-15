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
    public partial class mCellForm : Form
    {
        public string connection { get; private set; }
        public string name { get; private set; }
        public string precision { get; private set; }
        public string digits { get; private set; }

        public mCellForm(List<string> possibleMirrorCells)
        {
            InitializeComponent();

            nameSetDefaultText();

            precision = "0";
            digits = "0";

            if(possibleMirrorCells.Count == 0)
            {
                MessageBox.Show("No cells to mirror", "Error", MessageBoxButtons.OK);
                return;
            }

            cellToMirrorComboBox.Items.AddRange(possibleMirrorCells.ToArray());

            cellToMirrorComboBox.SelectionChangeCommitted += CellToMirrorComboBox_SelectionChangeCommitted;

            this.FormClosing += MCellForm_FormClosing;
        }

        public mCellForm(string conn, string n, string p, string d, List<string> possibleMirrorCells)
        {
            precision = p;
            digits = d;
            connection = conn;
            name = n;

            try
            {
                cellToMirrorComboBox.SelectedText = conn;
            }
            catch (Exception) { }
        }

        private void CellToMirrorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            connection = cellToMirrorComboBox.SelectedText;
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

        private void MCellForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // make sure we have values for everything
            /*int n;
            if(digits.Length == 0 && int.TryParse(digitsInput.Text, out n))
            {
                digits = digitsInput.Text;
            }

            if(precision.Length == 0 && int.TryParse(precisionInput.Text, out n))
            {
                precision = precisionInput.Text;
            }*/

            if(name.Length == 0 && nameInput.Text.Length > 0)
            {
                name = nameInput.Text;
            }

            if(connection.Length == 0 && cellToMirrorComboBox.Items.Count > 0)
            {
                connection = cellToMirrorComboBox.SelectedText;
            }
        }

    }
}
