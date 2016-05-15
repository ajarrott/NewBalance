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
    public partial class CreateAppForm : Form
    {
        private int rowCount = 0;
        private List<string> _appItems;

        public CreateAppForm()
        {
            InitializeComponent();

            _appItems = new List<string>();

            
        }

        /*private void KCellControl1_kCellClick(kCellControl sender, System.EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(sender.name);
            sb.Append(' ', 16 - sender.name.Length + 1); // add spaces up to 17 (for correct spacing in file);

            sb.Append(sender.digits);
            sb.Append(' ', 2 - sender.digits.Length + 1);

            sb.Append(sender.precision);
            sb.Append(' ', 2 - sender.digits.Length + 1);

            sb.Append(sender.connection);
        }*/

        /// <summary>
        /// Enabled/Disable buttons that require multiple cells when there are items/no items in the list respectively
        /// </summary>
        private void CheckItemsInAppListView()
        {
            if(appListView.Items.Count > 0)
            {
                addCCell.Enabled = addMCell.Enabled = addMultiCell.Enabled = true;
            }
            else
            {
                addCCell.Enabled = addMCell.Enabled = addMultiCell.Enabled = false;
            }
        }

        private List<string> GetNamesOfCells()
        {
            List<string> namesOfCells = new List<string>();

            for (int i = 0; i < rowCount; i++)
            {
                ListViewItem l = appListView.Items[i];

                namesOfCells.Add(l.SubItems[1].Text); // Index 1 is name of the cell
            }

            return namesOfCells;
        }

        private void addKCell_Click(object sender, EventArgs e)
        {
            kCellForm k = new kCellForm();
            if(k.ShowDialog() == DialogResult.OK)
            {
                rowCount++;
                appListView.Items.Add(new ListViewItem(new string[] { rowCount.ToString(), k.name, "K", k.digits, k.precision, k.connection }));
            }

            CheckItemsInAppListView();
        }

        private void addWCell_Click(object sender, EventArgs e)
        {
            wCellForm w = new wCellForm(GetNamesOfCells());
            if(w.ShowDialog() == DialogResult.OK)
            {
                rowCount++;
                appListView.Items.Add(new ListViewItem(new string[] { rowCount.ToString(), w.name, "W", w.digits, w.precision, w.connection }));
            }
            CheckItemsInAppListView();
        }


        private void addMCell_Click(object sender, EventArgs e)
        {
            mCellForm m = new mCellForm(GetNamesOfCells());
            if(m.ShowDialog() == DialogResult.OK)
            {
                rowCount++;
                appListView.Items.Add(new ListViewItem(new string[] { rowCount.ToString, m.name, "M", m.digits, m.precision, m.connection }));
            }
        }

        private void addCCell_Click(object sender, EventArgs e)
        {
            cCellForm c = new cCellForm(GetNamesOfCells());
            
            if(c.ShowDialog() == DialogResult.OK)
            {
                rowCount++;
                appListView.Items.Add(new ListViewItem(new string[] { rowCount.ToString(), c.name, "C", c.digits, c.precision, c.connection }));
            }
        }


        private void addMultiCell_Click(object sender, EventArgs e)
        {
            
        }

        private void editCellButton_Click(object sender, EventArgs e)
        {
            string type, name, digits, precision, connection;
            int rowIndex;
            ListViewItem row;

            try
            {
                rowIndex = appListView.SelectedIndices[0];
                row = appListView.Items[rowIndex];

                //2 is index of TYPE
                name = row.SubItems[1].Text;
                type = row.SubItems[2].Text;
                digits = row.SubItems[3].Text;
                precision = row.SubItems[4].Text;
                connection = row.SubItems[5].Text;
            }
            catch (Exception)
            {
                MessageBox.Show("No row selected. Please select a row the list of APP items.", "Error");
                return;
            }


            switch (type)
            {
                case "K":
                    kCellForm k = new kCellForm(connection, name, precision, digits);

                    if(k.ShowDialog() == DialogResult.OK)
                    {
                        name = k.name;
                        digits = k.digits;
                        precision = k.precision;
                        connection = k.connection;
                    }

                    break;

                case "W":
                    wCellForm w = new wCellForm(connection, name, precision, digits, GetNamesOfCells());

                    if (w.ShowDialog() == DialogResult.OK)
                    {
                        name = w.name;
                        digits = w.digits;
                        precision = w.precision;
                        connection = w.connection;
                    }

                    break;

                case "C":
                    cCellForm c = new cCellForm(connection, name, precision, digits, GetNamesOfCells());

                    if(c.ShowDialog() == DialogResult.OK)
                    {
                        name = c.name;
                        digits = c.digits;
                        precision = c.precision;
                        connection = c.connection;
                    }
                    break;

                case "M":
                    mCellForm m = new mCellForm(connection, name, precision, digits, GetNamesOfCells());

                    if(m.ShowDialog() == DialogResult.OK)
                    {
                        name = m.name;
                        digits = m.digits;
                        precision = m.precision;
                        connection = m.connection;
                    }
                    break;

                case "Multi":
                    break;
            }

            row.SubItems[1].Text = name;
            row.SubItems[3].Text = digits; 
            row.SubItems[4].Text = precision;
            row.SubItems[5].Text = connection;
        }

        private void deleteListItem_Click(object sender, EventArgs e)
        {


            CheckItemsInAppListView();
        }
    }
}
