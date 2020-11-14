using CarEngine;
using Frontend;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class MainWindow : Form
    {
        // create default colors for (in)active sidebar buttons
        private readonly Color _activeSidebarButtonColor = Constants.ActiveSidebarButtonColor;
        private readonly Color _activeSidebarButtonTextColor = Constants.ActiveSidebarButtonTextColor;
        private readonly Color _inactiveSidebarButtonColor = Constants.InactiveSidebarButtonColor;
        private readonly Color _inactiveSidebarButtonTextColor = Constants.InactiveSidebarButtonTextColor;

        private readonly IApi _api;
        private readonly UserInfo _userInfo;
        LoginScreen loginScreen;

        public MainWindow(IApi api, UserInfo userInfo)
        {
            _api = api;
            _userInfo = userInfo;

            // add method to handle no connection event to Api's delegate
            _api.NoServerResponse += NoConnection;

            InitializeComponent();

            // pass Api and UserInfo down
            browsePage.Api = _api;
            browsePage.UserInfo = _userInfo;
            searchPage.Api = _api;
            searchPage.UserInfo = _userInfo;
            uploadPage.Api = _api;
            uploadPage.UserInfo = _userInfo;
            profilePage.Api = _api;
            profilePage.UserInfo = _userInfo;
        }

        // this works, but if connection reappears, currently nothing changes
        private void NoConnection()
        {
            Action a = new Action(async () =>
            {
                SetActivePanel(networkErrorMessage);
                networkErrorMessage.BringToFront();
                Button[] disabledButtons = new Button[6];
                int btnCount = 0;
                if (browseButton.Enabled)
                {
                    browseButton.Enabled = false;
                    disabledButtons[btnCount++] = browseButton;
                }
                if (searchButton.Enabled)
                {
                    searchButton.Enabled = false;
                    disabledButtons[btnCount++] = searchButton;
                }
                if (uploadButton.Enabled)
                {
                    uploadButton.Enabled = false;
                    disabledButtons[btnCount++] = uploadButton;
                }
                if (profileButton.Enabled)
                {
                    profileButton.Enabled = false;
                    disabledButtons[btnCount++] = profileButton;
                }
                // close login screen if it is open
                if (loginScreen != null)
                {
                    loginScreen.Close();
                }
                if (loginBtn.Enabled)
                {
                    loginBtn.Enabled = false;
                    disabledButtons[btnCount++] = loginBtn;
                }
                if (logoutBtn.Enabled)
                {
                    logoutBtn.Enabled = false;
                    disabledButtons[btnCount++] = logoutBtn;
                }
                bool reconnected;
                do
                {
                    reconnected = await _api.CheckConnection();
                }
                while (!reconnected);
                for (int i = 0; i < btnCount; i++)
                    disabledButtons[i].Enabled = true;
            }
        );
            Invoke(a);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this makes the application send updated user liked ads list to server
            if (logoutBtn.Visible)
            {
                _userInfo.User = null;
            }
            // close login screen if it is opened
            if (loginScreen != null)
            {
                loginScreen.Close();
            }
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

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            SetActivePanel(profilePage);
            SidebarButtonClicked(profileButton);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            loginScreen = new LoginScreen(_api, _userInfo);
            loginScreen.Show();
            loginBtn.Enabled = false;
            loginScreen.FormClosing += LoginScreen_FormClosing;
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // show log out button if user is now logged in
            if (_userInfo.Username != null)
            {
                userNameLabel.Text = _userInfo.Username;
                logoutBtn.Visible = true;
                profileButton.Enabled = true;
                uploadButton.Enabled = true;
            }
            else
            {
                // enable login button if user has not logged in
                loginBtn.Enabled = true;
            }
            loginScreen = null;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            _userInfo.User = null;
            userNameLabel.Text = "Guest";
            // disable profile and upload page and go to browse page
            browseButton.PerformClick();
            profileButton.Enabled = false;
            uploadButton.Enabled = false;
            loginBtn.Enabled = true;
            logoutBtn.Visible = false;
        }

        // this method must be called when any sidebar button is clicked because it sets button colors
        private void SidebarButtonClicked(Button button)
        {
            browseButton.ForeColor = _inactiveSidebarButtonTextColor;
            browseButton.BackColor = _inactiveSidebarButtonColor;
            searchButton.ForeColor = _inactiveSidebarButtonTextColor;
            searchButton.BackColor = _inactiveSidebarButtonColor;
            uploadButton.ForeColor = _inactiveSidebarButtonTextColor;
            uploadButton.BackColor = _inactiveSidebarButtonColor;
            profileButton.ForeColor = _inactiveSidebarButtonTextColor;
            profileButton.BackColor = _inactiveSidebarButtonColor;

            button.ForeColor = _activeSidebarButtonTextColor;
            button.BackColor = _activeSidebarButtonColor;

            // enable buttons
            browseButton.Enabled = true;
            searchButton.Enabled = true;
            if (_userInfo.Username != null)
            {
                profileButton.Enabled = true;
                uploadButton.Enabled = true;
            }

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
            // goes to profile page if user is logged in, otherwise prompts user to log in
            if (userNameLabel.Text == "Guest")
            {
                loginBtn.PerformClick();
            }
            else
            {
                profileButton.PerformClick();
            }
        }

        private void LoginBtn_VisibleChanged(object sender, EventArgs e)
        {
            logoutBtn.Visible = !loginBtn.Visible;
        }

        private void LogoutBtn_VisibleChanged(object sender, EventArgs e)
        {
            loginBtn.Visible = !logoutBtn.Visible;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // start with Browse page activated
            browseButton.PerformClick();
        }
    }
}
