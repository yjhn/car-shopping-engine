using CarEngine.Properties;
using DataTypes;
using Frontend;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class SearchPage : UserControl
    {
        private int _resultspageNr = 1;
        private IApiWrapper _frontendApi;
        private readonly EnumParser _parser = new EnumParser();

        // tab close button image
        private readonly Image _closeImage = Utilities.ResizeImage(Resources.tabclose, 15, 15);

        // This property MUST be set for this to work correctly
        [DefaultValue(null)]
        public IApiWrapper Api
        {
            get
            {
                return _frontendApi;
            }
            set
            {
                // _frontendApi can be set only once
                if (_frontendApi == null && value != null)
                {
                    _frontendApi = value;
                }
                else
                {
                    throw new Exception("Cannot set Api property more than once");
                }
            }
        }

        private UserInfo _userInfo;

        [DefaultValue(null)]
        public UserInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                // _userInfo can be set only once
                if (_userInfo == null && value != null)
                {
                    _userInfo = value;

                    // we only enable the search button once we get the api and userInfo
                    if (_frontendApi != null)
                    {
                        searchBtn.Enabled = true;
                    }
                }
                else
                {
                    throw new Exception("Error while setting UserInfo");
                }
            }
        }

        public SearchPage()
        {
            InitializeComponent();

            // set min and max allowed manufacture years
            lowerYearTextbox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            lowerYearTextbox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;
            higherYearTextbox.Minimum = VehiclePropertyConstants.MinVehicleManufactureYear;
            higherYearTextbox.Maximum = VehiclePropertyConstants.MaxVehicleManufactureYear;

            // set min and max allowed price
            lowerPriceTextbox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            lowerPriceTextbox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;
            higherPriceTextbox.Minimum = VehiclePropertyConstants.MinVehiclePrice;
            higherPriceTextbox.Maximum = VehiclePropertyConstants.MaxVehiclePrice;

            // default vehicle type: any
            vehicleTypeCombobox.SelectedIndex = 0;
            // default sorting: by upload date descending
            sortByCombobox.SelectedIndex = 0;
            // default fuel type: any
            fuelTypeCombobox.SelectedIndex = 0;

            // make NumericUpDown appear empty
            lowerYearTextbox.Text = "";
            higherYearTextbox.Text = "";
            lowerPriceTextbox.Text = "";
            higherPriceTextbox.Text = "";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FuelType? fuelType = _parser.GetFuelType((string)fuelTypeCombobox.SelectedItem);

            ChassisType? chassisType = _parser.GetChassisType((string)vehicleTypeCombobox.SelectedItem);

            //SortingCriteria sortBy = EnumParser.GetSortingCriteria((string)sortByCombobox.SelectedItem);

            string brand = brandTextbox.Text.ToLower();
            string model = modelTextbox.Text.ToLower();
            int lowerPrice = (int)lowerPriceTextbox.Value;
            int higherPrice = (int)higherPriceTextbox.Value;
            int lowerYear = (int)lowerYearTextbox.Value;
            int higherYear = (int)higherYearTextbox.Value;

            CarFilters filters = new CarFilters()
            {
                ChassisType = chassisType,
                Brand = (brand == "") ? null : brand,
                Model = (model == "") ? null : model,
                PriceFrom = (lowerPrice == VehiclePropertyConstants.MinVehiclePrice) ? default(int?) : lowerPrice,
                PriceTo = (higherPrice == VehiclePropertyConstants.MinVehiclePrice) ? default(int?) : higherPrice,
                Used = usedRadioBtn.Checked ? true : (newRadioBtn.Checked ? false : default(bool?)),
                YearFrom = (lowerYear == VehiclePropertyConstants.MinVehicleManufactureYear) ? default(int?) : lowerYear,
                YearTo = (higherYear == VehiclePropertyConstants.MaxVehicleManufactureYear) ? default(int?) : higherYear,
                FuelType = fuelType
            };

            // create new tab for search results
            BrowsePage searchResultsTab = new BrowsePage(filters, (string)sortByCombobox.SelectedItem, sortAscRadioBtn.Checked, _frontendApi, _userInfo)
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoSize = false
            };
            TabPage resultsTab = new TabPage("results " + _resultspageNr++);
            resultsTab.Controls.Add(searchResultsTab);
            searchAndResultsTabs.TabPages.Add(resultsTab);
            searchAndResultsTabs.SelectTab(searchAndResultsTabs.TabPages.Count - 1);
        }

        private void ResetSearchButton_Click(object sender, EventArgs e)
        {
            // reset everything on page to default values
            vehicleTypeCombobox.SelectedIndex = 0;
            brandTextbox.ResetText();
            modelTextbox.ResetText();
            lowerPriceTextbox.ResetText();
            higherPriceTextbox.ResetText();
            newRadioBtn.Checked = false;
            usedRadioBtn.Checked = false;
            lowerYearTextbox.ResetText();
            higherYearTextbox.ResetText();
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

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {

            //try
            //{
            var tabPage = this.searchAndResultsTabs.TabPages[e.Index];
            var tabRect = this.searchAndResultsTabs.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);
            // draw Close button to all TabPages
            if (e.Index > 0)
            {
                e.Graphics.DrawImage(_closeImage,
                    (tabRect.Right - _closeImage.Width),
                    tabRect.Top + (tabRect.Height - _closeImage.Height) / 2);
            }
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                tabRect, tabPage.ForeColor, TextFormatFlags.Left);
            //}
            //catch (Exception ex) { throw new Exception(ex.Message); }
        }


        private void TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            // Process MouseDown event for every tab except for the first (close tab if user clicks on close button)
            for (var i = 1; i < searchAndResultsTabs.TabPages.Count; i++)
            {
                var tabRect = searchAndResultsTabs.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var imageRect = new Rectangle(
                    (tabRect.Right - _closeImage.Width),
                    (tabRect.Top + (tabRect.Height - _closeImage.Height) / 2),
                    _closeImage.Width,
                    _closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    searchAndResultsTabs.TabPages.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
