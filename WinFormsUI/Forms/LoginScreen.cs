using DataTypes;
using Frontend;
using System;
using System.Windows.Forms;

namespace CarEngine
{
    public partial class LoginScreen : Form
    {
        private readonly IApiWrapper _frontendApi;
        private readonly UserInfo _userInfo;

        public LoginScreen(IApiWrapper api, UserInfo userInfo)
        {
            _userInfo = userInfo;
            _frontendApi = api;
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';
            phoneTextbox.Controls[0].Visible = false;
            phoneTextbox.ResetText();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if (Utilities.ValidateInput(username, password))
            {
                if (!await _userInfo.Login(username, password))
                {
                    // this is not always correct, as we will get null also when there is no connection
                    // close this window from main window in no connection event
                    MessageBox.Show("Bad username or password", "Bad credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    passwordTextBox.Clear();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Username and password cannot be empty and cannot contain spaces ", "Bad input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Clear();
            }
        }

        private async void SigUpButton_Click(object sender, EventArgs e)
        {
            int successfullyCreated;
            if (!loginButton.Visible)
            {
                // need to check for bad input
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string email = emailTextbox.Text;
                long phone = 1000000;
                if (!string.IsNullOrEmpty(phoneTextbox.Text))
                    phone = Convert.ToInt64(phoneTextbox.Text);
                if (Utilities.ValidateInput(username, password) && email != "" && !email.Contains(' ') && phone != 1000000)
                {
                    User user = new User(username, phone, Utilities.EncryptPassword(password, username), email);
                    successfullyCreated = await _frontendApi.PostUser(user);
                    switch (successfullyCreated)
                    {
                        case 0:
                            // show that user creation is successful
                            MessageBox.Show("Successfully created user " + username, "User created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // show login controls
                            emailLabel.Visible = false;
                            emailTextbox.Visible = false;
                            phoneLabel.Visible = false;
                            phoneTextbox.Visible = false;
                            loginButton.Visible = true;
                            usernameTextBox.Focus();
                            break;
                        case -1:
                            MessageBox.Show("This username is already taken", "Bad username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case -2:
                            MessageBox.Show("No connection to server", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            throw new Exception("Unknown value returned");
                    }
                }
                else
                {
                    MessageBox.Show("Fields cannot be empty and cannot contain spaces", "Bad form data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                emailLabel.Visible = true;
                emailTextbox.Visible = true;
                phoneLabel.Visible = true;
                phoneTextbox.Visible = true;
                loginButton.Visible = false;
                usernameTextBox.Focus();
            }
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
            }
        }
    }
}
