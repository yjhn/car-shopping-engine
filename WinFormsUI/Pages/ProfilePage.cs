using CarEngine.Properties;
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
            profilePicture.Image = Resources.PikPng_com_profile_icon_png_805068;
        }

        private /*async*/ void LoadInfo()
        {
            if (_userInfo != null && _userInfo.Username != null && _frontendApi != null)
            {
                List<Car> likedCars = _userInfo.LikedCarList;
                List<bool> isLiked = Enumerable.Repeat(true, likedCars.Count).ToList();

                CarAdMinimal[] likedAdsList = Converter.VehicleListToAds(likedCars, _userInfo, isLiked);
                
                likedAdsPanel.Controls.Clear();
                likedAdsPanel.Controls.AddRange(likedAdsList);

                uploadedAdsPanel.Controls.Clear();

                // currently Api does not have this functionality
                //uploadedAdsPanel.Controls.AddRange(Converter.VehicleListToAds(_frontendApi. ,_userInfo))
            }

            // --temporary
            //uploadedPanel.Controls.Add(new CarAdMinimal(GenerateRandomCar(), _userInfo));
            //favoriteAds.Controls.Add(new CarAdMinimal(GenerateRandomCar(), _userInfo));
        }

        private Car GenerateRandomCar()
        {
            //string[] carBrands = { "BMW", "Audi", "Fiat" };
            //string[] carModels = { "Vienas", "Du", "Trys" };
            string[] images = { Converter.ConvertImageToBase64(Resources.branson_f42c_akcija_f47cn) };
            Car newCar = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 123,
                brand: "alfa", model: "beta", true, dateOfPurchase: new YearMonth(2020, 2), engine: new Engine(100, 60, 1.2f, EngineType.W3),
                fuelType: FuelType.Petrol, chassisType: ChassisType.Station_wagon, color: "juoda", gearboxType: GearboxType.Automatic, totalKilometersDriven: 100000,
                driveWheels: DriveWheels.Rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.Left,
                numberOfDoors: NumberOfDoors.FourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new YearMonth(2022, 5),
                wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
                additionalProperties: new string[] { "a", "b" }, images: images, comment: "my comment");

            newCar.Model = "Vienas";
            newCar.Brand = "BMW";
            newCar.Price = 15000;
            newCar.Comment = "Komentaras";
            newCar.Images = images;
            return newCar;
        }

        private void ProfilePicture_Click(object sender, EventArgs e)
        {
            // this should show profile info when called
            // currently profile info screen is not implemented
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
