using Frontend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test1
{
    public partial class MainWindow : Form
    {
        // create default colors for (in)active sidebar buttons
        private readonly Color _activeSidebarButtonColor = Color.AntiqueWhite;
        private readonly Color _activeSidebarButtonTextColor = Color.Black;
        private readonly Color _inactiveSidebarButtonColor = Color.Transparent;
        private readonly Color _inactiveSidebarButtonTextColor = Color.Transparent;

        // create the instance of Api that will be passed down to every page
        private readonly IApi _api = new Api();

        public MainWindow()
        {
            InitializeComponent();
            browsePage.Api = _api;

            // start with Browse page activated
            SetActivePanel(browsePage);
            SidebarButtonClicked(browseButton);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(browsePage);
            SidebarButtonClicked(browseButton);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(searchPage);
            SidebarButtonClicked(searchButton);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(uploadPage);
            SidebarButtonClicked(uploadButton);
        }

        private void FavoritesButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(profilePage);
            SidebarButtonClicked(favoritesButton);
        }

        // this method must be called when any sidebar button is clicked as it sets button colors
        private void SidebarButtonClicked(Button button)
        {
            browseButton.ForeColor = _inactiveSidebarButtonTextColor;
            browseButton.BackColor = _inactiveSidebarButtonColor;
            searchButton.ForeColor = _inactiveSidebarButtonTextColor;
            searchButton.BackColor = _inactiveSidebarButtonColor;
            uploadButton.ForeColor = _inactiveSidebarButtonTextColor;
            uploadButton.BackColor = _inactiveSidebarButtonColor;
            favoritesButton.ForeColor = _inactiveSidebarButtonTextColor;
            favoritesButton.BackColor = _inactiveSidebarButtonColor;

            button.ForeColor = _activeSidebarButtonTextColor;
            button.BackColor = _activeSidebarButtonColor;

            // enable all buttons
            browseButton.Enabled = true;
            searchButton.Enabled = true;
            uploadButton.Enabled = true;
            favoritesButton.Enabled = true;

            // disable the button that was clicked
            button.Enabled = false;
        }

        private void SetActivePanel(UserControl panel)
        {
            // disable all panels
            searchPage.Visible = false;
            browsePage.Visible = false;
            uploadPage.Visible = false;
            profilePage.Visible = false;

            // enable panel that's provided
            panel.Visible = true;
        }
    }
}
