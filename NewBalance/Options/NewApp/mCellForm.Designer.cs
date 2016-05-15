namespace NewBalance
{
    partial class mCellForm
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
            this.cellToMirrorComboBox = new System.Windows.Forms.ComboBox();
            this.cellToMirrorLabel = new System.Windows.Forms.Label();
            this.addCell = new System.Windows.Forms.Button();
            this.cancelCell = new System.Windows.Forms.Button();
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
            // cellToMirrorComboBox
            // 
            this.cellToMirrorComboBox.FormattingEnabled = true;
            this.cellToMirrorComboBox.Location = new System.Drawing.Point(171, 28);
            this.cellToMirrorComboBox.Name = "cellToMirrorComboBox";
            this.cellToMirrorComboBox.Size = new System.Drawing.Size(121, 21);
            this.cellToMirrorComboBox.TabIndex = 7;
            // 
            // cellToMirrorLabel
            // 
            this.cellToMirrorLabel.AutoSize = true;
            this.cellToMirrorLabel.Location = new System.Drawing.Point(168, 13);
            this.cellToMirrorLabel.Name = "cellToMirrorLabel";
            this.cellToMirrorLabel.Size = new System.Drawing.Size(69, 13);
            this.cellToMirrorLabel.TabIndex = 8;
            this.cellToMirrorLabel.Text = "Cell To Mirror";
            // 
            // addCell
            // 
            this.addCell.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addCell.Location = new System.Drawing.Point(206, 86);
            this.addCell.Name = "addCell";
            this.addCell.Size = new System.Drawing.Size(86, 23);
            this.addCell.TabIndex = 9;
            this.addCell.Text = "Add Cell";
            this.addCell.UseVisualStyleBackColor = true;
            // 
            // cancelCell
            // 
            this.cancelCell.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelCell.Location = new System.Drawing.Point(114, 86);
            this.cancelCell.Name = "cancelCell";
            this.cancelCell.Size = new System.Drawing.Size(86, 23);
            this.cancelCell.TabIndex = 10;
            this.cancelCell.Text = "Cancel";
            this.cancelCell.UseVisualStyleBackColor = true;
            // 
            // mCellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 121);
            this.Controls.Add(this.cancelCell);
            this.Controls.Add(this.addCell);
            this.Controls.Add(this.cellToMirrorLabel);
            this.Controls.Add(this.cellToMirrorComboBox);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Name = "mCellForm";
            this.Text = "New Mirror Cell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.ComboBox cellToMirrorComboBox;
        private System.Windows.Forms.Label cellToMirrorLabel;
        private System.Windows.Forms.Button addCell;
        private System.Windows.Forms.Button cancelCell;
    }
}