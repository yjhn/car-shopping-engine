using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class SearchPage : UserControl
    {
        private List<Car> _resultList;

        public SearchPage()
        {
            InitializeComponent();
            // do other intialization code here, such as setting default selected values for comboboxes

            // set min and max allowed manufacture years
            lowerYearRangeTextBox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            lowerYearRangeTextBox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;
            upperYearRangeTextBox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            upperYearRangeTextBox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;

            // set min and max allowed price
            lowerPriceTextBox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            lowerPriceTextBox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;
            upperPriceTextBox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            upperPriceTextBox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;

            // default vehicle type: any
            vehicleTypeCombobox.SelectedIndex = 0;
            // default sorting: by upload date descending
            sortByCombobox.SelectedIndex = 0;
            // default fuel type: any
            fuelTypeComboBox.SelectedIndex = 0;

            // make NumericUpDown appear empty
            lowerYearRangeTextBox.Text = "";
            upperYearRangeTextBox.Text = "";
            lowerPriceTextBox.Text = "";
            upperPriceTextBox.Text = "";
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            // formulate a query to the frontend to search for cars
            // frontend should save the query for use if user goes back to this screen - or maybe not, as information will not be removed from the form

            FuelType? fuelType;
            switch (fuelTypeComboBox.SelectedItem)
            {
                case "any":
                    fuelType = default;
                    break;
                case "petrol":
                    fuelType = FuelType.Petrol;
                    break;
                case "diesel":
                    fuelType = FuelType.Diesel;
                    break;
                case "electric":
                    fuelType = FuelType.Electricity;
                    break;
                case "hybrid":
                    fuelType = FuelType.Hybrid;
                    break;
                default:
                    fuelType = default;
                    break;
            }

            ChassisType? vehicleType;
            switch (vehicleTypeCombobox.SelectedItem)
            {
                case "any":
                    vehicleType = default;
                    break;
                case "station wagon":
                    vehicleType = ChassisType.Station_wagon;
                    break;
                case "hatchback":
                    vehicleType = ChassisType.Hatchback;
                    break;
                case "sedan":
                    vehicleType = ChassisType.Sedan;
                    break;
                case "suv":
                    vehicleType = ChassisType.Suv;
                    break;
                case "minivan":
                    vehicleType = ChassisType.Minivan;
                    break;
                case "coupe":
                    vehicleType = ChassisType.Coupe;
                    break;
                case "convertible":
                    vehicleType = ChassisType.Convertible;
                    break;
                case "passenger minibus":
                    vehicleType = ChassisType.Passenger_minibus;
                    break;
                case "combi minibus":
                    vehicleType = ChassisType.Combi_minibus;
                    break;
                case "freight minibus":
                    vehicleType = ChassisType.Freight_minibus;
                    break;
                case "commercial":
                    vehicleType = ChassisType.Commercial;
                    break;
                default:
                    vehicleType = default;
                    break;
            }

            SortingCriteria sortBy = Sorting.GetSortingCriteria((string)sortByCombobox.SelectedItem);

            bool sortAscending = radioButtonAscending.Checked;

            _resultList = await VehicleSearch.SearchVehicles(brandTextBox.Text,
                                                      modelTextBox.Text,
                                                      fuelType,
                                                      vehicleType,
                                                      sortBy,
                                                      sortAscending,
                                                      radioButtonUsed.Checked,
                                                      radioButtonNew.Checked,
                                                      Convert.ToInt32(lowerPriceTextBox.Value),
                                                      Convert.ToInt32(upperPriceTextBox.Value),
                                                      Convert.ToInt32(lowerYearRangeTextBox.Value),
                                                      Convert.ToInt32(upperYearRangeTextBox.Value));

            // after we get the results back from server, we show them
            //searchResultsPage.Visible = true;
        }

        private void ResetSearchButton_Click(object sender, EventArgs e)
        {
            // reset everything on page to default values
            vehicleTypeCombobox.SelectedIndex = 0;
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

        private void SearchPage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                vehicleTypeCombobox.Focus();
            }
        }
    }
}
