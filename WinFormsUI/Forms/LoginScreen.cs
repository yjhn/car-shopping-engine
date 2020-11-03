using System;
using System.Windows.Forms;

namespace Test1
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            passwordTextBox.PasswordChar = '*';

        }

        private void Button1_Click(object sender, EventArgs e)
        {


            //Here we should retrieve userToken from backend, if userToken is null it means, user is not logged in, for this button will just make the user token not null and set UserName. This Button will close the Form

            Program.user.Username = usernameTextBox.Text;
            Program.userToken = "";

            this.Close();
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
