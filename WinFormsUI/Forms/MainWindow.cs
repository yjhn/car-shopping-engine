﻿using Frontend;
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

        private bool _loginPageShow = false;

        public MainWindow()
        {
            // add method to handle no connection event to Api's delegate
            _api.NoServerResponse += NoConnection;

            InitializeComponent();

            // pass Api down
            browsePage.Api = _api;
            searchPage.Api = _api;
            uploadPage.Api = _api;
            profilePage.Api = _api;

            // start with Browse page activated
            SetActivePanel(browsePage);
            SidebarButtonClicked(browseButton);
        }

        // this works, but if connection reappears, currently nothing changes
        private void NoConnection()
        {
            Action a = new Action(() =>
            {
                SetActivePanel(networkErrorMessage);
                networkErrorMessage.BringToFront();
                browseButton.Enabled = false;
                searchButton.Enabled = false;
                uploadButton.Enabled = false;
                favoritesButton.Enabled = false;
                loginBtn.Enabled = false;
                logoutBtn.Enabled = false;
            });
            Invoke(a);
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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // login logic
            if (!_loginPageShow)
            {
                LoginScreen loginScreen = new LoginScreen(_api);
                loginScreen.Show();
                _loginPageShow = true;

                loginScreen.FormClosing += LoginScreen_FormClosing;
            }
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _loginPageShow = false;

            // actually we should get it from server, this is for testing
            // this should be done elsewhere
            //Program.UserToken = "user";
            //Program.user.Username = "Guest";

            userNameLabel.Text = Program.Username;

            // show log out button if user is now logged in
            // temporarily we will show it always
            logoutBtn.Visible = Program.UserToken != null;

            //UpdatePage();
            //((LoginScreen)sender).FormClosing -= LoginScreen_FormClosing;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            // logout logic

            logoutBtn.Visible = false;
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

        private void SetActivePanel(Control panel)
        {
            // disable all panels
            searchPage.Visible = false;
            browsePage.Visible = false;
            uploadPage.Visible = false;
            profilePage.Visible = false;

            // enable panel that's provided
            panel.Visible = true;
        }

        private void UserNameLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void LoginBtn_VisibleChanged(object sender, EventArgs e)
        {
            logoutBtn.Visible = !loginBtn.Visible;
        }

        private void LogoutBtn_VisibleChanged(object sender, EventArgs e)
        {
            loginBtn.Visible = !logoutBtn.Visible;
        }
    }
}
