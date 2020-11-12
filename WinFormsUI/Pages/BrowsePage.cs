using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class BrowsePage : UserControl
    {
        private readonly bool _isSearchResultsPage;
        private readonly CarFilters _filters;
        private string _selectedSortItem;
        private bool _sortAsc;
        private readonly int _adsInPage = Constants.AdsInBrowsePage;
        private int _currentPageNumber = 1;
        private readonly EnumParser _parser = new EnumParser();

        // this is used to track whether "next page" button should be enabled 
        private bool _nextPageButtonEnabled = false;

        // a list to store all car ads in all pages
        private readonly List<CarAdMinimal[]> _adList = new List<CarAdMinimal[]>();
        // instance of API
        private IApi _frontendApi;

        // This property MUST be set for this to work correctly
        [DefaultValue(null)]
        public IApi Api
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

                    // we only start loading the content once we get the api and userInfo
                    if (_userInfo != null)
                    {
                        SortingChanged();
                    }
                }
                else
                {
                    throw new Exception("Error while setting Api");
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

                    // we only start loading the content once we get the api and userInfo
                    if (_frontendApi != null)
                    {
                        SortingChanged();
                    }
                }
                else
                {
                    throw new Exception("Error while setting UserInfo");
                }
            }
        }

        public BrowsePage()
        {
            _isSearchResultsPage = false;

            InitializeComponent();
            sortResultsByCombobox.SelectedIndex = 0;
        }

        //  this constructor is needed to use this as a search results page
        public BrowsePage(CarFilters carFilters, string selectedSortItem, bool sortAsc, IApi api, UserInfo userInfo)
        {
            _frontendApi = api;
            _userInfo = userInfo;
            _isSearchResultsPage = true;
            _filters = carFilters;

            InitializeComponent();

            sortAscRadioButton.Checked = sortAsc;
            sortResultsByCombobox.SelectedItem = selectedSortItem;
            SortingChanged();
        }

        private async void ShowCarList()
        {
            // disable "refresh" and "sort" buttons for the duration of the load so that they cannot be abused by user
            refreshButton.Enabled = false;
            sortButton.Enabled = false;

            // clear main panel to load other ads
            mainPanel.Controls.Clear();

            // enable . It might get disabled later in the method, so we cannot do this later
            _nextPageButtonEnabled = true;

            // if we are on the first page for the first time
            if (_adList.Count == 0)
            {
                CarAdMinimal[] carAds = await GetMinimalVehicleAds(0, _adsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    refreshButton.Enabled = true;
                    sortButton.Enabled = true;
                    _nextPageButtonEnabled = false;
                    nextPageButton.Enabled = false;
                    return;
                }
                _adList.Add(carAds);
            }

            // if we are on the last populated page, we need to prefetch more data
            if (_currentPageNumber == _adList.Count)
            {
                // if we are on the last page, we fetch more vehicles to show
                CarAdMinimal[] carAds = await GetMinimalVehicleAds(_adsInPage * _currentPageNumber, _adsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    // since the next page is empty, next page button should be disabled
                    _nextPageButtonEnabled = false;
                }
                else
                {
                    _adList.Add(carAds);
                }
            }

            CarAdMinimal[] pageToShow = _adList[_currentPageNumber - 1];

            // try to display only as many ads as there are in the page
            mainPanel.Controls.AddRange(pageToShow);
            //for (int i = 0; i < pageToShow.Length; i++)
            //{
            //    mainPanel.Controls.Add(pageToShow[i]);

            //    // make ads selectable by tab (added 6 to make space for sorting buttons at the bottom)
            //    pageToShow[i].TabIndex = i + 6;
            //}
            nextPageButton.Enabled = _nextPageButtonEnabled;

            // re-enable "refresh" and "sort" buttons
            refreshButton.Enabled = true;
            sortButton.Enabled = true;
        }

        private async Task<CarAdMinimal[]> GetMinimalVehicleAds(int startIndex, int amount)
        {
            List<Car> vehicles;
            if (_isSearchResultsPage)
            {
                vehicles = await _frontendApi.SearchVehicles(_filters, _parser.GetSortingCriteria(_selectedSortItem), _sortAsc, startIndex, amount);
            }
            else
            {
                vehicles = await _frontendApi.GetSortedCars(_parser.GetSortingCriteria(_selectedSortItem), startIndex, amount, _sortAsc);
            }
            return Converter.VehicleListToAds(vehicles, _userInfo);
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber == 1)
            {
                previousPageButton.Enabled = true;
            }
            mainPanel.AutoScrollPosition = new Point(0, 0);
            _currentPageNumber++;
            pageNumberLabel.Text = _currentPageNumber.ToString();
            ShowCarList();
        }

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            mainPanel.AutoScrollPosition = new Point(0, 0);
            _currentPageNumber--;
            if (_currentPageNumber == 1)
            {
                previousPageButton.Enabled = false;
            }
            pageNumberLabel.Text = _currentPageNumber.ToString();
            ShowCarList();
        }

        private void SortingChanged()
        {
            // set SortingCriteria and sortAsc
            _selectedSortItem = (string)sortResultsByCombobox.SelectedItem;
            _sortAsc = sortAscRadioButton.Checked;

            // clear current ads, since they are obsolete
            _adList.Clear();

            // start from page 1
            _currentPageNumber = 1;
            ShowCarList();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SortingChanged();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            SortingChanged();
        }

        private void BrowsePage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                //refreshButton.Focus();
            }
        }
    }
}