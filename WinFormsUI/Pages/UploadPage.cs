using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DataTypes;
using Frontend;
using System.Windows.Forms.VisualStyles;

namespace CarEngine.Pages
{
    public partial class UploadPage : UserControl
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
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

        private void uploadButton_Click(object sender, EventArgs e)
        {
            //temporary kokas :_)
            Api.AddCar(GetAllCarInfo());
            ClearSelections();
        }

        //surenka info apie automobili is visu info lauku
        private Car GetAllCarInfo()
        {
            Car uploadCar = new Car();
            uploadCar.ChassisType = SetChassisType();
            uploadCar.Brand = brandTextBox.Text;
            uploadCar.Model = modelTextBox.Text;
            uploadCar.Price = Convert.ToInt32(priceBox.Value);
            uploadCar.Used = radioButtonUsed.Checked;
            uploadCar.FuelType = GetFuelType();
            uploadCar.Images = GetImages();
            return uploadCar;
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
            return imagesList.ToArray();
        }

        private ChassisType SetChassisType()
        {
            ChassisType vehicleType;
            switch (typeComboBox.SelectedItem)
            {
                case "any":
                    vehicleType = default;
                    break;
                case "station wagon":
                    vehicleType = ChassisType.station_wagon;
                    break;
                case "hatchback":
                    vehicleType = ChassisType.hatchback;
                    break;
                case "sedan":
                    vehicleType = ChassisType.sedan;
                    break;
                case "suv":
                    vehicleType = ChassisType.suv;
                    break;
                case "minivan":
                    vehicleType = ChassisType.minivan;
                    break;
                case "coupe":
                    vehicleType = ChassisType.coupe;
                    break;
                case "convertible":
                    vehicleType = ChassisType.convertible;
                    break;
                case "passenger minibus":
                    vehicleType = ChassisType.passenger_minibus;
                    break;
                case "combi minibus":
                    vehicleType = ChassisType.combi_minibus;
                    break;
                case "freight minibus":
                    vehicleType = ChassisType.freight_minibus;
                    break;
                case "commercial":
                    vehicleType = ChassisType.commercial;
                    break;
                default:
                    vehicleType = default;
                    break;
            }
            return vehicleType;
        }

        private FuelType GetFuelType()
        {
            FuelType fuelType;
            switch (fuelTypeComboBox.SelectedItem)
            {
                case "any":
                    fuelType = default;
                    break;
                case "petrol":
                    fuelType = FuelType.petrol;
                    break;
                case "diesel":
                    fuelType = FuelType.diesel;
                    break;
                case "electric":
                    fuelType = FuelType.electricity;
                    break;
                case "hybrid":
                    fuelType = FuelType.hybrid;
                    break;
                default:
                    fuelType = default;
                    break;
            }
            return fuelType;
        }

        private void ClearSelections()
        {
            typeComboBox.SelectedIndex = 0;
            brandTextBox.ResetText();
            modelTextBox.ResetText();
            priceBox.ResetText();
            radioButtonNew.Checked = false;
            radioButtonUsed.Checked = false;
            yearBox.ResetText();
            fuelTypeComboBox.SelectedIndex = 0;
            additionalImagesPanel.Controls.Clear();
            pictureBox1.Image = null;
        }
    }
}
