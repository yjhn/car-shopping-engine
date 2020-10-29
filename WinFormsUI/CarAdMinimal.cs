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
        //Graphics vehicleGraphics;
        Color selectedAdColor = Color.Aquamarine;
        Color normalAdColor = Color.FloralWhite;

        public CarAdMinimal(Car carInfo)
        {
            InitializeComponent();
            BackColor = normalAdColor;

            this.carInfo = carInfo;

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
            //Rectangle r = ClientRectangle;
            //Point p = DisplayRectangle.Location;
            //p.Offset(20, 20);
            //Size s = DisplayRectangle.Size;
            //s.Width -= 40;
            //s.Height -= 40;
            //Rectangle rectangle = new Rectangle(p, s);
            //ControlPaint.DrawSelectionFrame(vehicleGraphics, true, ClientRectangle, rectangle, Color.White);


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
