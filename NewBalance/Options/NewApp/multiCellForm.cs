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
    public partial class multiCellForm : Form
    {
        public string connection { get; private set; }
        public string name { get; private set; }
        public string precision { get; private set; }
        public string digits { get; private set; }

        public multiCellForm(List<string> possibleMirrorCells)
        {
            InitializeComponent();

            nameSetDefaultText();
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
    }
}
