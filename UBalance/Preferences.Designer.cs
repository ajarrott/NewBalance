using System;
using System.Windows.Forms;

namespace UBalance
{
    partial class Preferences
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
            this.defaultPathTextBox = new System.Windows.Forms.TextBox();
            this.selectNewFolder = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Save = new System.Windows.Forms.Button();
            this.comLabel = new System.Windows.Forms.Label();
            this.comPortList = new System.Windows.Forms.ComboBox();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.baudRateList = new System.Windows.Forms.ComboBox();
            this.stopBitsLabel = new System.Windows.Forms.Label();
            this.parityLabel = new System.Windows.Forms.Label();
            this.dataBitsLabel = new System.Windows.Forms.Label();
            this.parityList = new System.Windows.Forms.ComboBox();
            this.stopBitsList = new System.Windows.Forms.ComboBox();
            this.dataBitsList = new System.Windows.Forms.ComboBox();
            this.sicsCommandLabel = new System.Windows.Forms.Label();
            this.sicsTextBox = new System.Windows.Forms.TextBox();
            this.defaultAppLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // defaultPathTextBox
            // 
            this.defaultPathTextBox.Location = new System.Drawing.Point(12, 25);
            this.defaultPathTextBox.Name = "defaultPathTextBox";
            this.defaultPathTextBox.Size = new System.Drawing.Size(273, 20);
            this.defaultPathTextBox.TabIndex = 0;
            // 
            // selectNewFolder
            // 
            this.selectNewFolder.Location = new System.Drawing.Point(12, 51);
            this.selectNewFolder.Name = "selectNewFolder";
            this.selectNewFolder.Size = new System.Drawing.Size(198, 23);
            this.selectNewFolder.TabIndex = 1;
            this.selectNewFolder.Text = "Select New Folder...";
            this.selectNewFolder.UseVisualStyleBackColor = true;
            this.selectNewFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(179, 209);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save and Close";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // comLabel
            // 
            this.comLabel.Location = new System.Drawing.Point(9, 87);
            this.comLabel.Name = "comLabel";
            this.comLabel.Size = new System.Drawing.Size(35, 13);
            this.comLabel.TabIndex = 0;
            this.comLabel.Text = "COM Port";
            // 
            // comPortList
            // 
            this.comPortList.FormattingEnabled = true;
            this.comPortList.Location = new System.Drawing.Point(12, 103);
            this.comPortList.Name = "comPortList";
            this.comPortList.Size = new System.Drawing.Size(132, 21);
            this.comPortList.TabIndex = 4;
            this.comPortList.SelectedIndexChanged += new System.EventHandler(this.ComPortList_SelectedIndexChanged);
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(9, 127);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(58, 13);
            this.baudRateLabel.TabIndex = 5;
            this.baudRateLabel.Text = "Baud Rate";
            // 
            // baudRateList
            // 
            this.baudRateList.FormattingEnabled = true;
            this.baudRateList.Location = new System.Drawing.Point(12, 143);
            this.baudRateList.Name = "baudRateList";
            this.baudRateList.Size = new System.Drawing.Size(132, 21);
            this.baudRateList.TabIndex = 6;
            this.baudRateList.SelectedIndexChanged += new System.EventHandler(this.baudRateList_SelectedIndexChanged);
            // 
            // stopBitsLabel
            // 
            this.stopBitsLabel.AutoSize = true;
            this.stopBitsLabel.Location = new System.Drawing.Point(161, 87);
            this.stopBitsLabel.Name = "stopBitsLabel";
            this.stopBitsLabel.Size = new System.Drawing.Size(49, 13);
            this.stopBitsLabel.TabIndex = 7;
            this.stopBitsLabel.Text = "Stop Bits";
            // 
            // parityLabel
            // 
            this.parityLabel.AutoSize = true;
            this.parityLabel.Location = new System.Drawing.Point(9, 167);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(33, 13);
            this.parityLabel.TabIndex = 8;
            this.parityLabel.Text = "Parity";
            // 
            // dataBitsLabel
            // 
            this.dataBitsLabel.AutoSize = true;
            this.dataBitsLabel.Location = new System.Drawing.Point(161, 127);
            this.dataBitsLabel.Name = "dataBitsLabel";
            this.dataBitsLabel.Size = new System.Drawing.Size(50, 13);
            this.dataBitsLabel.TabIndex = 9;
            this.dataBitsLabel.Text = "Data Bits";
            // 
            // parityList
            // 
            this.parityList.FormattingEnabled = true;
            this.parityList.Location = new System.Drawing.Point(12, 183);
            this.parityList.Name = "parityList";
            this.parityList.Size = new System.Drawing.Size(132, 21);
            this.parityList.TabIndex = 10;
            this.parityList.SelectedIndexChanged += new System.EventHandler(this.parityList_SelectedIndexChanged);
            // 
            // stopBitsList
            // 
            this.stopBitsList.FormattingEnabled = true;
            this.stopBitsList.Location = new System.Drawing.Point(164, 103);
            this.stopBitsList.Name = "stopBitsList";
            this.stopBitsList.Size = new System.Drawing.Size(121, 21);
            this.stopBitsList.TabIndex = 11;
            this.stopBitsList.SelectedIndexChanged += new System.EventHandler(this.stopBitsList_SelectedIndexChanged);
            // 
            // dataBitsList
            // 
            this.dataBitsList.FormattingEnabled = true;
            this.dataBitsList.Location = new System.Drawing.Point(164, 143);
            this.dataBitsList.Name = "dataBitsList";
            this.dataBitsList.Size = new System.Drawing.Size(121, 21);
            this.dataBitsList.TabIndex = 12;
            this.dataBitsList.SelectedIndexChanged += new System.EventHandler(this.dataBitsList_SelectedIndexChanged);
            // 
            // sicsCommandLabel
            // 
            this.sicsCommandLabel.AutoSize = true;
            this.sicsCommandLabel.Location = new System.Drawing.Point(161, 167);
            this.sicsCommandLabel.Name = "sicsCommandLabel";
            this.sicsCommandLabel.Size = new System.Drawing.Size(123, 13);
            this.sicsCommandLabel.TabIndex = 13;
            this.sicsCommandLabel.Text = "Balance SICS Command";
            // 
            // sicsTextBox
            // 
            this.sicsTextBox.Location = new System.Drawing.Point(164, 183);
            this.sicsTextBox.Name = "sicsTextBox";
            this.sicsTextBox.Size = new System.Drawing.Size(121, 20);
            this.sicsTextBox.TabIndex = 14;
            this.sicsTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // defaultAppLabel
            // 
            this.defaultAppLabel.AutoSize = true;
            this.defaultAppLabel.Location = new System.Drawing.Point(12, 9);
            this.defaultAppLabel.Name = "defaultAppLabel";
            this.defaultAppLabel.Size = new System.Drawing.Size(100, 13);
            this.defaultAppLabel.TabIndex = 15;
            this.defaultAppLabel.Text = "Default .APP Folder";
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 240);
            this.Controls.Add(this.defaultAppLabel);
            this.Controls.Add(this.sicsTextBox);
            this.Controls.Add(this.sicsCommandLabel);
            this.Controls.Add(this.dataBitsList);
            this.Controls.Add(this.stopBitsList);
            this.Controls.Add(this.parityList);
            this.Controls.Add(this.dataBitsLabel);
            this.Controls.Add(this.parityLabel);
            this.Controls.Add(this.stopBitsLabel);
            this.Controls.Add(this.baudRateList);
            this.Controls.Add(this.baudRateLabel);
            this.Controls.Add(this.comPortList);
            this.Controls.Add(this.comLabel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.selectNewFolder);
            this.Controls.Add(this.defaultPathTextBox);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox defaultPathTextBox;
        private System.Windows.Forms.Button selectNewFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal Button Save;
        private Label comLabel;
        private ComboBox comPortList;
        private Label baudRateLabel;
        private ComboBox baudRateList;
        private Label stopBitsLabel;
        private Label parityLabel;
        private Label dataBitsLabel;
        private ComboBox parityList;
        private ComboBox stopBitsList;
        private ComboBox dataBitsList;
        private Label sicsCommandLabel;
        private TextBox sicsTextBox;
        private Label defaultAppLabel;
    }
}