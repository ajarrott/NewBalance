using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.UBalanceDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UBalanceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UBalanceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.UBalanceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UBalanceDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.addRowButton.Click += new System.EventHandler(this.button1_Click);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UBalance";
            this.Text = "UBalance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UBalanceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.UBalanceDataGridView.CellEndEdit += UBalanceDataGridView_CellEndEdit;
            this.UBalanceDataGridView.SelectionChanged += UBalanceDataGridView_SelectionChanged;
            this.UBalanceDataGridView.KeyDown +=UBalanceDataGridView_KeyDown;

        }

        private void UBalanceDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int column = UBalanceDataGridView.CurrentCell.ColumnIndex;
                int row = UBalanceDataGridView.CurrentCell.RowIndex;
                if (column == UBalanceDataGridView.ColumnCount - 1)
                {
                    if (UBalanceDataGridView.RowCount <= row + 1)
                    {
                        UBalanceDataGridView.Rows.Add();
                        ViewData.AddRow();
                    }
                    UBalanceDataGridView.CurrentCell = UBalanceDataGridView[0, row + 1];
                }
                else
                {
                    UBalanceDataGridView.CurrentCell = UBalanceDataGridView[column + 1, row];
                }
            }
        }

        private DataGridViewCell _cellEndEdit;

        void UBalanceDataGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            _cellEndEdit = UBalanceDataGridView[e.ColumnIndex, e.RowIndex];

            // need to update logic layer
        }

        // redirect transfer of cell on enter from down to right
        private void UBalanceDataGridView_SelectionChanged(object sender, System.EventArgs e)
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

                UBalanceDataGridView.CurrentCell = UBalanceDataGridView[newColumn, newRow];
            }
            _cellEndEdit = null;
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.DataGridView UBalanceDataGridView;
        private System.Windows.Forms.Button addRowButton;
        private Button readBalanceButton;

    }
}

