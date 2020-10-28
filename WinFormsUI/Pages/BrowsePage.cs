using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DataTypes;
using CarEngine.Properties;

namespace CarEngine
{
    
    public partial class BrowsePage : UserControl
    {
        static Random rnd;
        public int carAmount = 15;
        public static int pageNumber = 1;

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
            //cia reiktu pakeist i GetCars per API vietoj GenerateAds()
            
            if (pageNr > minimalAdList.Count)
            {
                CarAdMinimal[] carAds = GenerateAds(carAmount);
                minimalAdList.Add(carAds);
            }

            for (int i = 0; i < carAmount; i++)
            {
                mainPanel.Controls.Add(minimalAdList[pageNr - 1][i]);
            }
        }

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
            }
        }
    }
}
