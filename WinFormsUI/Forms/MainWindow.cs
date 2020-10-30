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

        public MainWindow()
        {
            InitializeComponent();

            // set window title
            Text = "Car Shopping Engine";
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // this causes the app to lock up while it fetches data from server
            SetActivePanel(browsePage);

            // browse button is "clicked"
            sidebarButton_Click(browseButton);

            // manually set the color of the button since I don't know how to raise button click event from here
            browseButton.ForeColor = _activeSidebarButtonTextColor;
            browseButton.BackColor = _activeSidebarButtonColor;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(browsePage);
            sidebarButton_Click(browseButton);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(searchPage);
            sidebarButton_Click(searchButton);
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(uploadPage);
            sidebarButton_Click(uploadButton);
        }

        private void FavoritesButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(profilePage);
            sidebarButton_Click(favoritesButton);
        }

        // this method must be called when any sidebar button is clicked as it set button colors
        private void sidebarButton_Click(Button button/*, EventArgs e*/)
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

            // this is OK as this method is called after SetActivePanel (since this was added to button click eventhandler later than button_Click)
            button.Enabled = false;
        }

        private void SetActivePanel(UserControl control)
        {
            // disable all panels
            searchPage.Visible = false;
            browsePage.Visible = false;
            uploadPage.Visible = false;
            profilePage.Visible = false;

            // enable all buttons, the callee must disable its own button after calling this method
            browseButton.Enabled = true;
            searchButton.Enabled = true;
            uploadButton.Enabled = true;
            favoritesButton.Enabled = true;

            // enable panel that's provided
            control.Visible = true;
        }
    }
}
