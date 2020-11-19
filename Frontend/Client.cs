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
        private readonly Config _configuration;

        public Client(Config configuration)
        {
            _configuration = configuration;
        }

        private bool ValidateServerCertificate(
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

        public Response GetResponse(Request req)
        {
            byte[] receivedData = new Byte[_configuration.MaxBufferSize];
            StringBuilder message = new StringBuilder($"{req.Method} {req.Url}/{req.Resource}");
            if (req.Queries.Count > 0)
            {
                message.Append('?');
                foreach (KeyValuePair<string, string> kvp in req.Queries)
                    message.Append($"{kvp.Key}={WebUtility.UrlEncode(kvp.Value)}&");
                message.Length -= 1;
            }
            message.Append($" {_configuration.HttpVersion}");
            req.Headers.Insert(0, new Header("Host", _configuration.Ip));
            foreach (Header h in req.Headers)
                message.Append($"\r\n{h.Name}: {h.Value}");
            message.Append("\r\n\r\n");
            byte[] sentData = Encoding.UTF8.GetBytes(message.ToString());
            int sentDataSize = sentData.Length;
            if (req.Content != null)
            {
                Array.Resize<byte>(ref sentData, sentDataSize + req.Content.Length);
                Array.Copy(req.Content, 0, sentData, sentDataSize, req.Content.Length);
            }
            StringBuilder rawResponse = new StringBuilder();
            try
            {
                TcpClient client = new TcpClient(_configuration.Ip, _configuration.Port);
                SslStream sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient(_configuration.Ip);
                sslStream.ReadTimeout = 5000;
                sslStream.WriteTimeout = 5000;
                sslStream.Write(sentData, 0, sentData.Length);
                bool readMore = true;
                int attempts = 0;
                do
                {
                    int bytes = sslStream.Read(receivedData, 0, _configuration.MaxBufferSize);
                    attempts++;
                    if (bytes == 0)
                    {
                        break;
                    }
                    rawResponse.Append(Encoding.UTF8.GetString(receivedData, 0, bytes));
                }
                while (readMore && attempts < _configuration.MaxAttempts);
                client.Close();
                sslStream.Close();
                return fromStringToResponse(rawResponse.ToString());
            }
            catch (Exception e)
            {
                return fromStringToResponse(rawResponse.ToString());
            }
        }

        private Response fromStringToResponse(string rawResponse)
        {
            Regex regex = new Regex(@$"^{_configuration.HttpVersion} (?<statusCode>\d\d\d) [a-zA-Z ]+\r\n(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[a-zA-Z,\.:\/\?\d&_\-; =]+)\r\n)+\r\n(?<content>[\d\D]*)$");
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
            int contentLength = content.Length;
            if (Header.Contains(headers, "CONTENT-LENGTH"))
                contentLength = int.Parse(Header.GetValueByName(headers, "CONTENT-LENGTH"));
            if (contentLength < content.Length)
                content = content.Substring(0, contentLength);
            Response r = new Response(_configuration.HttpVersion)
            {
                Headers = headers,
                Content = Encoding.UTF8.GetBytes(content),
                StatusCode = statusCode
            };
            return r;
        }
    }

}