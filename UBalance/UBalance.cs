using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UBalance.Library.AppLoading;
using UBalance.Library.Classes;
using UBalance.Library.Events;
using UBalance.Properties;

namespace UBalance
{
    public partial class UBalance : Form
    {
        public static AppLoader App;
        public static FolderBrowserDialog FolderBroswer = new FolderBrowserDialog();
        public GridData ViewData;
        public BalanceReader Balance;
        public ColorReader Color;
        public AppParser AppParse;
        public bool RecentlySaved;

        public string BalancePort = String.Empty;
        public string ColorPort = String.Empty;

        public SerialType SingleSerialType;

        public ContextMenuStrip RightClickMenu;

        // Base Constructor for the program
        public UBalance()
        {
            InitializeComponent();

            if (Settings.Default.DefaultPath.Length < 4)
            {
                FirstRunPopup first = new FirstRunPopup();

                first.ShowDialog();

                if (first.DialogResult == DialogResult.OK)
                {
                    FolderBrowserDialog f = new FolderBrowserDialog();

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.DefaultPath = f.SelectedPath;
                    }

                    Settings.Default.Save();
                }
            }

            App = new AppLoader(Settings.Default.DefaultPath);

            Balance = DefaultBalance();

            

            if (Balance == null || !Balance.IsBalanceConnected())
            {
                Balance = null;
                readBalanceButton.Enabled = false;
                readBalanceButton.Text = @"Disconnected";
            }
            else
            {
                // update command being sent to the balance on click
                Balance.UpdateCommand();
                readBalanceButton.Enabled = true;
                readBalanceButton.Text = @"Read Balance";
            }

            addRowButton.Enabled = false;
        }

        #region GUI Functions
        // Load Default Balance Settings
        private BalanceReader DefaultBalance()
        {
            // Get default settings and create balance reader off of those options
            string comPort = BalancePort == String.Empty ? Settings.Default.COMPort : BalancePort;          //1 - position in constructor
            int baudRate = Settings.Default.BaudRate;           //2
            int dataBits = Settings.Default.DataBits;           //4
            StopBits stopBits;                                  //3
            Parity parity;                                      //5
            string sicsCommand = Settings.Default.SICSCommand;  //6
            bool rts = Settings.Default.RTS;                    //7

            //Send sicsCommand to scale to update the value

            Enum.TryParse(Settings.Default.StopBits, out stopBits);
            Enum.TryParse(Settings.Default.Parity, out parity);

            return new BalanceReader(comPort, baudRate, stopBits, dataBits, parity, sicsCommand, rts);
        }

