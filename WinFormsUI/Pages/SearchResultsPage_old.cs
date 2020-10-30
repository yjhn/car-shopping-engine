using DataTypes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class SearchResultsPage_old : UserControl
    {
        private List<Car> resultList;
        public SearchResultsPage_old()
        {
            InitializeComponent();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void SearchResultsPage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                goBackButton.Focus();
            }
        }

        private void sortResultsByCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortingCriteria criteria = Sorting.GetSortingCriteria((string)sortResultsByCombobox.SelectedItem);
            resultList.SortBy(criteria, sortResultsAscRadioBtn.Checked);

            // display the sorted results (maybe this isn't needed?)
        }
    }
}
