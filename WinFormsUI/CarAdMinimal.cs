using CarEngine.Forms;
using DataTypes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        Car carInfo;
        Color selectedAdColor = Color.Aquamarine;
        Color normalAdColor = Color.FloralWhite;

        public CarAdMinimal(Car carInfo)
        {
            InitializeComponent();
            this.carInfo = carInfo;
            BackColor = normalAdColor;

            carModel.Text = $"{carInfo.Brand} {carInfo.Model}";
            price.Text = carInfo.Price.ToString() + "€";
            additionInfo.Text = carInfo.Engine.kw.ToString() + "kW";
            additionInfo.Text += $" \"{carInfo.Comment}\"";
            if (carInfo.Images != null && carInfo.Images.Length > 0)
            {
                carImage.Image = Converter.Base64ToImg(carInfo.Images[0]);
            }

            //vehicleGraphics = CreateGraphics();
        }

        private void adWindowClosed(object sender, EventArgs e)
        {
            BackColor = normalAdColor;
        }

        private void openCarWindow()
        {
            BackColor = selectedAdColor;
            CarForm form = new CarForm(carInfo);
            form.FormClosed += adWindowClosed;
            form.Show();
        }

        private void carImage_Click(object sender, EventArgs e)
        {
            openCarWindow();
        }

        private void carModel_Click(object sender, EventArgs e)
        {
            openCarWindow();
        }

        private void price_Click(object sender, EventArgs e)
        {
            openCarWindow();
        }

        private void additionInfo_Click(object sender, EventArgs e)
        {
            openCarWindow();
        }
    }
}
