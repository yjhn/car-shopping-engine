using CarEngine.Properties;
using DataTypes;
using System;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class ProfilePage : UserControl
    {
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
                brand: "alfa", model: "beta", true, dateOfPurchase: new Month { year = 2000, month = 10 }, engine: new Engine { hp = 100, kw = 60, volume = 1.2f },
                fuelType: FuelType.petrol, chassisType: ChassisType.station_wagon, color: "juoda", gearboxType: GearboxType.automatic, totalKilometersDriven: 100000,
                driveWheels: DriveWheels.rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.left,
                numberOfDoors: NumberOfDoors.fourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new Month { year = 2022, month = 5 },
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
