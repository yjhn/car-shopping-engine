using DataTypes;
using Frontend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CarEngine.Pages
{
    public partial class UploadPage : UserControl
    {
        private IApi _frontendApi;
        private EnumParser _parser = new EnumParser();

        // This property MUST be set for this to work correctly
        [DefaultValue(null)]
        public IApi Api
        {
            get
            {
                return _frontendApi;
            }
            set
            {
                // _frontendApi can be set only once
                if (_frontendApi == null)
                {
                    _frontendApi = value;
                }
                else
                {
                    throw new Exception("Cannot set Api property more than once");
                }
            }
        }

        public UploadPage()
        {
            InitializeComponent();
            // default types for combo boxes: 
            typeComboBox.SelectedIndex = 0;
            fuelTypeComboBox.SelectedIndex = 0;
            driveWheelsComboBox.SelectedIndex = 0;
            gearboxTypeComboBox.SelectedIndex = 0;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            additionalImagesPanel.Controls.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                            "All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = dialog.FileName.ToString();
            }

            for (int i = 1; i < dialog.FileNames.Count(); i++)
            {
                PictureBox picture = new PictureBox();
                picture.Size = new Size(additionalImagesPanel.Height, additionalImagesPanel.Height);
                picture.Location = new Point(additionalImagesPanel.Width - (i) * (picture.Width + 5), 0);
                picture.ImageLocation = dialog.FileNames[i];
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackColor = SystemColors.ControlLightLight;
                additionalImagesPanel.Controls.Add(picture);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            //temporary kokas :_)
            if (CheckIfFilled())
            {
                PushCar();
                ClearSelections();
            }
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
            /*else if (pictureBox1.Image == null)
            {
                DisplayErrorMessage("put some images");
                return false;
            }*/
            return true;
        }

        //surenka info apie automobili is visu info lauku ir ikelia per api 
        private void PushCar()
        {
            Car uploadCar = new Car
            {
                //----------------
                // ui shouldn't need to do this, this is a task for frontend
                UploaderUsername = "userTest",//change to current users name
                //----------------
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
                Defects = new string[] {defectsTextBox.Text},
                SteeringWheelPosition = radioButtonLeftWheel.Checked ? SteeringWheelPosition.Left : SteeringWheelPosition.Right,
                //Images = new string[] { Converter.ConvertImageToBase64(pictureBox1.Image)}
                    //^image uploadas neveikia, nutruksta connection su serveriu. not handled properly yet
            };
            _frontendApi.AddCar(uploadCar);
        }

        //surenka visas nuotraukas, kurios yra parinktos at a given time
        private string[] GetImages()
        {
            List<string> imagesList = new List<string>();
            //visas iš papildomu nuotrauku panel
            foreach (PictureBox picBox in additionalImagesPanel.Controls)
            {
                imagesList.Add(Converter.ConvertImageToBase64(picBox.Image));
            }
            //main didele nuotrauka
            imagesList.Add(Converter.ConvertImageToBase64(pictureBox1.Image));
            string[] returnas = imagesList.ToArray();
            return returnas;
                
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

        private void DisplayErrorMessage(string text)
        {
            MessageBox.Show(text, "Wrong Information Input",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
