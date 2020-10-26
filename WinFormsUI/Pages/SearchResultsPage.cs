using DataTypes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class SearchResultsPage : UserControl
    {
        private List<Car> resultList;
        public SearchResultsPage()
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
            SortingCriteria criteria;
            switch (sortResultsByCombobox.SelectedItem)
            {
                case "upload date":
                    criteria = SortingCriteria.UploadDate;
                    break;
                case "price":
                    criteria = SortingCriteria.Price;
                    break;
                case "date of purchase":
                    criteria = SortingCriteria.DateOfPurchase;
                    break;
                case "total kilometers driven":
                    criteria = SortingCriteria.TotalKilometersDriven;
                    break;
                case "original purchase country":
                    criteria = SortingCriteria.OriginalPurchaseCountry;
                    break;
                default:
                    criteria = SortingCriteria.UploadDate;
                    break;
            }
            resultList.SortBy(criteria, sortResultsAscRadioBtn.Checked);

            // display the sorted results (maybe this isn't needed?)
        }
    }
}
