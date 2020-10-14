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

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        public CarAdMinimal(string carModel, float price, string engine, string comment, string base64Image)
        {
            InitializeComponent();

            this.carModel.Text = carModel;
            this.price.Text = price.ToString() + "€";
            this.additionInfo.Text = engine;
            this.additionInfo.Text += " \"" + comment + "\"";
            carImage.Image = Converter.Base64ToImg(base64Image);
        }
    }
}
