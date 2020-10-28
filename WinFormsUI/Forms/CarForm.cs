using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataTypes;
namespace CarEngine.Forms
{
    public partial class CarForm : Form
    {
        public CarForm(Car carInfo)
        {
            InitializeComponent();

            brand.Text = carInfo.Brand.ToUpper();
            model.Text = carInfo.Model.ToLower();
            engine.Text = $"{carInfo.Engine.engineType.ToString()} {carInfo.Engine.volume.ToString()} {carInfo.Engine.kw.ToString()}";

            age.Text = carInfo.DateOfPurchase.year.ToString() + "-" + carInfo.DateOfPurchase.month.ToString();
            price.Text = carInfo.Price.ToString()+"€";

            chassisType.Text = carInfo.ChassisType.ToString();
            color.Text = carInfo.Color;
            fuelType.Text = carInfo.FuelType.ToString();
            gearBoxType.Text = carInfo.GearboxType.ToString();
            weight.Text = carInfo.Weight.ToString();
            eurostandard.Text = carInfo.EuroStandard.ToString();
            vin.Text = carInfo.Vin;

            comment.Text = carInfo.Comment;

            if (carInfo.Images.Length > 0)
            {
                carMainImage.Image = Converter.Base64ToImg(carInfo.Images[0]);
            }

        }
    }
}
