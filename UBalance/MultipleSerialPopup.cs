using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UBalance
{
    public partial class MultipleSerialPopup : Form
    {
        private List<string> _portNames; 
        private List<string> _itemsInBalanceList;
        private List<string> _itemsInColorList;

        public string ColorPortName { get; private set; }
        public string BalancePortName { get; private set; }
 
        public MultipleSerialPopup()
        {
            ColorPortName = "Unused";
            BalancePortName = "Unused";
            _itemsInBalanceList = new List<string>();
            _itemsInColorList= new List<string>();
            _portNames = SerialPort.GetPortNames().ToList();

            // add all com ports and unused to both lists
            _itemsInBalanceList.Add("Unused");
            _itemsInBalanceList.AddRange(_portNames);

            foreach (string item in _itemsInBalanceList)
            {
                _itemsInColorList.Add(item);
            }

            InitializeComponent();
            setupLists();
            balanceDropDownList.SelectedIndexChanged += balanceDropDownList_SelectedIndexChanged;
            colorDropDownList.SelectedIndexChanged += colorDropDownList_SelectedIndexChanged;
        }

        void colorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox colorComboBox = sender as ComboBox;

            if (colorComboBox == null) return;

            var item = colorComboBox.SelectedItem;
            ColorPortName = item.ToString();

            if (balanceDropDownList.Items.Contains(item) && _portNames.Contains(item))
            {
                balanceDropDownList.Items.Remove(item);
            }

            // fix lists
            foreach (var str in _portNames)
            {
                // don't add duplicate item
                if (balanceDropDownList.Items.Contains(str)) continue;

                // don't add item if it is selected in the other list
                if ((string)item != "Unused" && (string)item == str) continue;
                balanceDropDownList.Items.Add(str);
            }



        }

        void balanceDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox balanceComboBox = sender as ComboBox;

            if (balanceComboBox == null) return;

            var item = balanceComboBox.SelectedItem;
            BalancePortName = item.ToString();

            if (colorDropDownList.Items.Contains(item) && _portNames.Contains(item))
            {
                colorDropDownList.Items.Remove(item);
            }

            // fix lists
            foreach (var str in _portNames)
            {
                // don't add duplicate item
                if (colorDropDownList.Items.Contains(str)) continue;
                // don't add item if it is selected in the other list
                if ((string)item != "Unused" && (string)item == str) continue;
                colorDropDownList.Items.Add(str);
            }
        }

        private void setupLists()
        {
            foreach (string item in _itemsInBalanceList)
            {
                balanceDropDownList.Items.Add(item);
            }

            foreach (string item in _itemsInColorList)
            {
                colorDropDownList.Items.Add(item);
            }

            balanceDropDownList.SelectedItem = balanceDropDownList.Items[0];
            colorDropDownList.SelectedItem = colorDropDownList.Items[0];
        }

        private void alertButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
