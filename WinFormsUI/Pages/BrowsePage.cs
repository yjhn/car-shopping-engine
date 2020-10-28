using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DataTypes;
using CarEngine.Properties;
using Frontend;

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
            List<Car> vehicleAds = Api.GetCars(startIndex, amount);
            if(vehicleAds == null)
            {
                return null;
            }
            CarAdMinimal[] minimalAds = new CarAdMinimal[vehicleAds.Count];

            // might not get the amount of ads we asked for
            for (int i = 0; i < vehicleAds.Count; i++)
            {
                minimalAds[i] = new CarAdMinimal(vehicleAds[i]);
            }
            return minimalAds;
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
            Car newCar = new Car();
            newCar.Model = carModels[rnd.Next(0, carModels.Length)];
            newCar.Brand = carBrands[rnd.Next(0, carBrands.Length)];
            newCar.Price = (uint) rnd.Next(1000, 20000);
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
            if(pageNumber == 1)
            {
                previousPageButton.Enabled = true;
            }
            mainPanel.AutoScrollPosition = new Point(0,0);
            pageNumber++;
            pageNumberLabel.Text = pageNumber.ToString();
            ShowCarList(pageNumber);
            nextPageButton.Enabled = canShowMoreAds;
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            if(pageNumber > 1)
            {
                mainPanel.AutoScrollPosition = new Point(0, 0);
                pageNumber--;
                if(pageNumber == 1)
                {
                    previousPageButton.Enabled = false;
                }
                pageNumberLabel.Text = pageNumber.ToString();
                ShowCarList(pageNumber);
                nextPageButton.Enabled = true;
            }
        }
    }
}
