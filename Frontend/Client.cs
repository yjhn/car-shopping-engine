using DataTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Frontend
{
    public class Client
    {
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
            byte[] receivedData = new Byte[ServerConstants.MaxBufferSize];
            StringBuilder message = new StringBuilder($"{req.Method} {req.Url}/{req.Resource}");
            if (req.Queries.Count > 0)
            {
                message.Append("?");
                foreach (KeyValuePair<string, string> kvp in req.Queries)
                    message.Append($"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}&");
                message.Length -= 1;
            }
            message.Append($" {ServerConstants.HttpVersion}");
            req.Headers.Insert(0, new Header("Host", ServerConstants.HostForClients));
            foreach (Header h in req.Headers)
                message.Append($"{ServerConstants.HeaderSeparator}{h.Name}: {h.Value}");
            message.Append($"{ServerConstants.HeaderSeparator}{ServerConstants.HeaderSeparator}");
            byte[] sentData = Encoding.ASCII.GetBytes(message.ToString());
            int sentDataSize = sentData.Length;
            if (req.Content != null)
            {
                Array.Resize<byte>(ref sentData, sentDataSize + req.Content.Length);
                Array.Copy(req.Content, 0, sentData, sentDataSize, req.Content.Length);
            }
            StringBuilder rawResponse = new StringBuilder();
            try
            {
                TcpClient client = new TcpClient(ServerConstants.Ip, ServerConstants.Port);
                SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient(ServerConstants.HostForClients);
                sslStream.ReadTimeout = ServerConstants.ClientTimeout;
                sslStream.WriteTimeout = ServerConstants.ClientTimeout;
                sslStream.Write(sentData, 0, sentData.Length);
                bool readMore = true;
                int attempts = 0;
                do
                {
                    int bytes = sslStream.Read(receivedData, 0, ServerConstants.MaxBufferSize);
                    attempts++;
                    if (bytes == 0)
                        readMore = false;
                    rawResponse.Append(Encoding.ASCII.GetString(receivedData, 0, bytes));
                }
                while (readMore && attempts < ServerConstants.MaxAttempts);
                client.Close();
                sslStream.Close();
                return rawResponse.ToString();
            }
            catch (Exception)
            {
                return rawResponse.ToString();
            }
        }

        public static Response FromStringToResponse(string rawResponse)
        {
            Regex regex = new Regex(@$"^{ServerConstants.HttpVersion} (?<statusCode>\d\d\d) [a-zA-Z ]+{ServerConstants.HeaderSeparator}(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[a-zA-Z,\.:\/\?\d&_\-; =]+){ServerConstants.HeaderSeparator})+{ServerConstants.HeaderSeparator}(?<content>[\d\D]*)$");
            if (string.IsNullOrEmpty(rawResponse) || !regex.IsMatch(rawResponse))
                return null;
            GroupCollection groups = regex.Matches(rawResponse)[0].Groups;
            int statusCode = int.Parse(groups["statusCode"].Value);
            CaptureCollection names = groups["headerName"].Captures;
            CaptureCollection values = groups["headerValue"].Captures;
            List<Header> headers = new List<Header>();
            for (int i = 0; i < names.Count; i++)
                if (!Header.Contains(headers, names[i].Value.ToUpper()))
                    headers.Add(new Header(names[i].Value.ToUpper(), values[i].Value));
                else
                    return null;
            string content = groups["content"].Value;
            Response r = new Response(statusCode);
            r.Headers = headers;
            int contentLength = content.Length;
            if (Header.Contains(r.Headers, "CONTENT-LENGTH"))
                contentLength = int.Parse(Header.GetValueByName(r.Headers, "CONTENT-LENGTH"));
            if (contentLength < content.Length)
                content = content.Substring(0, contentLength);
            r.Content = Encoding.ASCII.GetBytes(content);
            return r;
        }
    }
}