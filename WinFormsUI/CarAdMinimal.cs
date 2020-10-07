using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        public CarAdMinimal(string carModel, float price, string engine, string comment)
        {
            InitializeComponent();

            this.carModel.Text = carModel;
            this.price.Text = price.ToString() + "€";
            this.additionInfo.Text = engine;
            this.additionInfo.Text += " \"" + comment+ "\"";

        }




    }
}
