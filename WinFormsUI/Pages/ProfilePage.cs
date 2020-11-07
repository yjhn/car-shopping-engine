using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class ProfilePage : UserControl
    {
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
                    _userInfo.LikedCarListUpdated += LoadLikedCars;
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

        private async void LoadInfo()
        {
            if (_userInfo != null && _userInfo.Username != null && _frontendApi != null)
            {
                usernameLabel.Text = _userInfo.Username;
                LoadLikedCars();

                List<Car> uploadedCars = await _frontendApi.GetUploadedCars(_userInfo.Username, 0, 15);
                if (uploadedCars != null)
                {
                    uploadedAdsPanel.Controls.AddRange(Converter.VehicleListToAds(uploadedCars, _userInfo));
                }
            }
        }

        private void LoadLikedCars()
        {
            CarAdMinimal[] likedAdsList = Converter.VehicleListToAds(_userInfo.LikedCarList, _userInfo);
            likedAdsPanel.Controls.Clear();
            likedAdsPanel.Controls.AddRange(likedAdsList);
        }

        private void ProfilePage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadInfo();
            }
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
