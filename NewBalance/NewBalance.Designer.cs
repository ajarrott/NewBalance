using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NewBalance.Library.Classes;
using NewBalance.Properties;

namespace NewBalance
{
    partial class NewBalance
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialAndAppSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewAPPFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewBalanceDataGridView = new System.Windows.Forms.DataGridView();
            this.addRowButton = new System.Windows.Forms.Button();
            this.readBalanceButton = new System.Windows.Forms.Button();
            this.colorMeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewBalanceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.appsToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.colorMeterToolStripMenuItem});
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
            this.saveAsToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
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
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serialAndAppSettingsToolStripMenuItem,
            this.preferencesToolStripMenuItem1,
            this.createNewAPPFileToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.preferencesToolStripMenuItem.Text = "Options";
            // 
            // serialAndAppSettingsToolStripMenuItem
            // 
            this.serialAndAppSettingsToolStripMenuItem.Name = "serialAndAppSettingsToolStripMenuItem";
            this.serialAndAppSettingsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.serialAndAppSettingsToolStripMenuItem.Text = "Serial and App Settings";
            this.serialAndAppSettingsToolStripMenuItem.Click += new System.EventHandler(this.serialAndAppSettingsToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem1
            // 
            this.preferencesToolStripMenuItem1.Name = "preferencesToolStripMenuItem1";
            this.preferencesToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.preferencesToolStripMenuItem1.Text = "Preferences";
            this.preferencesToolStripMenuItem1.Click += new System.EventHandler(this.preferencesToolStripMenuItem1_Click);
            // 
            // createNewAPPFileToolStripMenuItem
            // 
            this.createNewAPPFileToolStripMenuItem.Name = "createNewAPPFileToolStripMenuItem";
            this.createNewAPPFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createNewAPPFileToolStripMenuItem.Text = "Create New .APP file";
            this.createNewAPPFileToolStripMenuItem.Click += new System.EventHandler(this.createNewAPPFileToolStripMenuItem_Click);
            // 
            // NewBalanceDataGridView
            // 
            this.NewBalanceDataGridView.AllowUserToAddRows = false;
            this.NewBalanceDataGridView.AllowUserToDeleteRows = false;
            this.NewBalanceDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewBalanceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NewBalanceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.NewBalanceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.NewBalanceDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.NewBalanceDataGridView.Location = new System.Drawing.Point(13, 28);
            this.NewBalanceDataGridView.Name = "NewBalanceDataGridView";
            this.NewBalanceDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.NewBalanceDataGridView.RowTemplate.Height = 38;
            this.NewBalanceDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NewBalanceDataGridView.Size = new System.Drawing.Size(524, 229);
            this.NewBalanceDataGridView.TabIndex = 1;
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
            this.readBalanceButton.Location = new System.Drawing.Point(450, 263);
            this.readBalanceButton.Name = "readBalanceButton";
            this.readBalanceButton.Size = new System.Drawing.Size(86, 23);
            this.readBalanceButton.TabIndex = 3;
            this.readBalanceButton.Text = "Read Balance";
            this.readBalanceButton.UseVisualStyleBackColor = true;
            this.readBalanceButton.Click += new System.EventHandler(this.readBalanceButton_Click);
            // 
            // colorMeterToolStripMenuItem
            // 
            this.colorMeterToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.colorMeterToolStripMenuItem.Name = "colorMeterToolStripMenuItem";
            this.colorMeterToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.colorMeterToolStripMenuItem.Text = "Color Meter";
            this.colorMeterToolStripMenuItem.Click += new System.EventHandler(this.colorMeterToolStripMenuItem_Click);
            // 
            // NewBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 298);
            this.Controls.Add(this.readBalanceButton);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.NewBalanceDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NewBalance";
            this.Text = "NewBalance";
            this.Load += new System.EventHandler(this.NewBalance_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewBalanceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.DataGridView NewBalanceDataGridView;
        private System.Windows.Forms.Button addRowButton;
        private Button readBalanceButton;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem serialAndAppSettingsToolStripMenuItem;
        private ToolStripMenuItem preferencesToolStripMenuItem1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem createNewAPPFileToolStripMenuItem;
        private ToolStripMenuItem colorMeterToolStripMenuItem;
    }
}

