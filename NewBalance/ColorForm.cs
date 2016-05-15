using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewBalance.Library.Classes;

namespace NewBalance
{
    public partial class ColorForm : Form
    {
        private ColorMeter _colorMeter;
        private int _currentCol;
        private int _currentRow;
        private ColorGridData _gridData;

        private DataGridViewCell _currentCell;

        public ColorForm(ColorMeter c)
        {
            InitializeComponent();

            tester t = new tester();
            _colorMeter = c;
            _colorMeter.sendData += _colorMeter_sendData;

            colorDataGridView.CellBeginEdit += ColorDataGridView_CellBeginEdit;
            colorDataGridView.CellEndEdit += ColorDataGridView_CellEndEdit;

            _gridData = new ColorGridData(AddRow(true));
        }

        private void ColorDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell d = (sender as DataGridView).Rows[_currentRow].Cells[_currentCol];

            _gridData.UpdateValue(_currentRow, _currentCol, d.Value.ToString());

            return;
        }

        private void ColorDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell d = (sender as DataGridView).SelectedCells[0];

            _currentCell = d;
            _currentCol = d.ColumnIndex;
            _currentRow = d.RowIndex;

            d.Value = _gridData.GetValue(_currentRow, _currentCol);

            return;
        }

        /*
        private void Color_sendData(ColorReader sender, EventArgs e)
        {

        }
        */

        private void _colorMeter_sendData(ColorMeter sender, EventArgs e)
        {
            MessageBox.Show("L: " + sender.L + "\n"
                            + "a: " + sender.a +
                            "b: " + sender.b);

            int startCol;
            int startRow = colorDataGridView.SelectedCells[0].RowIndex;
            int val = colorDataGridView.SelectedCells[0].ColumnIndex;

            if( val < 3)
            {
                startCol = 4;
            }
            else if( val < 6)
            {
                startCol = 7;
            }
            else if( val < 9)
            {
                startCol = 11;
            }
            else
            {
                _gridData.ColorGridAddRow(AddRow());
                startRow++;
                startCol = 4;
            }

            colorDataGridView.Rows[startRow].Cells[startCol].Value = sender.L;
            colorDataGridView.Rows[startRow].Cells[startCol + 1].Value = sender.a;
            colorDataGridView.Rows[startRow].Cells[startCol + 2].Value = sender.b;

            CalculateAverage(startRow);


        }

        private void CalculateAverage(int row)
        {
            double x = 0.0, y = 0.0, z = 0.0;
            double Lavg, Aavg, Bavg;

            for(int i = 1; i < 10; i++)
            {
                double tmp;
                double.TryParse(colorDataGridView.Rows[row].Cells[i].Value.ToString(), out tmp);
                if(i % 3 == 1)
                {
                    x += tmp;
                }
                if(i % 3 == 2)
                {
                    y += tmp;
                }
                if(i % 3 == 0)
                {
                    z += tmp;
                }
            }

            Lavg = x / 3;
            Aavg = y / 3;
            Bavg = z / 3;

            _gridData.UpdateValue(row, (int) ColorGridData.GridViewLocation.L_avg, Lavg.ToString());
            _gridData.UpdateValue(row, (int) ColorGridData.GridViewLocation.a_avg, Aavg.ToString());
            _gridData.UpdateValue(row, (int) ColorGridData.GridViewLocation.b_avg, Bavg.ToString());
        }

        private void FindNextEmptySet()
        {
            // set to next x_L column that is empty
        }

        private string[] AddRow(bool firstrow = false)
        {
            colorDataGridView.Rows.Add();
            
            if (firstrow)
            {
                int startNursery = 1, startSample = 1, startNoodle = 2;

                colorDataGridView.Rows[0].Cells[0].Value = startNursery;
                colorDataGridView.Rows[0].Cells[1].Value = startSample;
                colorDataGridView.Rows[0].Cells[2].Value = startNoodle;

                return new string[] {startNursery.ToString(), startSample.ToString(), startNoodle.ToString(),
                "", "", "", // Lab 1
                "", "", "", // Lab 2
                "", "", "", // Lab 3
                "", "", "" }; // Lab Avg
            }

            int rowIndex = colorDataGridView.Rows.Count - 1;
            int nursery, sample, noodle;

            string oldNursery = _gridData.GetValue(rowIndex - 1, (int)ColorGridData.GridViewLocation.Nursery);
            string oldSample = _gridData.GetValue(rowIndex - 1, (int)ColorGridData.GridViewLocation.Sample);
            string oldNoodle = _gridData.GetValue(rowIndex - 1, (int)ColorGridData.GridViewLocation.Noodle);

            int.TryParse(oldNursery, out nursery);
            int.TryParse(oldSample, out sample);
            int.TryParse(oldNoodle, out noodle);

            sample++; noodle++;

            colorDataGridView.Rows[rowIndex].Cells[0].Value = nursery;
            colorDataGridView.Rows[rowIndex].Cells[1].Value = sample;
            colorDataGridView.Rows[rowIndex].Cells[2].Value = noodle;

            return new string[] {nursery.ToString(), sample.ToString(), noodle.ToString(),
            "","","",
            "","","",
            "","","",
            "","",""};
        }



        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences p = new Preferences(this.colorDataGridView.DefaultCellStyle, this.colorDataGridView.ColumnHeadersDefaultCellStyle);
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {

            _gridData.ColorGridAddRow(AddRow());


            /*foreach (DataGridViewCell d in colorDataGridView.Rows[colorDataGridView.RowCount - 1])
            {
                //
            }*/
        }
    }
}
