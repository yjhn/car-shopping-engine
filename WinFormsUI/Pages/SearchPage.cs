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
            lowerYearRangeTextBox.Minimum = VehiclePropertyConstants.minVehicleManufactureYear;
            lowerYearRangeTextBox.Maximum = VehiclePropertyConstants.maxVehicleManufactureYear;
            upperYearRangeTextBox.Minimum = VehiclePropertyConstants.minVehicleManufactureYear;
            upperYearRangeTextBox.Maximum = VehiclePropertyConstants.maxVehicleManufactureYear;

            // set min and max allowed price
            lowerPriceTextBox.Minimum = VehiclePropertyConstants.minVehiclePrice;
            lowerPriceTextBox.Maximum = VehiclePropertyConstants.maxVehiclePrice;
            upperPriceTextBox.Minimum = VehiclePropertyConstants.minVehiclePrice;
            upperPriceTextBox.Maximum = VehiclePropertyConstants.maxVehiclePrice;

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

            ChassisType? vehicleType;
            switch (vehicleTypeCombobox.SelectedItem)
            {
                case "any":
                    vehicleType = default;
                    break;
                case "station wagon":
                    vehicleType = ChassisType.station_wagon;
                    break;
                case "hatchback":
                    vehicleType = ChassisType.hatchback;
                    break;
                case "sedan":
                    vehicleType = ChassisType.sedan;
                    break;
                case "suv":
                    vehicleType = ChassisType.suv;
                    break;
                case "minivan":
                    vehicleType = ChassisType.minivan;
                    break;
                case "coupe":
                    vehicleType = ChassisType.coupe;
                    break;
                case "convertible":
                    vehicleType = ChassisType.convertible;
                    break;
                case "passenger minibus":
                    vehicleType = ChassisType.passenger_minibus;
                    break;
                case "combi minibus":
                    vehicleType = ChassisType.combi_minibus;
                    break;
                case "freight minibus":
                    vehicleType = ChassisType.freight_minibus;
                    break;
                case "commercial":
                    vehicleType = ChassisType.commercial;
                    break;
                default:
                    vehicleType = default;
                    break;
            }

            SortingCriteria sortBy = Sorting.GetSortingCriteria((string)sortByCombobox.SelectedItem);

            bool sortAscending = radioButtonAscending.Checked;

            _resultList = await VehicleSearch.searchVehicles(brandTextBox.Text,
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
