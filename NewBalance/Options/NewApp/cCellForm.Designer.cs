namespace NewBalance
{
    partial class cCellForm
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
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.digitsLabel = new System.Windows.Forms.Label();
            this.digitsInput = new System.Windows.Forms.TextBox();
            this.precisionLabel = new System.Windows.Forms.Label();
            this.precisionInput = new System.Windows.Forms.TextBox();
            this.cellToMirrorLabel = new System.Windows.Forms.Label();
            this.addCell = new System.Windows.Forms.Button();
            this.cancelCell = new System.Windows.Forms.Button();
            this.equationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.variableCellListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(13, 13);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(55, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Cell Name";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(16, 29);
            this.nameInput.MaxLength = 16;
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(145, 20);
            this.nameInput.TabIndex = 1;
            // 
            // digitsLabel
            // 
            this.digitsLabel.AutoSize = true;
            this.digitsLabel.Location = new System.Drawing.Point(13, 62);
            this.digitsLabel.Name = "digitsLabel";
            this.digitsLabel.Size = new System.Drawing.Size(33, 13);
            this.digitsLabel.TabIndex = 2;
            this.digitsLabel.Text = "Digits";
            // 
            // digitsInput
            // 
            this.digitsInput.Location = new System.Drawing.Point(69, 59);
            this.digitsInput.MaxLength = 2;
            this.digitsInput.Name = "digitsInput";
            this.digitsInput.Size = new System.Drawing.Size(29, 20);
            this.digitsInput.TabIndex = 3;
            // 
            // precisionLabel
            // 
            this.precisionLabel.AutoSize = true;
            this.precisionLabel.Location = new System.Drawing.Point(13, 88);
            this.precisionLabel.Name = "precisionLabel";
            this.precisionLabel.Size = new System.Drawing.Size(50, 13);
            this.precisionLabel.TabIndex = 4;
            this.precisionLabel.Text = "Precision";
            // 
            // precisionInput
            // 
            this.precisionInput.Location = new System.Drawing.Point(69, 85);
            this.precisionInput.MaxLength = 2;
            this.precisionInput.Name = "precisionInput";
            this.precisionInput.Size = new System.Drawing.Size(29, 20);
            this.precisionInput.TabIndex = 5;
            // 
            // cellToMirrorLabel
            // 
            this.cellToMirrorLabel.AutoSize = true;
            this.cellToMirrorLabel.Location = new System.Drawing.Point(168, 13);
            this.cellToMirrorLabel.Name = "cellToMirrorLabel";
            this.cellToMirrorLabel.Size = new System.Drawing.Size(49, 13);
            this.cellToMirrorLabel.TabIndex = 8;
            this.cellToMirrorLabel.Text = "Equation";
            // 
            // addCell
            // 
            this.addCell.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addCell.Location = new System.Drawing.Point(530, 86);
            this.addCell.Name = "addCell";
            this.addCell.Size = new System.Drawing.Size(86, 23);
            this.addCell.TabIndex = 9;
            this.addCell.Text = "Add Cell";
            this.addCell.UseVisualStyleBackColor = true;
            // 
            // cancelCell
            // 
            this.cancelCell.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelCell.Location = new System.Drawing.Point(438, 86);
            this.cancelCell.Name = "cancelCell";
            this.cancelCell.Size = new System.Drawing.Size(86, 23);
            this.cancelCell.TabIndex = 10;
            this.cancelCell.Text = "Cancel";
            this.cancelCell.UseVisualStyleBackColor = true;
            // 
            // equationTextBox
            // 
            this.equationTextBox.Location = new System.Drawing.Point(171, 29);
            this.equationTextBox.Name = "equationTextBox";
            this.equationTextBox.Size = new System.Drawing.Size(261, 20);
            this.equationTextBox.TabIndex = 12;
            this.equationTextBox.Leave += new System.EventHandler(this.equationTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Other Cells";
            // 
            // variableCellListBox
            // 
            this.variableCellListBox.FormattingEnabled = true;
            this.variableCellListBox.Location = new System.Drawing.Point(438, 27);
            this.variableCellListBox.Name = "variableCellListBox";
            this.variableCellListBox.Size = new System.Drawing.Size(178, 56);
            this.variableCellListBox.TabIndex = 14;
            this.variableCellListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.variableCellListBox_DoubleClick);
            // 
            // cCellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 121);
            this.Controls.Add(this.variableCellListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equationTextBox);
            this.Controls.Add(this.cancelCell);
            this.Controls.Add(this.addCell);
            this.Controls.Add(this.cellToMirrorLabel);
            this.Controls.Add(this.precisionInput);
            this.Controls.Add(this.precisionLabel);
            this.Controls.Add(this.digitsInput);
            this.Controls.Add(this.digitsLabel);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Name = "cCellForm";
            this.Text = "New Calculation Cell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label digitsLabel;
        private System.Windows.Forms.TextBox digitsInput;
        private System.Windows.Forms.Label precisionLabel;
        private System.Windows.Forms.TextBox precisionInput;
        private System.Windows.Forms.Label cellToMirrorLabel;
        private System.Windows.Forms.Button addCell;
        private System.Windows.Forms.Button cancelCell;
        private System.Windows.Forms.TextBox equationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox variableCellListBox;
    }
}