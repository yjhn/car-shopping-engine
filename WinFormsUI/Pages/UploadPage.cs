using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "PNG files (*.png)|*.png|JPEG files(*.jpg)|*.jpg|All files(*.*)|(*.*)";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }
        }
    }
}
