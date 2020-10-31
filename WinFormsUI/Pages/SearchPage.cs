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
        private Api _frontendApi = new Api(); // this is bad. There should only be one instance of this in the whole project

        public SearchPage()
        {
            InitializeComponent();

            // set min and max allowed manufacture years
            lowerYearTextbox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            lowerYearTextbox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;
            upperYearTextbox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            upperYearTextbox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;

            // set min and max allowed price
            lowerPriceTextbox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            lowerPriceTextbox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;
            upperPriceTextbox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            upperPriceTextbox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;

            // default vehicle type: any
            vehicleTypeCombobox.SelectedIndex = 0;
            // default sorting: by upload date descending
            sortByCombobox.SelectedIndex = 0;
            // default fuel type: any
            fuelTypeCombobox.SelectedIndex = 0;

            // make NumericUpDown appear empty
            lowerYearTextbox.Text = "";
            upperYearTextbox.Text = "";
            lowerPriceTextbox.Text = "";
            upperPriceTextbox.Text = "";
        }

        private /*async*/ void SearchButton_Click(object sender, EventArgs e)
        {
            // for testing purposes
            BrowsePage searchResultsTab = new BrowsePage();
            TabPage resultsTab = new TabPage("results 1");
            resultsTab.SuspendLayout();
            resultsTab.Controls.Add(searchResultsTab);
            searchResultsTab.Dock = DockStyle.Fill;
            searchResultsTab.AutoScroll = true;
            searchResultsTab.AutoSize = false;
            //searchResultsTab.
            resultsTab.ResumeLayout();

            searchAndResultsTabs.TabPages.Add(resultsTab);

            // formulate a query to the frontend to search for cars
            // frontend should save the query for use if user goes back to this screen - or maybe not, as information will not be removed from the form

            //FuelType? fuelType;
            //switch (fuelTypeCombobox.SelectedItem)
            //{
            //    case "any":
            //        fuelType = default;
            //        break;
            //    case "petrol":
            //        fuelType = FuelType.Petrol;
            //        break;
            //    case "diesel":
            //        fuelType = FuelType.Diesel;
            //        break;
            //    case "electric":
            //        fuelType = FuelType.Electricity;
            //        break;
            //    case "hybrid":
            //        fuelType = FuelType.Hybrid;
            //        break;
            //    default:
            //        fuelType = default;
            //        break;
            //}

            //ChassisType? vehicleType;
            //switch (vehicleTypeCombobox.SelectedItem)
            //{
            //    case "any":
            //        vehicleType = default;
            //        break;
            //    case "station wagon":
            //        vehicleType = ChassisType.Station_wagon;
            //        break;
            //    case "hatchback":
            //        vehicleType = ChassisType.Hatchback;
            //        break;
            //    case "sedan":
            //        vehicleType = ChassisType.Sedan;
            //        break;
            //    case "suv":
            //        vehicleType = ChassisType.Suv;
            //        break;
            //    case "minivan":
            //        vehicleType = ChassisType.Minivan;
            //        break;
            //    case "coupe":
            //        vehicleType = ChassisType.Coupe;
            //        break;
            //    case "convertible":
            //        vehicleType = ChassisType.Convertible;
            //        break;
            //    case "passenger minibus":
            //        vehicleType = ChassisType.Passenger_minibus;
            //        break;
            //    case "combi minibus":
            //        vehicleType = ChassisType.Combi_minibus;
            //        break;
            //    case "freight minibus":
            //        vehicleType = ChassisType.Freight_minibus;
            //        break;
            //    case "commercial":
            //        vehicleType = ChassisType.Commercial;
            //        break;
            //    default:
            //        vehicleType = default;
            //        break;
            //}

            //SortingCriteria sortBy = Sorting.GetSortingCriteria((string)sortByCombobox.SelectedItem);

            //bool sortAscending = sortAscRadioBtn.Checked;

            //_resultList = await new VehicleSearch(_frontendApi).searchVehicles(brandTextbox.Text,
            //                                          modelTextbox.Text,
            //                                          fuelType,
            //                                          vehicleType,
            //                                          sortBy,
            //                                          sortAscending,
            //                                          usedRadioBtn.Checked,
            //                                          newRadioBtn.Checked,
            //                                          Convert.ToInt32(lowerPriceTextbox.Value),
            //                                          Convert.ToInt32(upperPriceTextbox.Value),
            //                                          Convert.ToInt32(lowerYearTextbox.Value),
            //                                          Convert.ToInt32(upperYearTextbox.Value));

            // after we get the results back from server, we show them
            //searchResultsPage.Visible = true;
        }

        private void ResetSearchButton_Click(object sender, EventArgs e)
        {
            // reset everything on page to default values
            vehicleTypeCombobox.SelectedIndex = 0;
            brandTextbox.ResetText();
            modelTextbox.ResetText();
            lowerPriceTextbox.ResetText();
            upperPriceTextbox.ResetText();
            newRadioBtn.Checked = false;
            usedRadioBtn.Checked = false;
            lowerYearTextbox.ResetText();
            upperYearTextbox.ResetText();
            fuelTypeCombobox.SelectedIndex = 0;
            sortByCombobox.SelectedIndex = 0;
            sortDescRadioBtn.Checked = true;
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
