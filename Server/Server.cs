using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Backend;
namespace Server
{

    public class Server
    {
        private TcpListener tcpServer = null;
        private const int maxBufferLength = 5000;
        private Logger logger;
        private ICarDb carDb;
        private IUserDb userDb;
        private const string certFileName = @"..\..\..\ssl-certificate.pfx";
        private X509Certificate serverCertificate;
        private const string password = "burbulometodas";
        public Server(String ip, int port, Logger logger, ICarDb carDb, IUserDb userDb)
        {
            this.logger = logger;
            this.carDb = carDb;
            this.userDb = userDb;

            IPAddress localAddr = IPAddress.Parse(ip);
            tcpServer = new TcpListener(localAddr, port);
            tcpServer.Start();
            startListener();
        }

        private void startListener()
        {
            try
            {

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    TcpClient tcpClient = tcpServer.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    Thread t = new Thread(new ParameterizedThreadStart(ReceiveRequests));
                    t.Start(tcpClient);
                }
            }
            catch (Exception e)
            {
                logger.LogException(e);
                tcpServer.Stop();
            }
        }

        // Method for handling clients' requests
        private void ReceiveRequests(Object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            SslStream sslStream = new SslStream(client.GetStream(), false);
            try
            {
                serverCertificate = new X509Certificate(certFileName, password);
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);
                sslStream.ReadTimeout = 5000;
                sslStream.WriteTimeout = 5000;

                String data = null;
                byte[] bytes = new Byte[maxBufferLength];

                int i = sslStream.Read(bytes, 0, bytes.Length);
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                // Process the data sent by the client and make a response.
                byte[] msg = new RequestHandler(data, carDb, userDb, logger).HandleRequest();

                // Send back a response.
                sslStream.Write(msg, 0, msg.Length);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                if (e.InnerException != null)
                    logger.LogException(e.InnerException);
            }

            // Shutdown and end connection
            finally
            {
                sslStream.Close();
                client.Close();
            }
        }

        public static void Main(String[] args)
        {
            // create car database, user database and logger, since only one instance of each will be needed
            Logger logger = new Logger();
            ICarDb carDb = new CarList(logger);
            IUserDb userDb = new UserList(logger);

            new Server("0.0.0.0", 8888, logger, carDb, userDb);
        }
    }
}