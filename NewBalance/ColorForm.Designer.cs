namespace NewBalance
{
    partial class ColorForm
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
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDataGridView = new System.Windows.Forms.DataGridView();
            this.Nursery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sample = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noodle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading1_L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading1_a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading1_b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading2_L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading2_a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading2_b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading3_L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading3_a = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading3_b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Averagea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Averageb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addRowButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1049, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // colorDataGridView
            // 
            this.colorDataGridView.AllowUserToAddRows = false;
            this.colorDataGridView.AllowUserToDeleteRows = false;
            this.colorDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.colorDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colorDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.colorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nursery,
            this.Sample,
            this.Noodle,
            this.Reading1_L,
            this.Reading1_a,
            this.Reading1_b,
            this.Reading2_L,
            this.Reading2_a,
            this.Reading2_b,
            this.Reading3_L,
            this.Reading3_a,
            this.Reading3_b,
            this.AverageL,
            this.Averagea,
            this.Averageb});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colorDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.colorDataGridView.Location = new System.Drawing.Point(13, 27);
            this.colorDataGridView.Name = "colorDataGridView";
            this.colorDataGridView.RowHeadersVisible = false;
            this.colorDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.colorDataGridView.RowTemplate.Height = 38;
            this.colorDataGridView.Size = new System.Drawing.Size(1024, 336);
            this.colorDataGridView.TabIndex = 1;
            // 
            // Nursery
            // 
            this.Nursery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Nursery.FillWeight = 50F;
            this.Nursery.HeaderText = "Nursery";
            this.Nursery.Name = "Nursery";
            this.Nursery.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nursery.Width = 135;
            // 
            // Sample
            // 
            this.Sample.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Sample.FillWeight = 50F;
            this.Sample.HeaderText = "Sample";
            this.Sample.Name = "Sample";
            this.Sample.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sample.Width = 130;
            // 
            // Noodle
            // 
            this.Noodle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Noodle.FillWeight = 50F;
            this.Noodle.HeaderText = "Noodle";
            this.Noodle.Name = "Noodle";
            this.Noodle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Noodle.Width = 125;
            // 
            // Reading1_L
            // 
            this.Reading1_L.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading1_L.FillWeight = 75F;
            this.Reading1_L.HeaderText = "1_L";
            this.Reading1_L.MinimumWidth = 75;
            this.Reading1_L.Name = "Reading1_L";
            this.Reading1_L.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading1_L.Width = 84;
            // 
            // Reading1_a
            // 
            this.Reading1_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading1_a.HeaderText = "1_a";
            this.Reading1_a.Name = "Reading1_a";
            this.Reading1_a.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading1_a.Width = 84;
            // 
            // Reading1_b
            // 
            this.Reading1_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading1_b.HeaderText = "1_b";
            this.Reading1_b.Name = "Reading1_b";
            this.Reading1_b.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading1_b.Width = 84;
            // 
            // Reading2_L
            // 
            this.Reading2_L.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading2_L.HeaderText = "2_L";
            this.Reading2_L.Name = "Reading2_L";
            this.Reading2_L.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading2_L.Width = 84;
            // 
            // Reading2_a
            // 
            this.Reading2_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading2_a.HeaderText = "2_a";
            this.Reading2_a.Name = "Reading2_a";
            this.Reading2_a.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading2_a.Width = 84;
            // 
            // Reading2_b
            // 
            this.Reading2_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading2_b.HeaderText = "2_b";
            this.Reading2_b.Name = "Reading2_b";
            this.Reading2_b.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading2_b.Width = 84;
            // 
            // Reading3_L
            // 
            this.Reading3_L.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading3_L.HeaderText = "3_L";
            this.Reading3_L.Name = "Reading3_L";
            this.Reading3_L.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading3_L.Width = 84;
            // 
            // Reading3_a
            // 
            this.Reading3_a.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading3_a.HeaderText = "3_a";
            this.Reading3_a.Name = "Reading3_a";
            this.Reading3_a.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading3_a.Width = 84;
            // 
            // Reading3_b
            // 
            this.Reading3_b.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Reading3_b.HeaderText = "3_b";
            this.Reading3_b.Name = "Reading3_b";
            this.Reading3_b.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Reading3_b.Width = 84;
            // 
            // AverageL
            // 
            this.AverageL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AverageL.HeaderText = "Avg L";
            this.AverageL.Name = "AverageL";
            this.AverageL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AverageL.Width = 108;
            // 
            // Averagea
            // 
            this.Averagea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Averagea.HeaderText = "Avg a";
            this.Averagea.Name = "Averagea";
            this.Averagea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Averagea.Width = 108;
            // 
            // Averageb
            // 
            this.Averageb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Averageb.HeaderText = "Avg b";
            this.Averageb.Name = "Averageb";
            this.Averageb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Averageb.Width = 108;
            // 
            // addRowButton
            // 
            this.addRowButton.Location = new System.Drawing.Point(936, 370);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(100, 23);
            this.addRowButton.TabIndex = 2;
            this.addRowButton.Text = "Add Row";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // ColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 405);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.colorDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ColorForm";
            this.Text = "ColorMeter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView colorDataGridView;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nursery;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sample;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noodle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading1_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading1_a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading1_b;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading2_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading2_a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading2_b;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading3_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading3_a;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading3_b;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Averagea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Averageb;
    }
}