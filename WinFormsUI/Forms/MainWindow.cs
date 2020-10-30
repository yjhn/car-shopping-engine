using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test1
{
    public partial class MainWindow : Form
    {
        // create default colors for (in)active sidebar buttons
        readonly Color activeSidebarButtonColor = Color.AntiqueWhite;
        readonly Color activeSidebarButtonTextColor = Color.Black;
        readonly Color inactiveSidebarButtonColor = Color.Transparent;
        readonly Color inactiveSidebarButtonTextColor = Color.Transparent;

        public MainWindow()
        {
            InitializeComponent();

            // set window title
            Text = "Car Shopping Engine";

            // add event handler to sidebar buttons to make them change colour once clicked
            browseButton.Click += new System.EventHandler(sidebarButton_Click);
            searchButton.Click += new System.EventHandler(sidebarButton_Click);
            uploadButton.Click += new System.EventHandler(sidebarButton_Click);
            favoritesButton.Click += new System.EventHandler(sidebarButton_Click);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // this will probably cause the app to lock up while it fetches data from server
            SetActivePanel(browsePage);

            // disable the "clicked" button
            browseButton.Enabled = false;

            // manually set the color of the button since I don't know how to raise button click event from here
            browseButton.ForeColor = activeSidebarButtonTextColor;
            browseButton.BackColor = activeSidebarButtonColor;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(browsePage);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(searchPage);
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(uploadPage);
        }

        private void favoritesButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(profilePage);
        }

        // this method must be called when any sidebar button is clicked as it set button colors
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

            // this is OK as this method is called after SetActivePanel (since this was added to button click eventhandler later than button_Click)
            ((Button)sender).Enabled = false;
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
