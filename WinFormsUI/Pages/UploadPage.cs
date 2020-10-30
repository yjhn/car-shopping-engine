using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace CarEngine.Pages
{
    public partial class UploadPage : UserControl
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        string imgLocation = "";


        private void browseButton_Click(object sender, EventArgs e)
        {
            additionalImagesPanel.Controls.Clear();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                            "All files (*.*)|*.*";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }

            for (int i = 1; i < dialog.FileNames.Count(); i++)
            {
                PictureBox picture = new PictureBox();
                picture.Size = new System.Drawing.Size(additionalImagesPanel.Height, additionalImagesPanel.Height);
                picture.Location = new System.Drawing.Point(additionalImagesPanel.Width - (i) * (picture.Width + 5), 0);
                picture.ImageLocation = dialog.FileNames[i];
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BackColor = SystemColors.ControlLightLight;
                additionalImagesPanel.Controls.Add(picture);
            }

        }
    }
}
