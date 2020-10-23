using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form2 : Form
    {
        Color activeSidebarButtonColor = Color.AntiqueWhite;
        Color activeSidebarButtonTextColor = Color.Black;
        Color inactiveSidebarButtonColor = Color.Transparent;
        Color inactiveSidebarButtonTextColor = Color.Transparent;

        public Form2()
        {
            InitializeComponent();
            Load += Form2_load;


            // add event handler to sidebar buttons to make them change colour once clicked
            browseButton.Click += new System.EventHandler(sidebarButton_Click);
            searchButton.Click += new System.EventHandler(sidebarButton_Click);
            uploadButton.Click += new System.EventHandler(sidebarButton_Click);
            favoritesButton.Click += new System.EventHandler(sidebarButton_Click);
        }

        private void Form2_load(object sender, EventArgs e)
        {
            // this will probably cause the app to lock up while it fetches data from server
            SetActivePanel(browsePage1);
            browseButton.Enabled = false;
            browseButton.ForeColor = activeSidebarButtonTextColor;
            browseButton.BackColor = activeSidebarButtonColor;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(browsePage1);
            browseButton.Enabled = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(searchPage1);
            searchButton.Enabled = false;
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(uploadPage1);
            uploadButton.Enabled = false;
        }

        private void favoritesButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(favoritePage1);
            favoritesButton.Enabled = false;
        }

        private void sidebarButton_Click(object sender, EventArgs e)
        {
            browseButton.ForeColor = inactiveSidebarButtonTextColor;
            browseButton.BackColor = inactiveSidebarButtonColor;
            searchButton.ForeColor = inactiveSidebarButtonTextColor;
            searchButton.BackColor = inactiveSidebarButtonColor;
            uploadButton.ForeColor = inactiveSidebarButtonTextColor;
            uploadButton.BackColor = inactiveSidebarButtonColor;
            favoritesButton.ForeColor = inactiveSidebarButtonTextColor;
            favoritesButton.BackColor = inactiveSidebarButtonColor;

            ((Button)sender).ForeColor = activeSidebarButtonTextColor;
            ((Button)sender).BackColor = activeSidebarButtonColor;
        }

        private void SetActivePanel(UserControl control)
        {
            // disable all panels
            searchPage1.Visible = false;
            browsePage1.Visible = false;
            uploadPage1.Visible = false;
            favoritePage1.Visible = false;

            // enable all buttons, the callee must disable its own button after this method
            browseButton.Enabled = true;
            searchButton.Enabled = true;
            uploadButton.Enabled = true;
            favoritesButton.Enabled = true;

            // enable panel that's provided
            control.Visible = true;
        }
    }
}
