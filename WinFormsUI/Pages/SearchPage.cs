using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class SearchPage : UserControl
    {
        public SearchPage()
        {
            InitializeComponent();
            //lowerYearRangeComboBox.SelectedIndex = lowerYearRangeComboBox.FindStringExact("test1");
        }

        private void newCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            usedCheckBox.Checked = !newCheckBox.Checked;
        }

        private void usedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            newCheckBox.Checked = !usedCheckBox.Checked;
        }
    }
}
