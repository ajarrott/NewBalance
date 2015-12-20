namespace NewBalance
{
    partial class MultipleSerialPopup
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
            this.label1 = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.balanceDropDownList = new System.Windows.Forms.ComboBox();
            this.colorDropDownList = new System.Windows.Forms.ComboBox();
            this.alertButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select correct COM port from lists below.";
            // 
            // balanceLabel
            // 
            this.balanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(16, 39);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(98, 13);
            this.balanceLabel.TabIndex = 1;
            this.balanceLabel.Text = "Balance COM Port:";
            // 
            // colorLabel
            // 
            this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(147, 39);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(113, 13);
            this.colorLabel.TabIndex = 2;
            this.colorLabel.Text = "Color Meter COM Port:";
            // 
            // balanceDropDownList
            // 
            this.balanceDropDownList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.balanceDropDownList.FormattingEnabled = true;
            this.balanceDropDownList.Location = new System.Drawing.Point(19, 55);
            this.balanceDropDownList.Name = "balanceDropDownList";
            this.balanceDropDownList.Size = new System.Drawing.Size(121, 21);
            this.balanceDropDownList.TabIndex = 3;
            // 
            // colorDropDownList
            // 
            this.colorDropDownList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorDropDownList.FormattingEnabled = true;
            this.colorDropDownList.Location = new System.Drawing.Point(150, 55);
            this.colorDropDownList.Name = "colorDropDownList";
            this.colorDropDownList.Size = new System.Drawing.Size(121, 21);
            this.colorDropDownList.TabIndex = 4;
            // 
            // alertButton
            // 
            this.alertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.alertButton.Location = new System.Drawing.Point(196, 83);
            this.alertButton.Name = "alertButton";
            this.alertButton.Size = new System.Drawing.Size(75, 23);
            this.alertButton.TabIndex = 5;
            this.alertButton.Text = "Submit";
            this.alertButton.UseVisualStyleBackColor = true;
            this.alertButton.Click += new System.EventHandler(this.alertButton_Click);
            // 
            // MultipleSerialPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 118);
            this.Controls.Add(this.alertButton);
            this.Controls.Add(this.colorDropDownList);
            this.Controls.Add(this.balanceDropDownList);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.label1);
            this.Name = "MultipleSerialPopup";
            this.Text = "NewBalance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ComboBox balanceDropDownList;
        private System.Windows.Forms.ComboBox colorDropDownList;
        private System.Windows.Forms.Button alertButton;
    }
}