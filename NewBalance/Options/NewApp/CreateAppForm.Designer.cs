namespace NewBalance
{
    partial class CreateAppForm
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
            this.appListView = new System.Windows.Forms.ListView();
            this.colNumberHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameColHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColhead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.digitsColHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.precisionColHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conInfoColHead = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewLabel = new System.Windows.Forms.Label();
            this.addKCell = new System.Windows.Forms.Button();
            this.addMCell = new System.Windows.Forms.Button();
            this.addWCell = new System.Windows.Forms.Button();
            this.addCCell = new System.Windows.Forms.Button();
            this.addMultiCell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deleteListItem = new System.Windows.Forms.Button();
            this.createAPPFile = new System.Windows.Forms.Button();
            this.editCellButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // appListView
            // 
            this.appListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumberHeader,
            this.nameColHead,
            this.typeColhead,
            this.digitsColHead,
            this.precisionColHead,
            this.conInfoColHead});
            this.appListView.FullRowSelect = true;
            this.appListView.Location = new System.Drawing.Point(12, 25);
            this.appListView.Name = "appListView";
            this.appListView.Size = new System.Drawing.Size(546, 244);
            this.appListView.TabIndex = 1;
            this.appListView.UseCompatibleStateImageBehavior = false;
            this.appListView.View = System.Windows.Forms.View.Details;
            // 
            // colNumberHeader
            // 
            this.colNumberHeader.Text = "#";
            this.colNumberHeader.Width = 30;
            // 
            // nameColHead
            // 
            this.nameColHead.Text = "Name";
            // 
            // typeColhead
            // 
            this.typeColhead.Text = "Type";
            // 
            // digitsColHead
            // 
            this.digitsColHead.Text = "Digits";
            // 
            // precisionColHead
            // 
            this.precisionColHead.Text = "Precision";
            // 
            // conInfoColHead
            // 
            this.conInfoColHead.Text = "Connection Info";
            this.conInfoColHead.Width = 270;
            // 
            // listViewLabel
            // 
            this.listViewLabel.AutoSize = true;
            this.listViewLabel.Location = new System.Drawing.Point(12, 9);
            this.listViewLabel.Name = "listViewLabel";
            this.listViewLabel.Size = new System.Drawing.Size(78, 13);
            this.listViewLabel.TabIndex = 2;
            this.listViewLabel.Text = ".APP File Items";
            // 
            // addKCell
            // 
            this.addKCell.Location = new System.Drawing.Point(15, 293);
            this.addKCell.Name = "addKCell";
            this.addKCell.Size = new System.Drawing.Size(122, 23);
            this.addKCell.TabIndex = 3;
            this.addKCell.Text = "New Keyboard Cell";
            this.addKCell.UseVisualStyleBackColor = true;
            this.addKCell.Click += new System.EventHandler(this.addKCell_Click);
            // 
            // addMCell
            // 
            this.addMCell.Enabled = false;
            this.addMCell.Location = new System.Drawing.Point(271, 293);
            this.addMCell.Name = "addMCell";
            this.addMCell.Size = new System.Drawing.Size(122, 23);
            this.addMCell.TabIndex = 4;
            this.addMCell.Text = "New Mirrored Cell";
            this.addMCell.UseVisualStyleBackColor = true;
            this.addMCell.Click += new System.EventHandler(this.addMCell_Click);
            // 
            // addWCell
            // 
            this.addWCell.Location = new System.Drawing.Point(143, 293);
            this.addWCell.Name = "addWCell";
            this.addWCell.Size = new System.Drawing.Size(122, 23);
            this.addWCell.TabIndex = 5;
            this.addWCell.Text = "New Weight Cell";
            this.addWCell.UseVisualStyleBackColor = true;
            this.addWCell.Click += new System.EventHandler(this.addWCell_Click);
            // 
            // addCCell
            // 
            this.addCCell.Enabled = false;
            this.addCCell.Location = new System.Drawing.Point(15, 347);
            this.addCCell.Name = "addCCell";
            this.addCCell.Size = new System.Drawing.Size(122, 23);
            this.addCCell.TabIndex = 6;
            this.addCCell.Text = "New Calculation Cell";
            this.addCCell.UseVisualStyleBackColor = true;
            this.addCCell.Click += new System.EventHandler(this.addCCell_Click);
            // 
            // addMultiCell
            // 
            this.addMultiCell.Enabled = false;
            this.addMultiCell.Location = new System.Drawing.Point(143, 347);
            this.addMultiCell.Name = "addMultiCell";
            this.addMultiCell.Size = new System.Drawing.Size(122, 23);
            this.addMultiCell.TabIndex = 7;
            this.addMultiCell.Text = "New Multiple Cell";
            this.addMultiCell.UseVisualStyleBackColor = true;
            this.addMultiCell.Click += new System.EventHandler(this.addMultiCell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Normal Cells";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Calculation Cells";
            // 
            // deleteListItem
            // 
            this.deleteListItem.Location = new System.Drawing.Point(143, 404);
            this.deleteListItem.Name = "deleteListItem";
            this.deleteListItem.Size = new System.Drawing.Size(140, 23);
            this.deleteListItem.TabIndex = 10;
            this.deleteListItem.Text = "Delete Highlighted Row";
            this.deleteListItem.UseVisualStyleBackColor = true;
            this.deleteListItem.Click += new System.EventHandler(this.deleteListItem_Click);
            // 
            // createAPPFile
            // 
            this.createAPPFile.Location = new System.Drawing.Point(454, 404);
            this.createAPPFile.Name = "createAPPFile";
            this.createAPPFile.Size = new System.Drawing.Size(104, 23);
            this.createAPPFile.TabIndex = 11;
            this.createAPPFile.Text = "Create .APP File";
            this.createAPPFile.UseVisualStyleBackColor = true;
            // 
            // editCellButton
            // 
            this.editCellButton.Location = new System.Drawing.Point(15, 404);
            this.editCellButton.Name = "editCellButton";
            this.editCellButton.Size = new System.Drawing.Size(122, 23);
            this.editCellButton.TabIndex = 12;
            this.editCellButton.Text = "Edit Cell";
            this.editCellButton.UseVisualStyleBackColor = true;
            this.editCellButton.Click += new System.EventHandler(this.editCellButton_Click);
            // 
            // CreateAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 439);
            this.Controls.Add(this.editCellButton);
            this.Controls.Add(this.createAPPFile);
            this.Controls.Add(this.deleteListItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addMultiCell);
            this.Controls.Add(this.addCCell);
            this.Controls.Add(this.addWCell);
            this.Controls.Add(this.addMCell);
            this.Controls.Add(this.addKCell);
            this.Controls.Add(this.listViewLabel);
            this.Controls.Add(this.appListView);
            this.Name = "CreateAppForm";
            this.Text = "CreateAppForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView appListView;
        private System.Windows.Forms.Label listViewLabel;
        private System.Windows.Forms.ColumnHeader nameColHead;
        private System.Windows.Forms.ColumnHeader typeColhead;
        private System.Windows.Forms.ColumnHeader digitsColHead;
        private System.Windows.Forms.ColumnHeader precisionColHead;
        private System.Windows.Forms.ColumnHeader conInfoColHead;
        private System.Windows.Forms.ColumnHeader colNumberHeader;
        private System.Windows.Forms.Button addKCell;
        private System.Windows.Forms.Button addMCell;
        private System.Windows.Forms.Button addWCell;
        private System.Windows.Forms.Button addCCell;
        private System.Windows.Forms.Button addMultiCell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button deleteListItem;
        private System.Windows.Forms.Button createAPPFile;
        private System.Windows.Forms.Button editCellButton;
    }
}