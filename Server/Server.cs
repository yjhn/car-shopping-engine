using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Server
{

    public class Server
    {
        TcpListener tcpServer = null;
        private const int maxBufferLength = 5000;
        public Server(String ip, int port)
        {
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
            catch (SocketException e)
            {
                HandleSocketExceptionMessage(e);
                tcpServer.Stop();
            }
        }

        // Method for handling clients' requests
        private void ReceiveRequests(Object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;

            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            String data = null;
            byte[] bytes = new Byte[maxBufferLength];
            int i;

            try
            {

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                    // Process the data sent by the client and make a response.
                    byte[] msg = new RequestHandler(data).HandleRequest();

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                }
            }
            catch (SocketException e)
            {
                HandleSocketExceptionMessage(e);
                client.Close();
            }
            catch (IOException e)
            {
                // Client probably disconnected
                Console.WriteLine("Client closed the connection\n");
                Console.WriteLine(e.Message);
                client.Close();
            }

            // Shutdown and end connection
            client.Close();
        }

        private void HandleSocketExceptionMessage(SocketException e)
        {
            Console.WriteLine("Fatal error: {0}", e);
        }

        public static void Main(String[] args)
        {
            new Server("0.0.0.0", 8888);
        }
    }
}