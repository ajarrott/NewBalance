using System;
using System.Windows.Forms;
using UBalance.Library.Classes;

namespace UBalance
{
    partial class UBalance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UBalanceDataGridView = new System.Windows.Forms.DataGridView();
            this.addRowButton = new System.Windows.Forms.Button();
            this.readBalanceButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UBalanceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.appsToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // appsToolStripMenuItem
            // 
            this.appsToolStripMenuItem.Name = "appsToolStripMenuItem";
            this.appsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.appsToolStripMenuItem.Text = "Apps";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // UBalanceDataGridView
            // 
            this.UBalanceDataGridView.AllowUserToAddRows = false;
            this.UBalanceDataGridView.AllowUserToDeleteRows = false;
            this.UBalanceDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UBalanceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UBalanceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UBalanceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UBalanceDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.UBalanceDataGridView.Location = new System.Drawing.Point(13, 28);
            this.UBalanceDataGridView.Name = "UBalanceDataGridView";
            this.UBalanceDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.UBalanceDataGridView.RowTemplate.Height = 38;
            this.UBalanceDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UBalanceDataGridView.Size = new System.Drawing.Size(524, 229);
            this.UBalanceDataGridView.TabIndex = 1;
            // 
            // addRowButton
            // 
            this.addRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addRowButton.Location = new System.Drawing.Point(369, 263);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(75, 23);
            this.addRowButton.TabIndex = 2;
            this.addRowButton.Text = "Add Row...";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // readBalanceButton
            // 
            this.readBalanceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.readBalanceButton.Location = new System.Drawing.Point(450, 262);
            this.readBalanceButton.Name = "readBalanceButton";
            this.readBalanceButton.Size = new System.Drawing.Size(86, 23);
            this.readBalanceButton.TabIndex = 3;
            this.readBalanceButton.Text = "Read Balance";
            this.readBalanceButton.UseVisualStyleBackColor = true;
            this.readBalanceButton.Click += new System.EventHandler(this.readBalanceButton_Click);
            // 
            // UBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 298);
            this.Controls.Add(this.readBalanceButton);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.UBalanceDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UBalance";
            this.Text = "UBalance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UBalanceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void UBalanceDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            // need to get next column value from data view then skip columns that are not KColumns or WColumns
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int column = UBalanceDataGridView.CurrentCell.ColumnIndex;
                int row = UBalanceDataGridView.CurrentCell.RowIndex;
                if (column == UBalanceDataGridView.ColumnCount - 1)
                {
                    if (UBalanceDataGridView.RowCount <= row + 1)
                    {
                        AddRowToDataAndView();
                    }
                    UBalanceDataGridView.CurrentCell = UBalanceDataGridView[0, row + 1];
                }
                else
                {
                    UBalanceDataGridView.CurrentCell = UBalanceDataGridView[column + 1, row];
                }
            }
        }

        void AddRowToDataAndView()
        {
            int rowNumber = UBalanceDataGridView.RowCount; // will be correct row index when we add a row

            UBalanceDataGridView.Rows.Add();
            ViewData.AddRow();

            for (int i = 0; i < UBalanceDataGridView.Rows[0].Cells.Count; i++)
            {
                ViewData.GetCell(rowNumber, i).CellValueChanged += UBalance_CellValueChanged;
                ViewData.GetCell(rowNumber, i).NotifyDependents += UBalance_NotifyDependents;
                
                UBalanceDataGridView.Columns[i].Resizable = DataGridViewTriState.True;
            }
        }

        void UBalance_NotifyDependents(object sender, EventArgs e)
        {
            //Update dependents value
            Cell c = sender as Cell;
            if (c == null) return;

            string valueToSend;

            if (c is KCell)
            {
                KCell kc = c as KCell;
                if (kc.KValue != String.Empty)
                {
                    valueToSend = kc.KValue;
                }
                else
                {
                    valueToSend = kc.Value.ToString();
                }
            }
            else if (c is MCell)
            {
                MCell mc = c as MCell;
                valueToSend = mc.MValue;
            }
            else
            {
                if (c.Value == null) valueToSend = String.Empty;
                else valueToSend = c.Value.ToString();
            }

            // Cell's will only be dependent within the current row
            for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
            {
                MCell mc = ViewData.GetCell(c.RowIndex, i) as MCell;
                if (mc == null) continue;

                if (mc.IsDependent(c))
                {
                    mc.MValue = valueToSend;
                }
                
            }
        }

        void UBalance_CellValueChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Cell c = sender as Cell;

            if (e.PropertyName == "String")
            {
                if (sender is KCell)
                {
                    KCell k = sender as KCell;

                    if (k.KValue != String.Empty)
                    {
                        UBalanceDataGridView.Rows[k.RowIndex].Cells[k.ColumnIndex].Value = k.KValue;
                    }
                    else
                    {
                        UBalanceDataGridView.Rows[k.RowIndex].Cells[k.ColumnIndex].Value = k.Value.ToString();
                    }
                }
                else if (sender is MCell)
                {
                    MCell m = sender as MCell;
                    UBalanceDataGridView.Rows[m.RowIndex].Cells[m.ColumnIndex].Value = m.MValue;
                }
                
            }
            else
            {
                if (c.Value == null)
                {
                    if (c is KCell)
                    {
                        KCell kc = c as KCell;

                        if (kc.KValue != String.Empty)
                            UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = kc.KValue;
                        else
                            UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = null;
                    }
                    else
                    {
                        UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = null;
                    }
                }
                else
                {
                    UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = c.Value.ToString();
                }

            }
        }

        private DataGridViewCell _cellEndEdit;

        void UBalanceDataGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            _cellEndEdit = UBalanceDataGridView[e.ColumnIndex, e.RowIndex];
            // arbitrary number
            double d = -1.00015;
            bool changed;
            string s = String.Empty;

            // need to update logic layer

            if (_cellEndEdit.Value == oldCellValue) return;
            else changed = true;

            if (_cellEndEdit.Value != null && double.TryParse(_cellEndEdit.Value.ToString(), out d) == false)
            {
                s = _cellEndEdit.Value.ToString();
            }

            switch(ViewData.GetCellType(e.RowIndex, e.ColumnIndex))
            {
                // don't update if value is not valid
                case CellType.C:
                    CCell c = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as CCell;

                    if (c == null) return;

                    if (changed == true && d != -1.00015) c.OverrideValue(d);
                    else c.Value = null;
                    
                    break;
                case CellType.K:
                    KCell k = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as KCell;

                    if (k == null) return;

                    if (s.Length > 0)
                    {
                        k.KValue = s;
                    }
                    else if (d != 1.0015 && changed == true)
                    {
                        k.KValue = d.ToString();
                    }

                    break;
                case CellType.M:
                    MCell m = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as MCell;

                    if (m == null) return;

                    if (changed == true && d != -1.00015) m.OverrideValue(d);
                    else m.Value = null;
                    
                    break;
                case CellType.W:
                    WCell w = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as WCell;

                    if (w == null) return;

                    if (changed == true && d != 1.0015) w.Value = d;
                    else w.Value = null;

                    break;
            }
            NextCell();
        }

        private void NextCell()
        {
            int maxCols = UBalanceDataGridView.ColumnCount;
            int newColumn, newRow;
            // don't change on mouse press
            if (MouseButtons != 0) return;


            if (_cellEndEdit != null && UBalanceDataGridView.CurrentCell != null)
            {
                // Current cell will be diagramed as follows
                // X -> X - X
                // | -> 
                // X ->

                // need to select next cell based on logic implemented lower
                // 

                if (_cellEndEdit.ColumnIndex < maxCols - 1)
                {
                    newColumn = _cellEndEdit.ColumnIndex + 1;
                    newRow = _cellEndEdit.RowIndex;
                }
                else
                {
                    newColumn = 0;
                    newRow = _cellEndEdit.RowIndex + 1;
                }

                if ( newRow == UBalanceDataGridView.RowCount )
                    AddRowToDataAndView();

                UBalanceDataGridView.CurrentCell = UBalanceDataGridView[newColumn, newRow];
            }
            _cellEndEdit = null;
        }

        // redirect transfer of cell on enter from down to right
        private void UBalanceDataGridView_SelectionChanged(object sender, System.EventArgs e)
        {
            NextCell();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.DataGridView UBalanceDataGridView;
        private System.Windows.Forms.Button addRowButton;
        private Button readBalanceButton;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;

    }
}

