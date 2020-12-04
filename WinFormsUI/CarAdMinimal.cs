using DataTypes;
using Frontend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class CarAdMinimal : UserControl
    {
        private readonly Color _selectedAdColor = Settings.Default.selectedAdColor;
        private readonly Color _normalAdColor = Settings.Default.normalAdColor;

        private readonly Car _carInfo;
        private readonly UserInfo _userInfo;

        public CarAdMinimal(Car carInfo, UserInfo userInfo)
        {
            userInfo.LoginStateChanged += LoginStateChanged;
            _userInfo = userInfo;
            _carInfo = carInfo;

            InitializeComponent();

            LoginStateChanged();

            BackColor = _normalAdColor;

            carBrandModelBtn.Text = $"{carInfo.Brand} {carInfo.Model}";
            priceLabel.Text = carInfo.Price.ToString() + "€";

            if (carInfo.Engine != null)
            {
                additionalInfo.Text = carInfo.Engine.Kw.ToString() + "kW";
            }
            additionalInfo.Text += $" \"{carInfo.Comment}\"";
            if (carInfo.Images != null && carInfo.Images.Count > 0)
            {
                carImage.Image = Utilities.Base64ToImg(carInfo.Images[0]);
            }
        }

        private void LoginStateChanged()
        {
            // if user just logged out
            if (_userInfo.Username == null)
            {
                likeButton.Enabled = false;
                likeButton.Text = "❤";
            }
            else // if user just logged in
            {
                likeButton.Enabled = true;
                likeButton.Text = _userInfo.LikedAds.Contains(_carInfo.Id) ? "♥" : "❤";
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

        private void AdditionalInfo_Click(object sender, EventArgs e)
        {
            OpenCarWindow();
        }

        private void LikeButton_Click(object sender, EventArgs e)
        {
            // if user has not already liked this ad
            if (((Button)sender).Text == "❤")
            {
                ((Button)sender).Text = "♥";
                _userInfo.LikedAds.Add(_carInfo.Id);
            }
            else
            {
                ((Button)sender).Text = "❤";
                _userInfo.LikedAds.Remove(_carInfo.Id);
            }
        }
    }
}
