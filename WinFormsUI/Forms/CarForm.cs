using DataTypes;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class CarForm : Form
    {
        // add ability to delete cars from this form

        public CarForm(Car carInfo)
        {
            InitializeComponent();

            if (carInfo.Brand != null)
            {
                brand.Text = carInfo.Brand.ToUpper();
            }
            else
            {
                brand.Visible = false;
            }
            if (carInfo.Model != null)
            {
                model.Text = carInfo.Model.ToLower();
            }
            else
            {
                model.Visible = false;
            }

            if (carInfo.Engine != null)
            {
                engine.Text = $"{carInfo.Engine.Type} {carInfo.Engine.Volume} {carInfo.Engine.Kw}";
            }
            else
            {
                engine.Visible = false;
            }

            if (carInfo.DateOfPurchase != null)
            {
                age.Text = carInfo.DateOfPurchase.Year.ToString() + "-" + carInfo.DateOfPurchase.Month.ToString();
            }
            else
            {
                age.Visible = false;
            }

            if (carInfo.Price != 0)
            {
                price.Text = carInfo.Price.ToString() + "€";
            }
            else
            {
                price.Visible = false;
            }
            chassisType.Text = carInfo.ChassisType.ToString();

            if (carInfo.Color != null)
            {
                color.Text = carInfo.Color;
            }
            else
            {
                color.Visible = false;
            }

            fuelType.Text = carInfo.FuelType.ToString();

            gearBoxType.Text = carInfo.GearboxType.ToString();

            if (carInfo.Weight != 0)
            {
                weight.Text = carInfo.Weight.ToString();
            }
            else
            {
                weight.Visible = false;
            }
            eurostandard.Text = carInfo.EuroStandard.ToString();

            if (carInfo.Vin != null)
            {
                vin.Text = carInfo.Vin;
            }
            else
            {
                vin.Visible = false;
            }

            if (carInfo.Comment != null)
            {
                comment.Text = carInfo.Comment;
            }
            else
            {
                comment.Visible = false;
            }


            if (carInfo.Images != null && carInfo.Images.Count > 0)
            {
                foreach (var i in carInfo.Images)
                {
                    PictureBox pic = new PictureBox
                    {
                        Image = Utilities.Base64ToImg(i),
                        SizeMode = PictureBoxSizeMode.Zoom,//447; 407
                        Size = new Size(447, 407)
                    };
                    flowLayoutPanel2.Controls.Add(pic);
                }
                carMainImage.Image = Utilities.Base64ToImg(carInfo.Images[0]);
            }

        }
    }
}
