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
        // need to prepare this for use as a search results page

        private readonly CarFilters _filters;
        private SortingCriteria _sorting;
        private bool _sortAsc;
        //static Random rnd;
        public int AdsInPage = 15;
        private int _currentPageNumber = 1;

        // a list to store all car ads in all pages
        private readonly List<CarAdMinimal[]> _adList = new List<CarAdMinimal[]>();


        public BrowsePage()
        {
            InitializeComponent();
            sortResultsByCombobox.SelectedIndex = 0;
            SortingChanged();
        }


        //public BrowsePage(CarFilters carFilters = null, SortingCriteria? sortBy = default, bool? sortAsc = default)
        //{
        //    filters = carFilters;

        //    InitializeComponent();

        //    if (sortBy != default)
        //    {
        //        sorting = (SortingCriteria)sortBy;
        //        sortResultsByCombobox.SelectedItem = Sorting.GetSortObj(sorting);
        //        if(sortAsc != default)
        //        {
        //            this.sortAsc = (bool)sortAsc;
        //        }
        //    }
        //    else
        //    {
        //        sortResultsByCombobox.SelectedIndex = 0;
        //    }
        //    sortingChanged();
        //}

        // this method sets nextPageButton.Enabled property
        private void ShowCarList()
        {
            // clear main panel to load other ads
            mainPanel.Controls.Clear();

            // enable "next page" button. It might get disabled later in the method, so we cannot do this later
            nextPageButton.Enabled = true;

            // if we are one the first page for the first time
            if (_adList.Count == 0)
            {
                CarAdMinimal[] carAds = GetMinimalVehicleAds(0, AdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    nextPageButton.Enabled = false;
                    // does Api return null if it gets an empty list from server?
                    // if not, then we should display network error
                    return;
                }
                _adList.Add(carAds);
            }

            // since prefetch is happening, we need to check if we are on the last populated page to disable "next" button if neccessary
            if (_currentPageNumber == _adList.Count)
            {
                // if we are on the last page, we fetch more vehicles to show
                CarAdMinimal[] carAds = GetMinimalVehicleAds(AdsInPage * _currentPageNumber, AdsInPage);
                if (carAds == null || carAds.Length == 0)
                {
                    // since the next page is empty, next page button should be disabled
                    nextPageButton.Enabled = false;
                }
                else
                {
                    _adList.Add(carAds);
                }
            }

            CarAdMinimal[] pageToShow = _adList[_currentPageNumber - 1];

            // try to display only as many ads as there are in the page
            foreach (CarAdMinimal ad in pageToShow)
            {
                mainPanel.Controls.Add(ad);
            }
        }

        private CarAdMinimal[] GetMinimalVehicleAds(int startIndex, int amount)
        {
            List<Car> vehicles;
            if (_filters != null)
            {
                vehicles = Api.SearchVehicles(_filters, _sorting, _sortAsc, startIndex, amount);
            }
            else
            {
                //sorting = Sorting.getSortingCriteria((string)sortResultsByCombobox.SelectedItem);
                vehicles = Api.SortBy(_sorting, startIndex, amount, _sortAsc);
            }
            return Converter.vehicleListToAds(vehicles);
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
            //nextPageButton.Enabled = canShowMoreAds;
        }

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            // this is not needed as it is already enforced
            //if (currentPageNumber > 1)
            //{
            mainPanel.AutoScrollPosition = new Point(0, 0);
            _currentPageNumber--;
            if (_currentPageNumber == 1)
            {
                previousPageButton.Enabled = false;
            }
            pageNumberLabel.Text = _currentPageNumber.ToString();
            ShowCarList();
            //nextPageButton.Enabled = true;
            //}
        }

        private void SortingChanged()
        {
            // set SortingCriteria and sortAsc
            _sorting = Sorting.GetSortingCriteria((string)sortResultsByCombobox.SelectedItem);
            _sortAsc = sortAscRadioButton.Checked;

            // clear current ads, since they are obsolete
            _adList.Clear();

            // start from page 1
            _currentPageNumber = 1;
            ShowCarList();
        }
        private void SortingChanged(object sender, EventArgs e)
        {
            SortingChanged();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            SortingChanged();
        }
    }
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
//private CarAdMinimal[] GenerateAds(int carAmount)
//{
//    CarAdMinimal[] carAds = new CarAdMinimal[carAmount];

//    for (int i = 0; i < carAmount; i++)
//    {
//        carAds[i] = new CarAdMinimal(GenerateRandomCar());
//    }
//    return carAds;
//}

//// generate random car ad
//private Car GenerateRandomCar()
//{
//    string[] carBrands = { "BMW", "Audi", "Fiat" };
//    string[] carModels = { "Vienas", "Du", "Trys" };
//    string[] images = { Converter.ConvertImageToBase64(Resources.branson_f42c_akcija_f47cn) };
//    Car newCar = new Car(uploaderUsername: "Andrius", uploadDate: DateTime.Now, price: 123,
//        brand: "alfa", model: "beta", true, dateOfPurchase: new Month { year = 2000, month = 10 }, engine: new Engine { hp = 100, kw = 60, volume = 1.2f },
//        fuelType: FuelType.petrol, chassisType: ChassisType.station_wagon, color: "juoda", gearboxType: GearboxType.automatic, totalKilometersDriven: 100000,
//        driveWheels: DriveWheels.rear, defects: new string[] { "dauzta mazda" }, steeringWheelPosition: SteeringWheelPosition.left,
//        numberOfDoors: NumberOfDoors.fourFive, numberOfCylinders: 4, numberOfGears: 6, seats: 5, nextVehicleInspection: new Month { year = 2022, month = 5 },
//        wheelSize: "R16", weight: 1300, euroStandard: EuroStandard.Euro3, originalPurchaseCountry: "Vokietija", vin: "cgfb13uj5b4gri53",
//        additionalProperties: new string[] { "a", "b" }, images: images, comment: "my comment");

//    newCar.Model = carModels[rnd.Next(0, carModels.Length)];
//    newCar.Brand = carBrands[rnd.Next(0, carBrands.Length)];
//    newCar.Price = rnd.Next(1000, 20000);
//    newCar.Engine = new Engine();
//    newCar.Comment = "Komentaras";
//    newCar.Images = images;
//    return newCar;
//}