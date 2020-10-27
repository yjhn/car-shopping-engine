using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Text;
using System.IO;
using Backend;
using DataTypes;

namespace Server
{
    public class Server
    {
        private TcpListener tcpServer = null;
        private Logger logger;
        private ICarDb carDb;
        private IUserDb userDb;
        private X509Certificate serverCertificate;
        public Server(Logger logger, ICarDb carDb, IUserDb userDb)
        {
            this.logger = logger;
            this.carDb = carDb;
            this.userDb = userDb;

            IPAddress addr = IPAddress.Parse(ServerConstants.Host);
            tcpServer = new TcpListener(addr, ServerConstants.Port);
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
                serverCertificate = new X509Certificate(ServerConstants.CertFileName, ServerConstants.Password);
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, checkCertificateRevocation: true);
                sslStream.ReadTimeout = ServerConstants.ServerTimeout;
                sslStream.WriteTimeout = ServerConstants.ServerTimeout;
                StringBuilder data = new StringBuilder(); ;
                byte[] bytes = new Byte[ServerConstants.MaxBufferSize];
                try
                {
                    bool readMore = true;
                    int attempts = 0;
                    do
                    {
                        int numOfBytes = sslStream.Read(bytes, 0, bytes.Length);
                        attempts++;
                        if (numOfBytes == 0)
                            readMore = false;
                        // Translate data bytes to a ASCII string.
                        data.Append(Encoding.ASCII.GetString(bytes, 0, numOfBytes));
                    }
                    while (readMore && attempts < ServerConstants.MaxAttempts);
                }
                catch (IOException e)
                {
                    logger.LogException(e);
                }
                // Process the data sent by the client and make a response.
                byte[] msg = new RequestHandler(data.ToString(), carDb, userDb, logger).HandleRequest();

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

            new Server(logger, carDb, userDb);
        }
    }
}