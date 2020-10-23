using DataTypes;
using System;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class SearchPage : UserControl
    {
        public SearchPage()
        {
            InitializeComponent();
            // do other intialization code here, such as setting default selected values for comboboxes

            // default sorting: by upload date descending
            this.sortByCombobox.SelectedIndex = 0;
            // default fuel type: any
            this.fuelTypeComboBox.SelectedIndex = 0;

            // make NumericUpDown appear empty
            lowerYearRangeTextBox.Text = "";
            upperYearRangeTextBox.Text = "";
            lowerPriceTextBox.Text = "";
            upperPriceTextBox.Text = "";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // formulate a query to the frontend to search for cars
            // frontend should save the query for use if user goes back to this screen

            // should move all this to frontend, just supply all this info

            FuelType? fuelType;
            switch (fuelTypeComboBox.SelectedItem)
            {
                case "any":
                    fuelType = FuelType.any;
                    break;
                case "petrol":
                    fuelType = FuelType.petrol;
                    break;
                case "diesel":
                    fuelType = FuelType.diesel;
                    break;
                case "electric":
                    fuelType = FuelType.electricity;
                    break;
                case "hybrid":
                    fuelType = FuelType.hybrid;
                    break;
                default:
                    fuelType = default;
                    break;
            }

            // filtering

            CarFilters filters = new CarFilters()
            {
                PriceFrom = (lowerPriceTextBox.Value == lowerPriceTextBox.Minimum) ? default(uint?) : Convert.ToUInt32(lowerPriceTextBox.Value),
                PriceTo = (upperPriceTextBox.Value == upperPriceTextBox.Minimum) ? default(uint?) : Convert.ToUInt32(upperPriceTextBox.Value),
                Used = radioButtonUsed.Checked ? true : (radioButtonNew.Checked ? false : default(bool?)),
                YearFrom = (lowerYearRangeTextBox.Value == lowerYearRangeTextBox.Minimum) ? default(uint?) : Convert.ToUInt32(lowerYearRangeTextBox.Value),
                YearTo = (upperYearRangeTextBox.Value == upperYearRangeTextBox.Maximum) ? default(uint?) : Convert.ToUInt32(upperYearRangeTextBox.Value),
                FuelType = fuelType
                // add more filters
            };

            // sorting

            SortingCriteria sortBy;
            switch (sortByCombobox.SelectedItem)
            {
                case "upload date":
                    sortBy = SortingCriteria.UploadDate;
                    break;
                case "price":
                    sortBy = SortingCriteria.Price;
                    break;
                case "date of purchase":
                    sortBy = SortingCriteria.DateOfPurchase;
                    break;
                case "total kilometers driven":
                    sortBy = SortingCriteria.TotalKilometersDriven;
                    break;
                case "original purchase country":
                    sortBy = SortingCriteria.OriginalPurchaseCountry;
                    break;
                default:
                    sortBy = SortingCriteria.UploadDate;
                    break;
            }
            if (radioButtonDescending.Checked)
            {
                sortBy |= SortingCriteria.SortDescending;
            }
            else
            {
                sortBy |= SortingCriteria.SortAscending;
            }

            // call frontend with search data
            //List<Car> carsToDisplay = Frontend.SearchCars(filters, sortBy);
        }

        private void resetSearchButton_Click(object sender, EventArgs e)
        {
            brandTextBox.ResetText();
            modelTextBox.ResetText();
            lowerPriceTextBox.ResetText();
            upperPriceTextBox.ResetText();
            radioButtonNew.Checked = false;
            radioButtonUsed.Checked = false;
            lowerYearRangeTextBox.ResetText();
            upperYearRangeTextBox.ResetText();
            fuelTypeComboBox.SelectedIndex = 0;
            sortByCombobox.SelectedIndex = 0;
            radioButtonAscending.Checked = false;
            radioButtonDescending.Checked = true;
        }
    }
}
