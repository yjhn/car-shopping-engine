using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class ProfilePage : UserControl
    {
        private IApi _frontendApi;
        private readonly int _likedAdsInPage = Constants.AdsInLikedAdsPage;
        private readonly int _uploadedAdsInPage = Constants.AdsInUploadedAdsPage;
        private readonly EnumParser _parser = new EnumParser();
        private int _likedAdsPageNr = 1;
        private int _uploadedAdsPageNr = 1;
        private bool _nextLikedAdsPageBtnEnabled = false;
        private bool _nextUploadedAdsPageBtnEnabled = false;
        private readonly List<CarAdMinimal[]> _likedAdsPages = new List<CarAdMinimal[]>();
        private readonly List<CarAdMinimal[]> _uploadedAdsPages = new List<CarAdMinimal[]>();
        private int _leftoverNrOfAdsLikedInSession { get; } = 0;
        private int _nrOfAdsLikedInSession { get; } = 0;
        private List<Car> _adsLikedInCurrentSession;

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

                    // we only start loading the content once we get the api and userInfo and we are logged in
                    if (_userInfo != null && _userInfo.Username != null)
                    {
                        LoadInfo();
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
                    _userInfo.LoginStateChanged += LoginStateChanged;

                    // we only start loading the content once we get the api and userInfo and we are logged in
                    if (_frontendApi != null && value.Username != null)
                    {
                        LoadInfo();
                    }
                }
                else
                {
                    throw new Exception("Error while setting UserInfo");
                }
            }
        }

        public ProfilePage()
        {
            InitializeComponent();
            sortLikedAdsByCombobox.SelectedIndex = 0;
            sortUploadedAdsByCombobox.SelectedIndex = 0;
        }

        private void LoginStateChanged()
        {
            likedAdsPanel.Controls.Clear();
            uploadedAdsPanel.Controls.Clear();
            // if user logs in we load their info
            if (_userInfo.Username != null)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            if (_userInfo != null && _userInfo.Username != null && _frontendApi != null)
            {
                usernameLabel.Text = _userInfo.Username;
                LoadLikedAds();
                LoadUploadedAds();
            }
        }

        private void LoadUploadedAds()
        {
            _uploadedAdsPageNr = 1;
            _uploadedAdsPages.Clear();
            ShowUploadedCars();
        }

        private void LoadLikedAds()
        {
            _likedAdsPageNr = 1;
            _likedAdsPages.Clear();
            ShowLikedCars();
        }

        /*
         * loading strategy:
         *  liked ads:
         *      check if UserInfo has enough ads for us to load anything
         *      maybe do some sort of prefetch?
         *      check if UserInfo has more ads than we currently need. If it does, enable "next page" button (else disable it)
         *      
         *  uploaded ads:
         *      similar to how BrowsePage loads stuff
         */

        // loads one page of liked cars
        //private void LoadLikedCars()
        //{
        //    // disable all buttons for the duration of the load
        //    likedAdsNextPageBtn.Enabled = false;
        //    likedAdsPrevPageBtn.Enabled = false;
        //    sortLikedAdsBtn.Enabled = false;

        //    List<Car> likedCars = _userInfo.GetLikedCarsPage(_likedAdsPageNr);
        //    if(likedCars == null)
        //    {
        //        // if there is nothing to load, then return
        //        likedAdsPrevPageBtn.Enabled = _likedAdsPageNr > 1;
        //        sortLikedAdsBtn.Enabled = true;
        //        return;
        //    }
        //    CarAdMinimal[] likedAdsList = Converter.VehicleListToAds(likedCars, _userInfo);
        //    likedAdsPanel.Controls.Clear();
        //    likedAdsPanel.Controls.AddRange(likedAdsList);

        //    // enable some buttons
        //    likedAdsPrevPageBtn.Enabled = _likedAdsPageNr > 1;
        //    //likedAdsNextPageBtn.Enabled = 
        //    sortLikedAdsBtn.Enabled = true;
        //}


        // loads one page of liked cars
        private async void ShowLikedCars()
        {
            // disable all buttons for the duration of the load
            likedAdsNextPageBtn.Enabled = false;
            likedAdsPrevPageBtn.Enabled = false;
            sortLikedAdsBtn.Enabled = false;

            // clear main panel to load other ads
            likedAdsPanel.Controls.Clear();

            // enable "next page" placeholder bool. It might get disabled later in the method, it will be used to set nextpagebutton.enabled property
            _nextLikedAdsPageBtnEnabled = true;

            // IMPORTANT: do not add this to liked ads list if user has already logged out!!! //

            // if we are on the first page for the first time
            if (_likedAdsPages.Count == 0)
            {
                CarAdMinimal[] carAds = await GetMinimalLikedVehicleAds(0, _likedAdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    sortLikedAdsBtn.Enabled = true;
                    _nextLikedAdsPageBtnEnabled = false;
                    likedAdsNextPageBtn.Enabled = false;
                    return;
                }
                _likedAdsPages.Add(carAds);
            }

            // if we are on the last popuplated page, we need to prefetch more data
            if (_likedAdsPageNr == _likedAdsPages.Count)
            {
                // if we are on the last page, we fetch more vehicles to show
                CarAdMinimal[] carAds = await GetMinimalLikedVehicleAds(_likedAdsInPage * _likedAdsPageNr, _likedAdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    // since the next page is empty, next page button should be disabled
                    _nextLikedAdsPageBtnEnabled = false;
                }
                else
                {
                    _likedAdsPages.Add(carAds);
                }
            }

            CarAdMinimal[] pageToShow = _likedAdsPages[_likedAdsPageNr - 1];

            // try to display only as many ads as there are in the page
            likedAdsPanel.Controls.AddRange(pageToShow);

            // enable some buttons
            likedAdsPrevPageBtn.Enabled = _likedAdsPageNr > 1;
            likedAdsNextPageBtn.Enabled = _nextLikedAdsPageBtnEnabled;
            sortLikedAdsBtn.Enabled = true;
        }

        private async Task<CarAdMinimal[]> GetMinimalLikedVehicleAds(int startIndex, int amount)
        {
            // update liked ads
            await _userInfo.UpdateLikedAds();

            // get sortingCriteria and sortAscending
            bool sortAsc = sortLikedAdsAscRdBtn.Checked;
            SortingCriteria sortBy = _parser.GetSortingCriteria((string)sortLikedAdsByCombobox.SelectedItem);

            List<Car> vehicles = await _frontendApi.GetSortedLikedCars(_userInfo.Token,sortBy,sortAsc, startIndex, amount);
            return Converter.VehicleListToAds(vehicles, _userInfo);
        }

        private async Task<CarAdMinimal[]> GetMinimalUploadedVehicleAds(int startIndex, int amount)
        {
            // get sortingCriteria and sortAscending
            bool sortAsc = sortUploadedAdsAscRdBtn.Checked;
            SortingCriteria sortBy = _parser.GetSortingCriteria((string)sortUploadedAdsByCombobox.SelectedItem);

            List<Car> vehicles = await _frontendApi.GetSortedUploadedCars(_userInfo.Username, sortBy, sortAsc, startIndex, amount);
            return Converter.VehicleListToAds(vehicles, _userInfo);
        }


        private void ProfilePage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadInfo();
            }
        }



        private async void ShowUploadedCars()
        {
            // disable all buttons for the duration of the load
            uploadedAdsNextPageBtn.Enabled = false;
            uploadedAdsPrevPageBtn.Enabled = false;
            sortUploadedAdsBtn.Enabled = false;
            refreshUploadedAdsBtn.Enabled = false;

            // clear main panel to load other ads
            uploadedAdsPanel.Controls.Clear();

            // enable "next page" button placeholder. Its value will be used to set the actual button.enabled proerty
            _nextUploadedAdsPageBtnEnabled = true;


            // IMPORTANT: do not add this to uploaded ads list if user has already logged out!!! //
            // will need to test with slow network (probably would be good enough to add a delay to server call task)

            // if we are on the first page for the first time
            if (_uploadedAdsPages.Count == 0)
            {
                CarAdMinimal[] carAds = await GetMinimalUploadedVehicleAds(0, _uploadedAdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    refreshUploadedAdsBtn.Enabled = true;
                    sortUploadedAdsBtn.Enabled = true;
                    _nextUploadedAdsPageBtnEnabled = false;
                    uploadedAdsNextPageBtn.Enabled = false;
                    return;
                }
                _uploadedAdsPages.Add(carAds);
            }

            // if we are on the last populated page, we need to prefetch more data
            if (_uploadedAdsPageNr == _uploadedAdsPages.Count)
            {
                // if we are on the last page, we fetch more vehicles to show
                CarAdMinimal[] carAds = await GetMinimalUploadedVehicleAds(_uploadedAdsInPage * _uploadedAdsPageNr, _uploadedAdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    // since the next page is empty, next page button should be disabled
                    _nextUploadedAdsPageBtnEnabled = false;
                }
                else
                {
                    _uploadedAdsPages.Add(carAds);
                }
            }


            CarAdMinimal[] pageToShow = _uploadedAdsPages[_uploadedAdsPageNr - 1];

            // try to display only as many ads as there are in the page
            uploadedAdsPanel.Controls.AddRange(pageToShow);

            // enable some buttons
            uploadedAdsPrevPageBtn.Enabled = _uploadedAdsPageNr > 1;
            uploadedAdsNextPageBtn.Enabled = _nextUploadedAdsPageBtnEnabled;
            sortUploadedAdsBtn.Enabled = true;
            refreshUploadedAdsBtn.Enabled = true;
        }

        private void SortLikedAdsBtn_Click(object sender, EventArgs e)
        {
            LoadLikedAds();
        }

        private void SortUploadedAdsBtn_Click(object sender, EventArgs e)
        {
            LoadUploadedAds();
        }

        private void RefreshUploadedAdsBtn_Click(object sender, EventArgs e)
        {
            LoadUploadedAds();
        }
    }
}


//private Car GenerateRandomCar()
//{
//    //string[] carBrands = { "BMW", "Audi", "Fiat" };
//    //string[] carModels = { "Vienas", "Du", "Trys" };
//    string[] images = { Converter.ConvertImageToBase64(Resources.branson_f42c_akcija_f47cn) };
//    Car newCar = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 123,
//        brand: "alfa", model: "beta", true, dateOfPurchase: new YearMonth(2020, 2), engine: new Engine(100, 60, 1.2f, EngineType.W3),
//        fuelType: FuelType.Petrol, chassisType: ChassisType.Station_wagon, color: "juoda", gearboxType: GearboxType.Automatic, totalKilometersDriven: 100000,
//        driveWheels: DriveWheels.Rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.Left,
//        numberOfDoors: NumberOfDoors.FourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new YearMonth(2022, 5),
//        wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
//        additionalProperties: new string[] { "a", "b" }, images: images, comment: "my comment");

//    newCar.Model = "Vienas";
//    newCar.Brand = "BMW";
//    newCar.Price = 15000;
//    newCar.Comment = "Komentaras";
//    newCar.Images = images;
//    return newCar;
//}
