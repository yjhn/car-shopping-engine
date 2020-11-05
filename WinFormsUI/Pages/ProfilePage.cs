using CarEngine.Properties;
using DataTypes;
using System;
using System.Windows.Forms;
using Frontend;
using System.ComponentModel;
using Test1;

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
                if (_frontendApi == null)
                {
                    _frontendApi = value;
                }
                else
                {
                    throw new Exception("Cannot set Api property more than once");
                }
            }
        }

        public ProfilePage()
        {
            InitializeComponent();
            profilePicture.Image = Resources.PikPng_com_profile_icon_png_805068;
            // --temporary
            uploadedPanel.Controls.Add(new CarAdMinimal(GenerateRandomCar()));
            favoriteAds.Controls.Add(new CarAdMinimal(GenerateRandomCar()));
        }

        private Car GenerateRandomCar()
        {
            string[] carBrands = { "BMW", "Audi", "Fiat" };
            string[] carModels = { "Vienas", "Du", "Trys" };
            string[] images = { Converter.ConvertImageToBase64(Resources.branson_f42c_akcija_f47cn) };
            Car newCar = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 123,
                brand: "alfa", model: "beta", true, dateOfPurchase: new YearMonth(2020, 2), engine: new Engine(100,60,1.2f, EngineType.W3),
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

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //UpdatePage();
        }

        private void UpdatePage()
        {
            //logoutBtn.Visible= (Program.UserToken == null)? false : true;


            //usernameLabel.Text = Program.user.Username;
            //uploadedLabel.Text = "Ads uploaded by " + Program.user.Username;
            //favoriteAdsLabel.Text = Program.user.Username + " favorite Ads";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Program.UserToken = null;
            UpdatePage();
        }
    }
}
