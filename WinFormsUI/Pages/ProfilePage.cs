using CarEngine.Properties;
using DataTypes;
using System;
using System.Windows.Forms;
using Frontend;

namespace CarEngine.Pages
{
    public partial class ProfilePage : UserControl
    {
        private IApi _frontendApi;

        // This property MUST be set for this to work correctly
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
                brand: "alfa", model: "beta", true, dateOfPurchase: new YearMonth { Year = 2000, Month = 10 }, engine: new Engine { Hp = 100, Kw = 60, Volume = 1.2f },
                fuelType: FuelType.Petrol, chassisType: ChassisType.Station_wagon, color: "juoda", gearboxType: GearboxType.Automatic, totalKilometersDriven: 100000,
                driveWheels: DriveWheels.Rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.Left,
                numberOfDoors: NumberOfDoors.FourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new YearMonth { Year = 2022, Month = 5 },
                wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
                additionalProperties: new string[] { "a", "b" }, images: images, comment: "my comment");

            newCar.Model = "Vienas";
            newCar.Brand = "BMW";
            newCar.Price = 15000;
            newCar.Engine = new Engine();
            newCar.Comment = "Komentaras";
            newCar.Images = images;
            return newCar;
        }
    }
}
