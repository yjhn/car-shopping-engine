using System;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Frontend
{

    public class Client
    {
        private const int maxBufferLength = 5000;
        private const string serverName = "localhost";
        private int port = 8888;
        private Logger logger;
        public Client(Logger logger)
        {
            this.logger = logger;
        }

        public static bool ValidateServerCertificate(
          object sender,
          X509Certificate certificate,
          X509Chain chain,
          SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            //        Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return true;
        }

        public string GetResponse(Request req)
        {
            byte[] receivedData = new Byte[maxBufferLength];
            StringBuilder message = new StringBuilder("{req.Method} {req.Url}/{req.Resource}");
            if (req.Queries.Count > 0)
            {
                message.Append("?");
                foreach (KeyValuePair kvp in req.Queries)
                    message.Append("{kvp.Key}=kvp.Value}");
                message.Length = message.Length - 1;
                foreach (Header h in req.Headers)
                    message.Append("\r\n{h.Name}: {h.Value}");
                message.Append("\r\n\r\n");
                byte[] sentData = System.Text.Encoding.ASCII.GetBytes(message);
                try
                {
                    TcpClient client = new TcpClient(ip, port);
                    SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                    sslStream.AuthenticateAsClient(serverName);
                    sslStream.Write(sentData, 0, sentData.Length);
                    String responseData = String.Empty;
                    int reachedLength, totalLength;
                    int bytes = sslStream.Read(receivedData, 0, maxBufferLength);
                    responseData = System.Text.Encoding.ASCII.GetString(receivedData, 0, bytes);
                    StringBuilder contentLength = new StringBuilder();
                    StringBuilder content = new StringBuilder(responseData);
                    int index = responseData.IndexOf("Content-length: ");
                    if (index > -1)
                    {
                        index = index + 16;
                        while (index + 1 < responseData.Length & int.TryParse(responseData.Substring(index, 1), out totalLength))
                        {
                            contentLength.Append(responseData.Substring(index, 1));
                            index++;
                        }
                        totalLength = int.Parse(contentLength.ToString());
                        if (totalLength > (responseData.Length - (index + 4)))
                        {
                            reachedLength = responseData.Length - (index + 4);
                            do
                            {
                                bytes = sslStream.Read(receivedData, 0, maxBufferLength);
                                responseData = System.Text.Encoding.ASCII.GetString(receivedData, 0, bytes);
                                reachedLength += responseData.Length;
                                content.Append(responseData);
                            }
                            while (totalLength > reachedLength);
                        }
                    }
                    client.Close();
                    sslStream.Close();
                }
                catch (Exception e)
                {
                    logger.LogException(e);
                }
            }
        }
    }
}
