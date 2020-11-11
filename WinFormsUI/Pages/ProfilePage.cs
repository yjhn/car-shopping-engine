using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class ProfilePage : UserControl
    {
        private IApi _frontendApi;
        private readonly int _likedAdsInPage = Constants.AdsInLikedAdsPage;
        private readonly int _uploadedAdsInPage = Constants.AdsInUploadedAdsPage;
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
                _likedAdsPageNr = 1;
                _likedAdsPages.Clear();
                ShowLikedCars();
                _uploadedAdsPageNr = 1;
                _uploadedAdsPages.Clear();
                LoadUploadedCars();
            }
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
            /*
             * Strategy:
             *  ads liked in current session are kept in UserInfo
             *  all other liked ads are fetched here
             *  each time profile page is opened, the list from server is cleaned up (because the user might have unliked the ads he liked in previous sessions)
             *  then the lists from UserInfo and here are merged (more ads need to be prefetched tp know if next page button should be enabled)
             *  finally, they are shown to th user
             */

            // disable all buttons for the duration of the load
            likedAdsNextPageBtn.Enabled = false;
            likedAdsPrevPageBtn.Enabled = false;
            sortLikedAdsBtn.Enabled = false;

            // clear main panel to load other ads
            likedAdsPanel.Controls.Clear();

            // enable "next page" placeholder bool. It might get disabled later in the method, it will be used to set nextpagebutton.enabled property
            _nextLikedAdsPageBtnEnabled = true;

            // if we are one the first page for the first time
            if (_likedAdsPages.Count == 0)
            {
                // get cars liked in this session
                _adsLikedInCurrentSession = new List<Car>(); //_userInfo.CarsLikedInCurrentSession;
                //_nrOfAdsLikedInSession = _adsLikedInCurrentSession.Count;
                //_leftoverNrOfAdsLikedInSession = _nrOfAdsLikedInSession;

                if (_leftoverNrOfAdsLikedInSession < _likedAdsInPage)
                {
                    // send updated liked ads list to server
                    await _userInfo.UpdateLikedAds();
                    // not sure if this is going to work, it might not fetch the data before going forward
                    _adsLikedInCurrentSession.AddRange(await _frontendApi.GetSortedLikedCars(_userInfo.Token,/*SortingCrieteria, sortAscending*/ 0, _likedAdsInPage - _leftoverNrOfAdsLikedInSession));

                    //// remove currently unliked ads from list
                    //_adsLikedInCurrentSession.RemoveAll(car => !_userInfo.LikedAds.Contains(car.Id));

                    // if there are less ads liked in current session then can be displayed in one page, we set this to 0
                    //_leftoverNrOfAdsLikedInSession = 0;

                    // if the page is still not full, we should disable "next page" button
                    if (_adsLikedInCurrentSession.Count < _likedAdsInPage)
                    {
                        _nextLikedAdsPageBtnEnabled = false;
                        // if there is nothing to show, we return
                        if (_adsLikedInCurrentSession.Count == 0)
                        {
                            // if there are zero ads shown, we should not enable sorting
                            sortLikedAdsBtn.Enabled = true;
                            likedAdsNextPageBtn.Enabled = false;
                            // return if there is nothing to show
                            return;
                        }
                    }
                    // we add the ads we got to the liked ads panel
                    _likedAdsPages.Add(Converter.VehicleListToAds(_adsLikedInCurrentSession.Take(_likedAdsInPage).ToList(), _userInfo));

                    // clear current page ads from the list
                    _adsLikedInCurrentSession.Clear();
                }
                else
                {
                    // if there are more liked ads in current session than can fit on one page
                    // decrease the number of ads that were liked in current session by amount shown on this page
                    //_leftoverNrOfAdsLikedInSession -= _likedAdsInPage;

                    // we add the ads we got to the liked ads panel
                    _likedAdsPages.Add(Converter.VehicleListToAds(_adsLikedInCurrentSession.Take(_likedAdsInPage).ToList(), _userInfo));

                    // clear current page ads from the list
                    _adsLikedInCurrentSession = _adsLikedInCurrentSession.Skip(_likedAdsInPage).ToList();
                }
            }

            // if we are on the last populated page, and there are potentially more ads to get from server, we need to prefetch more data
            if (_likedAdsPageNr == _likedAdsPages.Count && _nextLikedAdsPageBtnEnabled)
            {
                //List<Car> likedCars;

                // calculate the start index for GetLIkedCars method. In order to know it, we need to know how many ads in total were liked in this session
                int startIndex = _likedAdsPageNr * _likedAdsInPage - _nrOfAdsLikedInSession;
                if (_leftoverNrOfAdsLikedInSession < _likedAdsInPage)
                {
                    // send updated liked ads list to server
                    await _userInfo.UpdateLikedAds();
                    // fetch more ads to make full page if there is not enough
                    _adsLikedInCurrentSession.AddRange(await _frontendApi.GetSortedLikedCars(_userInfo.Token, startIndex, _likedAdsInPage - _leftoverNrOfAdsLikedInSession)); //_userInfo.GetLikedCarsPage(_likedAdsPageNr);
                    if (_adsLikedInCurrentSession.Count == 0)
                    {
                        // since the next page is empty, next page button should be disabled
                        _nextLikedAdsPageBtnEnabled = false;
                    }
                    else
                    {
                        _likedAdsPages.Add(Converter.VehicleListToAds(_adsLikedInCurrentSession.Take(_likedAdsInPage).ToList(), _userInfo));
                    }
                    //_leftoverNrOfAdsLikedInSession = 0;
                }
                else
                {
                    _likedAdsPages.Add(Converter.VehicleListToAds(_adsLikedInCurrentSession.Take(_likedAdsInPage).ToList(), _userInfo));

                    _adsLikedInCurrentSession = _adsLikedInCurrentSession.Skip(_likedAdsInPage).ToList();
                    //_leftoverNrOfAdsLikedInSession -= _likedAdsInPage;
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



        private void ProfilePage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadInfo();
            }
        }



        private async void LoadUploadedCars()
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

            // if we are one the first page for the first time
            if (_uploadedAdsPages.Count == 0)
            {
                List<Car> uploadedCars = await _frontendApi.GetSortedUploadedCars(_userInfo.Username,/* SortingCriteria, sortAscending*/ 0, _uploadedAdsInPage);
                if (uploadedCars == null || uploadedCars.Count == 0)
                {
                    refreshUploadedAdsBtn.Enabled = true;
                    sortUploadedAdsBtn.Enabled = true;
                    _nextUploadedAdsPageBtnEnabled = false;
                    uploadedAdsNextPageBtn.Enabled = false;
                    return;
                }
                _uploadedAdsPages.Add(Converter.VehicleListToAds(uploadedCars, _userInfo));
            }

            // if we are on the last popuplated page, we need to prefetch more data
            if (_uploadedAdsPageNr == _uploadedAdsPages.Count)
            {
                // if we are on the last page, we fetch more vehicles to show
                List<Car> uploadedCars = await _frontendApi.GetSortedUploadedCars(_userInfo.Username, (_uploadedAdsPageNr - 1) * _uploadedAdsInPage, _uploadedAdsInPage);
                if (uploadedCars == null || uploadedCars.Count == 0)
                {
                    // since the next page is empty, next page button should be disabled
                    _nextUploadedAdsPageBtnEnabled = false;
                }
                else
                {
                    _uploadedAdsPages.Add(Converter.VehicleListToAds(uploadedCars, _userInfo));
                }
            }

            CarAdMinimal[] pageToShow = _uploadedAdsPages[_uploadedAdsPageNr - 1];

            // try to display only as many ads as there are in the page
            uploadedAdsPanel.Controls.AddRange(pageToShow);
            //for (int i = 0; i < pageToShow.Length; i++)
            //{
            //    mainPanel.Controls.Add(pageToShow[i]);

            //    // make ads selectable by tab (added 6 to make space for sorting buttons at the bottom)
            //    //pageToShow[i].TabIndex = i + 6;
            //}

            // enable some buttons
            uploadedAdsPrevPageBtn.Enabled = _likedAdsPageNr > 1;
            uploadedAdsNextPageBtn.Enabled = _nextUploadedAdsPageBtnEnabled;
            sortUploadedAdsBtn.Enabled = true;
            refreshUploadedAdsBtn.Enabled = true;
        }

        private void SortLikedAdsBtn_Click(object sender, EventArgs e)
        {
            // currently sorting does not work
        }

        private void sortUploadedAdsBtn_Click(object sender, EventArgs e)
        {
            // currently sorting does not work
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
