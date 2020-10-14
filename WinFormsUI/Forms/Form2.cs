using CarEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += Form2_load;

            browsePage1.Controls.Add(new CarAdMinimal("ADasd", 489, "V65", "Vairavo moteris"));


        }

        private void Form2_load(object sender, EventArgs e)
        {
            SetActivePanel(browsePage1);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(browsePage1);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(searchPage1);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(uploadPage1);
        }

        private void favoritesButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(favoritePage1);
        }

        private void SetActivePanel(UserControl control1)
        {
            //disable all panels
            searchPage1.Visible = false;
            browsePage1.Visible = false;
            uploadPage1.Visible = false;
            favoritePage1.Visible = false;


            //enable panel thats provided
            control1.Visible = true;
        }
    }
}
