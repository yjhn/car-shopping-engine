using Backend;
using DataTypes;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Configuration;

namespace Server
{
    public class Server
    {
        private readonly TcpListener _tcpServer = null;
        private readonly Logger _logger;
        private readonly IDatabase _db;
        private X509Certificate _serverCertificate;
        private readonly Config _configuration;

        public Server(Logger logger, IDatabase db)
        {
            _logger = logger;
            _db = db;

            // retreaving values from config file
            string ip = ConfigurationManager.AppSettings["ip"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            string httpVersion = ConfigurationManager.AppSettings["httpVersion"];
            string scheme = ConfigurationManager.AppSettings["scheme"];
            int maxBufferSize = int.Parse(ConfigurationManager.AppSettings["maxBufferSize"]);
            int maxAttempts = int.Parse(ConfigurationManager.AppSettings["maxAttempts"]);
            int timeout = int.Parse(ConfigurationManager.AppSettings["timeout"]);
            _configuration = new Config(ip, port, httpVersion, scheme, maxBufferSize, maxAttempts, timeout);
            string[] extras = { ConfigurationManager.AppSettings["certFileName"], ConfigurationManager.AppSettings["password"] };
            _configuration.Extra = extras;
            _tcpServer = new TcpListener(IPAddress.Parse(ip), _configuration.Port);
            _tcpServer.Start();
            StartListener();
        }

        private void StartListener()
        {
            try
            {

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    // Perform a blocking call to accept requests.
                    TcpClient tcpClient = _tcpServer.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    Thread t = new Thread(new ParameterizedThreadStart(ReceiveRequests));
                    t.Start(tcpClient);
                }
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                _tcpServer.Stop();
            }
        }

        // Method for handling clients' requests
        private void ReceiveRequests(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            SslStream sslStream = new SslStream(client.GetStream(), false);
            sslStream.ReadTimeout = _configuration.Timeout;
            sslStream.WriteTimeout = _configuration.Timeout;
            try
            {
                _serverCertificate = new X509Certificate(_configuration.Extra[0], _configuration.Extra[1]);
                sslStream.AuthenticateAsServer(_serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);
                StringBuilder data = new StringBuilder();
                byte[] bytes = new Byte[_configuration.MaxBufferSize];
                byte[] msg = null;
                bool isRequestValid = false, readMore = true;
                int attempts = 0;
                string newData = null;
                try
                {
                    do
                    {
                        int numOfBytes = sslStream.Read(bytes, 0, bytes.Length);
                        attempts++;
                        if (numOfBytes == 0)
                        {
                            break;
                        }
                        // Translate data bytes to a UTF8 string.
                        newData = Encoding.UTF8.GetString(bytes, 0, numOfBytes);
                        // if all data was fetched already, check it
                        msg = new RequestHandler(newData, _db, _logger, _configuration).HandleRequest(out isRequestValid);
                        if (isRequestValid)
                            readMore = false;
                        data.Append(newData);
                    }
                    while (readMore && attempts < _configuration.MaxAttempts);
                }
                catch (IOException e)
                {
                    _logger.LogException(e);
                }
                // Process the data sent by the client and make a response.
                if (!isRequestValid)
                {
                    msg = new RequestHandler(data.ToString(), _db, _logger, _configuration).HandleRequest(out bool unnecessary);
                }
                // Send back a response.
                sslStream.Write(msg, 0, msg.Length);
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                if (e.InnerException != null)
                    _logger.LogException(e.InnerException);
            }

            // Shutdown and end connection
            finally
            {
                sslStream.Close();
                client.Close();
            }
        }

        public static void Main()
        {
            // create database and logger since only one instance of each will be needed
            Logger logger = new Logger();
            IDatabase db = new Database(logger);
            _ = new Server(logger, db);
        }
    }
}