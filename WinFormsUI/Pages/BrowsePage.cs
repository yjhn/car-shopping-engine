using CarEngine.Properties;
using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{

    public partial class BrowsePage : UserControl
    {
        // need to add the ability to refresh page

        static Random rnd;
        public int carAmount = 15;
        private int pageNumber = 1;
        private bool canShowMoreAds = true;

        // a list to store all car ads in all pages
        List<CarAdMinimal[]> minimalAdList = new List<CarAdMinimal[]>();

        public BrowsePage()
        {
            InitializeComponent();
            sortResultsByCombobox.SelectedIndex = 0;
        }

        private void ShowCarList(int pageNr)
        {
            if (mainPanel.Controls.Count != 0)
            {
                mainPanel.Controls.Clear();
            }

            if (pageNr > minimalAdList.Count)
            {
                //CarAdMinimal[] carAds = GetMinimalVehicleAds(15 * (pageNr - 1), carAmount);
                //if(carAds == null)
                //{
                //    canShowMoreAds = false;
                //    return;
                //}

                // test
                CarAdMinimal[] carAds = GenerateAds(carAmount);
                // test

                minimalAdList.Add(carAds);
            }

            CarAdMinimal[] pageToShow = minimalAdList[pageNr - 1];

            // cannot display more ads if the last page is not full, so the "next" button should be disabled
            canShowMoreAds = !(pageToShow.Length < carAmount);
            // try to display only as many ads as there are in the page
            for (int i = 0; i < pageToShow.Length; i++)
            {
                mainPanel.Controls.Add(pageToShow[i]);
            }
        }

        private CarAdMinimal[] GetMinimalVehicleAds(int startIndex, int amount)
        {
            SortingCriteria sortBy = Sorting.getSortingCriteria((string)sortResultsByCombobox.SelectedItem);
            var adList = Converter.vehicleListToAds(Api.SortBy(sortBy/*, sortAscRadioButton.Checked*/, startIndex, amount));
            if (adList == null)
            {
                return null;
            }
            return adList;
        }

        //private void ShowCarList(int pageNr)
        //{
        //    if (mainPanel.Controls.Count != 0)
        //    {
        //        mainPanel.Controls.Clear();
        //    }

        //    if (pageNr > minimalAdList.Count)
        //    {
        //        //cia reiktu pakeist i GetCars per API vietoj GenerateAds()
        //        CarAdMinimal[] carAds = GenerateAds(carAmount);
        //        minimalAdList.Add(carAds);
        //    }

        //    for (int i = 0; i < carAmount; i++)
        //    {
        //        mainPanel.Controls.Add(minimalAdList[pageNr - 1][i]);
        //    }
        //}

        //Sugeneruoja caradminimal array is random ads - laikinas metodas
        private CarAdMinimal[] GenerateAds(int carAmount)
        {
            CarAdMinimal[] carAds = new CarAdMinimal[carAmount];

            for (int i = 0; i < carAmount; i++)
            {
                carAds[i] = new CarAdMinimal(GenerateRandomCar());
            }
            return carAds;
        }

        //sukuria individualu random car ad - laikinas metodas
        private Car GenerateRandomCar()
        {
            string[] carBrands = { "BMW", "Audi", "Fiat" };
            string[] carModels = { "Vienas", "Du", "Trys" };
            string[] images = { Converter.ConvertImageToBase64(Resources.branson_f42c_akcija_f47cn) };
            //Car newCar = new Car();
            Car newCar = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 123,
                brand: "alfa", model: "beta", true, dateOfPurchase: new Month { year = 2000, month = 10 }, engine: new Engine { hp = 100, kw = 60, volume = 1.2f },
                fuelType: FuelType.petrol, chassisType: ChassisType.station_wagon, color: "juoda", gearboxType: GearboxType.automatic, totalKilometersDriven: 100000,
                driveWheels: DriveWheels.rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.left,
                numberOfDoors: NumberOfDoors.fourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new Month { year = 2022, month = 5 },
                wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
                additionalProperties: new string[] { "a", "b" }, images: new string[] { "0" }, comment: "my comment");

            newCar.Model = carModels[rnd.Next(0, carModels.Length)];
            newCar.Brand = carBrands[rnd.Next(0, carBrands.Length)];
            newCar.Price = rnd.Next(1000, 20000);
            newCar.Engine = new Engine();
            newCar.Comment = "Komentaras";
            newCar.Images = images;
            return newCar;
        }

        private void BrowsePage_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            ShowCarList(1);
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            if (pageNumber == 1)
            {
                previousPageButton.Enabled = true;
            }
            mainPanel.AutoScrollPosition = new Point(0, 0);
            pageNumber++;
            pageNumberLabel.Text = pageNumber.ToString();
            ShowCarList(pageNumber);
            nextPageButton.Enabled = canShowMoreAds;
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                mainPanel.AutoScrollPosition = new Point(0, 0);
                pageNumber--;
                if (pageNumber == 1)
                {
                    previousPageButton.Enabled = false;
                }
                pageNumberLabel.Text = pageNumber.ToString();
                ShowCarList(pageNumber);
                nextPageButton.Enabled = true;
            }
        }

        private void sortingChanged()
        {
            // send new request to server
            SortingCriteria sortBy = Sorting.getSortingCriteria((string)sortResultsByCombobox.SelectedItem);
            var adList = Converter.vehicleListToAds(Api.SortBy(sortBy/*, sortAscRadioButton.Checked*/, 0, carAmount));
            if (adList == null)
            {
                return;
            }
            if (minimalAdList.Count == 0)
            {
                minimalAdList.Add(adList);
            }
            else
            {
                minimalAdList[0] = adList;
            }
            ShowCarList(1);
            pageNumber = 1;
        }
        private void sortingChanged(object sender, EventArgs e)
        {
            this.sortingChanged();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            minimalAdList = new List<CarAdMinimal[]>();
            sortingChanged();
        }
    }
}
