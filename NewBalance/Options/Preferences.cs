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
    public partial class Preferences : Form
    {
        private DataGridViewCellStyle _old_cell_style, _old_col_style;

        public Color foreColor { get; private set; }
        public Color backColor { get; private set; }

        public Preferences(DataGridViewCellStyle cell_style, DataGridViewCellStyle col_style)
        {
            InitializeComponent();

            _old_cell_style = cell_style;
            _old_col_style = col_style;

            foreColor = cell_style.ForeColor;
            backColor = cell_style.BackColor;

            this.dataGridView1.DefaultCellStyle = cell_style;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = col_style;
            this.dataGridView1.RowsDefaultCellStyle = col_style;
            this.dataGridView1.RowCount = 2;
            this.dataGridView1.ColumnCount = 1;
            this.dataGridView1.Rows[0].Cells[0].Value = "New Style 1";
            this.dataGridView1.Rows[1].Cells[0].Value = "New Style 2";
            this.dataGridView1.Columns[0].HeaderText = "Header";
        }

        private void ChangeFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            DialogResult result = c.ShowDialog();
            if (result != DialogResult.Cancel || result != DialogResult.Cancel)
            {
                _old_cell_style.ForeColor = c.Color;
                _old_col_style.ForeColor = c.Color;

                foreColor = c.Color;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;

            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void ChangeBackground_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            DialogResult result = c.ShowDialog();
            if (result != DialogResult.Cancel || result != DialogResult.Cancel)
            {
                _old_cell_style.BackColor = c.Color;
                _old_col_style.BackColor = c.Color;

                backColor = c.Color;
            }
        }
    }
}
