using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using DataTypes;
using CarEngine.Forms;

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        Car carInfo;
        
        public CarAdMinimal(Car carInfo)
        {
            InitializeComponent();

            this.carInfo = carInfo;

            this.carModel.Text = $"{carInfo.Brand} {carInfo.Model}";
            this.price.Text = carInfo.Price.ToString() + "€";
            this.additionInfo.Text = carInfo.Engine.kw.ToString() +"kW";
            this.additionInfo.Text += " \"" + carInfo.Comment + "\"";
            if (carInfo.Images.Length > 0)
            {
                carImage.Image = Converter.Base64ToImg(carInfo.Images[0]);
            }
        }
         
        private void carImage_Click(object sender, EventArgs e)
        {
            CarForm form = new CarForm(carInfo);
            form.Show();

        }
    }
}
