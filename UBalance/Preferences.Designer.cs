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
            this.DefaultPath = new System.Windows.Forms.TextBox();
            this.SelectNewFolder = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ComPortList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baudRateList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.parityList = new System.Windows.Forms.ComboBox();
            this.stopBitsList = new System.Windows.Forms.ComboBox();
            this.dataBitsList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DefaultPath
            // 
            this.DefaultPath.Location = new System.Drawing.Point(12, 12);
            this.DefaultPath.Name = "DefaultPath";
            this.DefaultPath.Size = new System.Drawing.Size(385, 20);
            this.DefaultPath.TabIndex = 0;
            // 
            // SelectNewFolder
            // 
            this.SelectNewFolder.Location = new System.Drawing.Point(12, 38);
            this.SelectNewFolder.Name = "SelectNewFolder";
            this.SelectNewFolder.Size = new System.Drawing.Size(198, 23);
            this.SelectNewFolder.TabIndex = 1;
            this.SelectNewFolder.Text = "Select New Folder...";
            this.SelectNewFolder.UseVisualStyleBackColor = true;
            this.SelectNewFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(288, 172);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(109, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "Save and Close";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // ComPortList
            // 
            this.ComPortList.FormattingEnabled = true;
            this.ComPortList.Location = new System.Drawing.Point(15, 92);
            this.ComPortList.Name = "ComPortList";
            this.ComPortList.Size = new System.Drawing.Size(132, 21);
            this.ComPortList.TabIndex = 4;
            this.ComPortList.SelectedIndexChanged += new System.EventHandler(this.ComPortList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Baud Rate";
            // 
            // baudRateList
            // 
            this.baudRateList.FormattingEnabled = true;
            this.baudRateList.Location = new System.Drawing.Point(15, 133);
            this.baudRateList.Name = "baudRateList";
            this.baudRateList.Size = new System.Drawing.Size(132, 21);
            this.baudRateList.TabIndex = 6;
            this.baudRateList.SelectedIndexChanged += new System.EventHandler(this.baudRateList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Stop Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Bits";
            // 
            // parityList
            // 
            this.parityList.FormattingEnabled = true;
            this.parityList.Location = new System.Drawing.Point(15, 174);
            this.parityList.Name = "parityList";
            this.parityList.Size = new System.Drawing.Size(132, 21);
            this.parityList.TabIndex = 10;
            this.parityList.SelectedIndexChanged += new System.EventHandler(this.parityList_SelectedIndexChanged);
            // 
            // stopBitsList
            // 
            this.stopBitsList.FormattingEnabled = true;
            this.stopBitsList.Location = new System.Drawing.Point(164, 92);
            this.stopBitsList.Name = "stopBitsList";
            this.stopBitsList.Size = new System.Drawing.Size(121, 21);
            this.stopBitsList.TabIndex = 11;
            this.stopBitsList.SelectedIndexChanged += new System.EventHandler(this.stopBitsList_SelectedIndexChanged);
            // 
            // dataBitsList
            // 
            this.dataBitsList.FormattingEnabled = true;
            this.dataBitsList.Location = new System.Drawing.Point(164, 133);
            this.dataBitsList.Name = "dataBitsList";
            this.dataBitsList.Size = new System.Drawing.Size(121, 21);
            this.dataBitsList.TabIndex = 12;
            this.dataBitsList.SelectedIndexChanged += new System.EventHandler(this.dataBitsList_SelectedIndexChanged);
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 203);
            this.Controls.Add(this.dataBitsList);
            this.Controls.Add(this.stopBitsList);
            this.Controls.Add(this.parityList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baudRateList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComPortList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SelectNewFolder);
            this.Controls.Add(this.DefaultPath);
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DefaultPath;
        private System.Windows.Forms.Button SelectNewFolder;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        internal Button Save;
        private Label label1;
        private ComboBox ComPortList;
        private Label label2;
        private ComboBox baudRateList;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox parityList;
        private ComboBox stopBitsList;
        private ComboBox dataBitsList;
    }
}