using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class UploadPage : UserControl
    {
        private IApiWrapper _frontendApi;
        private readonly EnumParser _parser = new EnumParser();

        // This property MUST be set for this to work correctly
        [DefaultValue(null)]
        public IApiWrapper Api
        {
            get
            {
                return _frontendApi;
            }
            set
            {
                // _frontendApi can be set only once
                if (_frontendApi == null && value != null)
                {
                    _frontendApi = value;
                }
                else
                {
                    throw new Exception("Cannot set Api property more than once");
                }
            }
        }

        private UserInfo _userInfo;

        [DefaultValue(null)]
        public UserInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                // _userInfo can be set only once
                if (_userInfo == null && value != null)
                {
                    _userInfo = value;

                    // enable upload button once we get the api and userInfo
                    if (_frontendApi != null)
                    {
                        uploadButton.Enabled = true;
                    }
                }
                else
                {
                    throw new Exception("Error while setting UserInfo");
                }
            }
        }

        public UploadPage()
        {
            InitializeComponent();

            // default values for combo boxes: 
            typeComboBox.SelectedIndex = 0;
            fuelTypeComboBox.SelectedIndex = 0;
            driveWheelsComboBox.SelectedIndex = 0;
            gearboxTypeComboBox.SelectedIndex = 0;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            additionalImagesPanel.Controls.Clear();
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|" +
                            "All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName.ToString();
            }

            for (int i = 1; i < dialog.FileNames.Length; i++)
            {
                Size pictureSize = new Size(additionalImagesPanel.Height, additionalImagesPanel.Height);
                PictureBox picture = new PictureBox
                {
                    Size = pictureSize,
                    Location = new Point(additionalImagesPanel.Width - (i) * (pictureSize.Width + 5), 0),
                    Image = Image.FromFile(dialog.FileNames[i]),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = SystemColors.ControlLightLight
                };
                additionalImagesPanel.Controls.Add(picture);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            if (CheckIfFilled())
            {
                PushCar();
                ClearSelections();
            }
        }

        private void ResetDataButton_Click(object sender, EventArgs e)
        {
            ClearSelections();
        }

        private bool CheckIfFilled()
        {
            if (brandTextBox.Text.Length < 1)
            {
                DisplayErrorMessage("enter brand name");
                return false;
            }
            else if (modelTextBox.Text.Length < 1)
            {
                DisplayErrorMessage("enter model name");
                return false;
            }
            else if (!radioButtonNew.Checked && !radioButtonUsed.Checked)
            {
                DisplayErrorMessage("select whether its new or used");
                return false;
            }
            else if (!radioButtonLeftWheel.Checked && !radioButtonRightWheel.Checked)
            {
                DisplayErrorMessage("select whether wheel is on the left or the right side");
                return false;
            }
            else if (pictureBox1.Image == null)
            {
                DisplayErrorMessage("put some images");
                return false;
            }
            return true;
        }

        //surenka info apie automobili is visu info lauku ir ikelia per api 
        private async void PushCar()
        {
            Car uploadCar = new Car
            {
                UploaderUsername = _userInfo.Username,
                UploadDate = DateTime.Now,
                Price = Convert.ToInt32(priceBox.Value),
                Brand = modelTextBox.Text,
                Model = modelTextBox.Text,
                Used = radioButtonUsed.Checked,
                FuelType = (FuelType)_parser.GetFuelType((string)fuelTypeComboBox.SelectedItem),
                ChassisType = (ChassisType)_parser.GetChassisType((string)typeComboBox.SelectedItem),
                GearboxType = (GearboxType)_parser.GetGearboxType((string)gearboxTypeComboBox.SelectedItem),
                TotalKilometersDriven = Convert.ToInt32(priceBox.Value),
                DriveWheels = (DriveWheels)_parser.GetDriveWheels((string)driveWheelsComboBox.SelectedItem),
                Defects = new List<string> { defectsTextBox.Text },
                SteeringWheelPosition = radioButtonLeftWheel.Checked ? SteeringWheelPosition.Left : SteeringWheelPosition.Right,
                Images = GetImages()
            };
            if (await _userInfo.PostCar(uploadCar) == 0)
            {
                MessageBox.Show("Successfully uploaded", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to upload ad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //surenka visas nuotraukas, kurios yra parinktos at a given time
        private List<string> GetImages()
        {
            List<string> images = new List<string>(additionalImagesPanel.Controls.Count + 1)
            {
                // main image
                Utilities.ConvertImageToBase64(pictureBox1.Image)
            };
            // additional images
            foreach (PictureBox p in additionalImagesPanel.Controls)
            {
                images.Add(Utilities.ConvertImageToBase64(p.Image));
            }
            return images;
        }

        private void ClearSelections()
        {
            typeComboBox.SelectedIndex = 0;
            brandTextBox.ResetText();
            modelTextBox.ResetText();
            priceBox.ResetText();
            radioButtonNew.Checked = false;
            radioButtonUsed.Checked = false;
            radioButtonLeftWheel.Checked = false;
            radioButtonRightWheel.Checked = false;
            yearBox.ResetText();
            fuelTypeComboBox.SelectedIndex = 0;
            additionalImagesPanel.Controls.Clear();
            pictureBox1.Image = null;
            defectsTextBox.ResetText();
        }

        private static void DisplayErrorMessage(string text)
        {
            MessageBox.Show(text, "Wrong Information Input",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
