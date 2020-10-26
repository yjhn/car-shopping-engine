using DataTypes;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Frontend
{
    public class Client
    {
        private const int maxBufferLength = 5000;
        private static string host = "localhost";
        private static int port = 8888;

        private static bool ValidateServerCertificate(
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

        public static string GetRawResponse(Request req)
        {
            byte[] receivedData = new Byte[maxBufferLength];
            StringBuilder message = new StringBuilder("{req.Method} {req.Url}/{req.Resource}");
            if (req.Queries.Count > 0)
            {
                message.Append("?");
                foreach (KeyValuePair<string, string> kvp in req.Queries)
                    message.Append("{kvp.Key}=kvp.Value}");
                message.Length = message.Length - 1;
            }
            req.Headers.Insert(0, new Header("Host", host));
            foreach (Header h in req.Headers)
                message.Append("\r\n{h.Name}: {h.Value}");
            message.Append("\r\n\r\n");
            byte[] sentData = Encoding.ASCII.GetBytes(message.ToString());
            try
            {
                TcpClient client = new TcpClient(host, port);
                SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient(host);
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
                return content.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Response FromString2Response(string rawResponse)
        {
            Regex regex = new Regex(@"^HTTP/1.1 (?<statusCode>\d\d\d) [a-zA-Z]+\r\n(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[a-zA-Z\,\.:\/\?\d&_]+)\r\n)+\r\n(?<content>[\d\D]*)$");
            if (!regex.IsMatch(rawResponse))
                return null;
            GroupCollection groups = regex.Matches(rawResponse)[0].Groups;
            int statusCode = int.Parse(groups["statusCode"].Value);
            CaptureCollection names = groups["headerName"].Captures;
            CaptureCollection values = groups["headerValue"].Captures;
            List<Header> headers = new List<Header>();
            for (int i = 0; i < names.Count; i++)
                if (!Header.Contains(headers, names[i].Value))
                    headers.Add(new Header(names[i].Value.ToUpper(), values[i].Value));
                else
                    return null;
            string content = groups["content"].Value;
            Response r = new Response(statusCode);
            r.Headers = headers;
            r.Content = Encoding.ASCII.GetBytes(content);
            return r;
        }
    }
}