using Frontend;
using DataTypes;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace CarEngine
{
    static class Program
    {
        // this is the only instance of Api that exists
        //private static readonly IApi _api = new Api();
        private static readonly IServerV2 _server = new ServerV2(new Uri("https://localhost:5001/"));
        private static readonly IApiWrapper _api = new ApiWrapper(_server);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {

            _api = new Api(new Config(Settings.Default.ip, Settings.Default.port, Settings.Default.httpVersion, Settings.Default.scheme, Settings.Default.maxBufferSize, Settings.Default.maxAttempts, Settings.Default.timeout));
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(_api, new UserInfo(_api)));
        }
    }
}