        // Load App Files into ToolStripMenu "Apps"
        public void LoadAndUpdateAppFiles()
        {
            // remove the old toolstrip menu items if they exist
            if (appsToolStripMenuItem.DropDownItems.Count > 0)
            {
                while (appsToolStripMenuItem.DropDownItems.Count != 0)
                {
                    appsToolStripMenuItem.DropDownItems.RemoveAt(0);
                }
            }

            List<string> itemsToAddToMenu = App.GetFileNames();

            if (itemsToAddToMenu.Count == 0)
            {
                // no .APP files found in the directory, adding useful info for the user
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Enabled = false;
                item.Text = "No app items found";
                this.appsToolStripMenuItem.DropDownItems.Insert(0, item);
            }
            else
            {
                int i = 0;
                foreach (string s in itemsToAddToMenu)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Enabled = true;
                    item.Text = Path.GetFileNameWithoutExtension(s);
                    item.Click += item_Click;
                    this.appsToolStripMenuItem.DropDownItems.Insert(i, item);
                    i++;
                }
            }
        }

        //Clears GridView and Any Subscriptions
        private void EmptyGridView(string nameOfApp)
        {
            int index = App.GetFileNames().IndexOf(nameOfApp);

            if (index < 0) return;
            AppParse = new AppParser(App.GetDirectoryNames()[index]);

            if (ViewData != null)
            {
                for (int j = 0; j < UBalanceDataGridView.RowCount; j++)
                {
                    for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
                    {
                        if (ViewData.GetCellType(0, i) == CellType.Multiple)
                        {
                            MultipleCell mc = ViewData.GetCell(0, i) as MultipleCell;
                            mc.NotifyHeaderNameChange -= mc_NotifyHeaderNameChange;

                            foreach (var cell in mc.CellOptions)
                            {
                                cell.CellValueChanged -= UBalance_CellValueChanged;
                                cell.NotifyDependents -= UBalance_NotifyDependents;
                            }
                        }
                        else
                        {
                            Cell c = ViewData.GetCell(0, i);
                            c.CellValueChanged -= UBalance_CellValueChanged;
                            c.NotifyDependents -= UBalance_NotifyDependents;
                        }
                    }
                }
            }

            UBalanceDataGridView.Rows.Clear();
   
            ViewData = new GridData(AppParse.ReturnCellsInRow(UBalanceDataGridView.RowCount), nameOfApp);

            // update right click context menu if multiple cells exist
            RightClickMenu = new ContextMenuStrip();
            UBalanceDataGridView.ContextMenuStrip = RightClickMenu;

            if (ViewData.HasMultipleCells())
            {
                for (int i = 0; i < ViewData.ColumnHeaders().Count; i++)
                {
                    var cell = ViewData.GetCell(0, i) as MultipleCell;
                    if (cell != null)
                    {
                        foreach (string s in cell.OptionStrings)
                        {
                            ToolStripMenuItem t = new ToolStripMenuItem(s);
                            t.Click += t_Click;
                            RightClickMenu.Items.Add(t);
                        }

                        break;
                    }
                }
            }

            List<string> columnHeaders = ViewData.ColumnHeaders();

            int count = columnHeaders.Count;

            UBalanceDataGridView.ColumnCount = count;
            UBalanceDataGridView.CellBeginEdit += UBalanceDataGridView_CellBeginEdit;
            UBalanceDataGridView.CellEndEdit += UBalanceDataGridView_CellEndEdit;

            UBalanceDataGridView.Rows.Add();

            // update initialized values from constructor
            for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
            {
                UBalanceDataGridView.Rows[0].Cells[i].Value = ViewData.GetCell(0, i).Value.ToString();
            }

            for (int i = 0; i < count; i++)
            {
                UBalanceDataGridView.Columns[i].HeaderText = columnHeaders[i];
            }

            for (int i = 0; i < UBalanceDataGridView.Rows[0].Cells.Count; i++)
            {
                if (ViewData.GetCellType(0, i) == CellType.Multiple)
                {
                    MultipleCell mc = ViewData.GetCell(0, i) as MultipleCell;
                    mc.NotifyHeaderNameChange += mc_NotifyHeaderNameChange;

                    foreach (var cell in mc.CellOptions)
                    {
                        cell.CellValueChanged += UBalance_CellValueChanged;
                        cell.NotifyDependents += UBalance_NotifyDependents;
                    }
                }
                else
                {
                    Cell c = ViewData.GetCell(0, i);
                    c.CellValueChanged += UBalance_CellValueChanged;
                    c.NotifyDependents += UBalance_NotifyDependents;
                }

                UBalanceDataGridView.Columns[i].Resizable = DataGridViewTriState.True;
            }
        }

        //Add Row to Logic and GUI
        void AddRowToDataAndView()
        {
            int rowNumber = UBalanceDataGridView.RowCount; // will be correct row index when we add a row

            UBalanceDataGridView.Rows.Add();
            ViewData.AddRow();

            // prevent a bunch of event call updates and just update manually here
            for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
            {
                UBalanceDataGridView.Rows[rowNumber].Cells[i].Value = ViewData.GetCell(rowNumber, i).Value;
            }

            for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
            {
                if (ViewData.GetCellType(rowNumber, i) == CellType.Multiple)
                {
                    MultipleCell mc = ViewData.GetCell(rowNumber, i) as MultipleCell;
                    mc.NotifyHeaderNameChange += mc_NotifyHeaderNameChange;

                    foreach (var cell in mc.CellOptions)
                    {
                        cell.CellValueChanged += UBalance_CellValueChanged;
                        cell.NotifyDependents += UBalance_NotifyDependents;
                    }
                }
                else
                {
                    Cell c = ViewData.GetCell(rowNumber, i);
                    c.CellValueChanged += UBalance_CellValueChanged;
                    c.NotifyDependents += UBalance_NotifyDependents;
                }
            }
        }

        //Forced Nullable TryParse function
        double? nullableDoubleTryParse(string valueString)
        {
            double outValue;
            return double.TryParse(valueString, out outValue) ? (double?)outValue : null;
        }
        #endregion

        #region Hot Keys And Find Next Cells
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1) && saveToolStripMenuItem.Enabled)
            {
                saveToolStripMenuItem_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F2))
            {
                loadToolStripMenuItem_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.F3) && addRowButton.Enabled)
            {
                addRowButton_Click(this, EventArgs.Empty);
                return true;
            }
            if (keyData == (Keys.Enter) && _cellBeginEdit != null)
            {
                NextCell();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void NextCell()
        {
            int maxCols = UBalanceDataGridView.ColumnCount;
            // don't change on mouse press
            if (MouseButtons != 0) return;


            if (_cellBeginEdit != null && UBalanceDataGridView.CurrentCell != null)
            {
                // need to select next cell based on logic implemented lower
                int nRow, nColumn;

                Cell c = ViewData.GetCell(_cellBeginEdit.RowIndex, _cellBeginEdit.ColumnIndex);

                ViewData.NextCell(c, out nRow, out nColumn);

                if (nRow == UBalanceDataGridView.RowCount)
                {
                    AddRowToDataAndView();
                }
                UBalanceDataGridView.CurrentCell = UBalanceDataGridView.Rows[nRow].Cells[nColumn];
            }
            _cellBeginEdit = null;
        }
        #endregion

        #region GUI Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            int numConnectedPorts = SerialPort.GetPortNames().ToList().Count;

            if (numConnectedPorts > 1)
            {
                MultipleSerialPopup m = new MultipleSerialPopup();

                m.Closing += m_Closing;

                m.Show();
            }
            else if (numConnectedPorts == 1)
            {
                SingleSerialPopup s = new SingleSerialPopup();

                s.Closing += s_Closing;
                s.Show();
            }

            LoadAndUpdateAppFiles();

            UBalanceDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }

        //Load File Event Handler
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog()
            {
                InitialDirectory = Settings.Default.DefaultPath,
                RestoreDirectory = true
            };

            if (UBalanceDataGridView.RowCount > 0)
            {
                SaveCheck sc = new SaveCheck();
                sc.LabelCorrectlyFromLoad();

                if (sc.ShowDialog() == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }

            if (o.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(o.FileName, FileMode.Open);
                StreamReader r = new StreamReader(fs);

                // first line is the app name
                string appName = r.ReadLine();

                EmptyGridView(appName);

                string s;
                int row = 0, column;
                double placeHolder;
                bool firstLine = true;
                while ((s = r.ReadLine()) != null)
                {
                    if (!firstLine)
                        AddRowToDataAndView();
                    var items = s.Split(',');
                    column = 0;

                    foreach (string item in items)
                    {
                        if (!String.IsNullOrWhiteSpace(item))
                        {
                            if (double.TryParse(item, out placeHolder))
                                ViewData.GetCell(row, column).Value = placeHolder;
                            // string, need to set correct string value for celltype
                            // only K has a string value
                            else
                            {
                                KCell kc = ViewData.GetCell(row, column) as KCell;
                                if (kc != null)
                                {
                                    kc.KValue = item;
                                }
                            }
                        }
                        column++;
                    }
                    firstLine = false;
                    row++;
                }

                r.Close();
                fs.Close();
                saveToolStripMenuItem.Enabled = true;
                addRowButton.Enabled = true;

                // Don't annoy user if they just loaded the file
                RecentlySaved = true;
            }
        }

        //Save File Event Handler
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog()
            {
                RestoreDirectory = true,
                InitialDirectory = Settings.Default.DefaultPath
            };

            if (s.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(s.FileName, FileMode.Create);
                StreamWriter w = new StreamWriter(fs);

                w.Write(ViewData.Save());

                w.Close();
                fs.Close();
            }

            // Don't annoy user if they have recently saved
            RecentlySaved = true;
        }

        //Apps Menu Item Clicked Event Handler
        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = sender as ToolStripMenuItem;

            if (t == null) return;

            if (UBalanceDataGridView.RowCount > 0)
            {
                SaveCheck sc = new SaveCheck();
                sc.LabelCorrectlyFromLoad();

                if (sc.ShowDialog() == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(this, EventArgs.Empty);
                }
            }

            //find item in app
            string nameOfApp = t.Text;
            Text = "UBalance - " + t.Text;

            EmptyGridView(nameOfApp);

            addRowButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        //Preferences Popup Event Handler
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences pref = new Preferences();

            pref.CloseEvent += pref_CloseEvent;

            pref.Show();
        }

        //Preferences On Close Event Handler
        private void pref_CloseEvent(object sender, PreferenceCloseEventArgs e)
        {
            App.UpdatePath(e.Text);
            // update balance settings
            if (Balance != null)
                Balance.Dispose();
            Balance = DefaultBalance();

            LoadAndUpdateAppFiles();

            readBalanceButton.Enabled = Balance.IsBalanceConnected();
        }

        //Add Row Event Handler;
        private void addRowButton_Click(object sender, EventArgs e)
        {
            AddRowToDataAndView();
        }

        //Read Balance Event Handler
        private void readBalanceButton_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            try
            {
                cell = UBalanceDataGridView.SelectedCells[0];
            }
            catch (Exception)
            {
                //ignore, keep cell null
            }


            if (cell != null)
            {
                cell.Value = Balance.GetBalanceValue();
            }
        }

        // Single Serial Port Popup Event Handler
        void s_Closing(object sender, CancelEventArgs e)
        {
            SingleSerialPopup singleSerialPopup = sender as SingleSerialPopup;
            if (singleSerialPopup == null) return;
            SingleSerialType = singleSerialPopup.PortType;

            if (SingleSerialType == SerialType.Balance)
            {
                BalancePort = singleSerialPopup.PortName;
            }
            else if (SingleSerialType == SerialType.ColorMeter)
            {
                ColorPort = singleSerialPopup.PortName;
            }
        }

        // Multiple Serial Port Popup Event Handler
        private void m_Closing(object sender, CancelEventArgs e)
        {
            MultipleSerialPopup multipleSerialPopup = sender as MultipleSerialPopup;

            if (multipleSerialPopup == null) return;

            if (multipleSerialPopup.BalancePortName != "Unused")
            {
                BalancePort = multipleSerialPopup.BalancePortName;
            }
            if (multipleSerialPopup.ColorPortName != "Unused")
            {
                ColorPort = multipleSerialPopup.ColorPortName;
            }
        }

        //Right Click Menu Event
        void t_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem t = sender as ToolStripMenuItem;

            if (t == null) return;

            MultipleCell mc = null;

            for (int i = 0; i < ViewData.ColumnHeaders().Count; i++)
            {
                if (ViewData.GetCellType(0, i) == CellType.Multiple)
                {
                    mc = ViewData.GetCell(0, i) as MultipleCell;
                    break;
                }
            }

            // make sure we have the multiple cell selected
            if (mc == null) return;

            // change selected item to the CellOption that contains the correct name
            mc.ChangeOption(t.ToString());
        }

        #endregion

        #region Cell Edit Event Handlers
        private DataGridViewCell _cellBeginEdit;

        // Finished Editing Cell Event Handler
        void UBalanceDataGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            _cellBeginEdit = UBalanceDataGridView[e.ColumnIndex, e.RowIndex];
            // arbitrary number
            bool changed;
            double? d = null;
            string s = String.Empty;

            // need to update logic layer

            if ((string)_cellBeginEdit.Value == oldCellValue)
            {
                return;
            }
            else changed = true;

            if (_cellBeginEdit.Value != null)
            {
                d = nullableDoubleTryParse(_cellBeginEdit.Value.ToString());
            }

            if (_cellBeginEdit.Value != null && d == null)
            {
                s = _cellBeginEdit.Value.ToString();
            }

            switch (ViewData.GetCellType(e.RowIndex, e.ColumnIndex))
            {
                // don't update if value is not valid
                case CellType.C:
                    CCell c = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as CCell;

                    if (c == null) return;

                    if (changed == true && d != null) c.OverrideValue((double)d);
                    else c.Value = null;

                    break;
                case CellType.K:
                    KCell k = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as KCell;

                    if (k == null) return;

                    if (s.Length > 0)
                    {
                        k.KValue = s;
                    }
                    else if (d != null && changed == true)
                    {
                        k.KValue = d.ToString();
                    }
                    else
                    {
                        k.KValue = null;
                    }

                    break;
                case CellType.M:
                    MCell m = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as MCell;

                    if (m == null) return;

                    if (changed == true && d != null) m.OverrideValue((double)d);
                    else m.Value = null;

                    break;
                case CellType.W:
                    WCell w = ViewData.GetCell(e.RowIndex, e.ColumnIndex) as WCell;

                    if (w == null) return;

                    if (changed == true && d != null) w.Value = d;
                    else w.Value = null;

                    break;
            }
            RecentlySaved = false;
        }

        private string oldCellValue;
        // Begin Editing Cell Event handler
        void UBalanceDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _cellBeginEdit = UBalanceDataGridView.CurrentCell;
            DataGridViewCell d = UBalanceDataGridView[e.ColumnIndex, e.RowIndex];
            oldCellValue = d.Value == null ? null : d.Value.ToString();
        }

        // Multiple Cell Change Header Name Event Handler
        void mc_NotifyHeaderNameChange(object sender, EventArgs e)
        {
            MultipleCell mc = sender as MultipleCell;

            if (mc == null) return;
            // don't stack overflow on recursive calls that happen below
            if (UBalanceDataGridView.Columns[mc.ColumnIndex].HeaderText == mc.SelectedCell.Label) return;

            UBalanceDataGridView.Columns[mc.ColumnIndex].HeaderText = mc.SelectedCell.Label;

            // change the selected cells for every column to the correct Selected cell

            for (int i = 0; i < UBalanceDataGridView.RowCount; i++)
            {
                MultipleCell temp = ViewData.GetCell(i, mc.ColumnIndex) as MultipleCell;

                temp.ChangeOption(mc.SelectedCell.Label);
            }
        }

        // Notify Mirror Cell Dependents Event Handler
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

        // Logic Value Changed Event Handler
        void UBalance_CellValueChanged(object sender, PropertyChangedEventArgs e)
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
            //else if (e.PropertyName == "MultipleCell")
            //{
            //    if (sender is MultipleCell)
            //    {
            //        MultipleCell mc = sender as MultipleCell;

            //        // make sure value is not null
            //        if (mc.Value != null)
            //        {
            //            UBalanceDataGridView.Rows[mc.RowIndex].Cells[mc.ColumnIndex].Value = mc.Value;
            //        }

            //        ViewData.CheckAndUpdateDependency(mc);
            //    }
            //}
            else
            {
                if (c != null && c.Value == null)
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
                    if (c != null)
                    {
                        // need to check if there is a calculation with sender as a dependency
                        ViewData.CheckAndUpdateDependency(c);
                        UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value = c.Value.ToString();

                        if (ViewData.HasMultipleCells())
                        {
                            MultipleCell mc = null;

                            for (int i = 0; i < UBalanceDataGridView.ColumnCount; i++)
                            {
                                if (ViewData.GetCellType(c.RowIndex, i) == CellType.Multiple)
                                {
                                    mc = ViewData.GetCell(c.RowIndex, i) as MultipleCell;
                                    break;
                                }
                            }

                            if (mc == null) return;
                            // Update Value to the currently selected cell
                            ViewData.CheckAndUpdateMultipleDependency(c, mc);
                            UBalanceDataGridView.Rows[c.RowIndex].Cells[c.ColumnIndex].Value =
                                mc.SelectedValue.ToString();
                        }
                    }

                    
                }

            }
        }
#endregion
    }
}
