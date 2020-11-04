using CarEngine.Forms;
using DataTypes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        private readonly Car _carInfo;
        private readonly Color _selectedAdColor = Color.Aquamarine;
        private readonly Color _normalAdColor = Color.FloralWhite;

        public CarAdMinimal(Car carInfo)
        {
            InitializeComponent();
            _carInfo = carInfo;
            BackColor = _normalAdColor;

            carModel.Text = $"{carInfo.Brand} {carInfo.Model}";
            price.Text = carInfo.Price.ToString() + "€";
            //additionInfo.Text = carInfo.Engine.Kw.ToString() + "kW";
            additionInfo.Text += $" \"{carInfo.Comment}\"";
            if (carInfo.Images != null && carInfo.Images.Length > 0)
            {
                carImage.Image = Converter.Base64ToImg(carInfo.Images[0]);
            }
        }

        private void AdWindowClosed(object sender, EventArgs e)
        {
            BackColor = _normalAdColor;
        }

        private void OpenCarWindow()
        {
            BackColor = _selectedAdColor;
            CarForm form = new CarForm(_carInfo);
            form.FormClosed += AdWindowClosed;
            form.Show();
        }

        private void CarImage_Click(object sender, EventArgs e)
        {
            OpenCarWindow();
        }

        private void CarModel_Click(object sender, EventArgs e)
        {
            OpenCarWindow();
        }

        private void Price_Click(object sender, EventArgs e)
        {
            OpenCarWindow();
        }

        private void AdditionInfo_Click(object sender, EventArgs e)
        {
            OpenCarWindow();
        }
    }
}
