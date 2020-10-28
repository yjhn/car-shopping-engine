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

            if (carInfo.Brand != null)
            {
                brand.Text = carInfo.Brand.ToUpper();
            } else
            {
                brand.Visible = false;
            }
            if (carInfo.Model != null)
            {
                model.Text = carInfo.Model.ToLower();
            }else
            {
                model.Visible = false;
            }

            if (carInfo.Engine != null)
            {
                engine.Text = $"{carInfo.Engine.engineType.ToString()} {carInfo.Engine.volume.ToString()} {carInfo.Engine.kw.ToString()}";
            } else
            {
                engine.Visible = false;
            }

            if (carInfo.DateOfPurchase != null)
            {
                age.Text = carInfo.DateOfPurchase.year.ToString() + "-" + carInfo.DateOfPurchase.month.ToString();
            } else
            {
                age.Visible = false;
            }

            if (carInfo.Price != null)
            {
                price.Text = carInfo.Price.ToString() + "€";
            }
            else
            {
                price.Visible = false;
            }

            if (carInfo.ChassisType != null)
            {
                chassisType.Text = carInfo.ChassisType.ToString();
            } else
            {
                chassisType.Visible = false;
            }

            if (carInfo.Color != null)
            {
                color.Text = carInfo.Color;
            } else
            {
                color.Visible = false;
            }

            if (carInfo.FuelType != null)
            {
                fuelType.Text = carInfo.FuelType.ToString();
            }
            else
            {
                fuelType.Visible = false;
            }

            if (carInfo.GearboxType != null)
            {
                gearBoxType.Text = carInfo.GearboxType.ToString();
            }else
            {
                gearBoxType.Visible = false;
            }

            if (carInfo.Weight != null)
            {
                weight.Text = carInfo.Weight.ToString();
            } else
            {
                weight.Visible = false;
            }

            if (carInfo.EuroStandard != null)
            {
                eurostandard.Text = carInfo.EuroStandard.ToString();
            } else
            {
                eurostandard.Visible = false;
            }

            if (carInfo.Vin != null)
            {
                vin.Text = carInfo.Vin;
            } else
            {
                vin.Visible = false;
            }

            if (carInfo.Comment != null)
            {
                comment.Text = carInfo.Comment;
            }else
            {
                comment.Visible = false;
            }


            if (carInfo.Images.Length > 0)
            {
                foreach(var i in carInfo.Images)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image= Converter.Base64ToImg(i);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;//447; 407
                    pic.Size = new Size(447, 407);
                    flowLayoutPanel2.Controls.Add(pic);
                }
                //carMainImage.Image = Converter.Base64ToImg(carInfo.Images[0]);
            }

        }
    }
}
