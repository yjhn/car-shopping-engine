using DataTypes;
using System;
using System.Windows.Forms;

namespace Test1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        //public static User user = new User("Guest", 0, "", "");
        public static string UserToken = null;
        public static string Username = null;
        public static MinimalUser User
        {
            get
            {
                return User;
            }
            set
            {
                if (value != null)
                {
                    Username = value.Username;
                    UserToken = value.Token;
                    //User = value;
                }
            }
        }

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
        }
    }
}
