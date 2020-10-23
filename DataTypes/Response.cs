using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public class Response
    {
        private const string HttpVersion = "HTTP/1.1";
        private string headersDelimitor = "\r\n";
        private int statusCode;
        private string statusText;
        public List<Header> Headers
        { set; get; }
        public byte[] Content
        { set; get; }

        public Response(int statusCode)
        {
            this.statusCode = statusCode;
            switch (statusCode)
            {
                case 200:
                    statusText = "OK";
                    break;
                case 201:
                    statusText = "Created";
                    break;
                case 400:
                    statusText = "Bad Request";
                    break;
                case 401:
                    statusText = "Unauthorized";
                    break;
                case 404:
                    statusText = "Not Found";
                    break;
                case 500:
                    statusText = "Internal Server Error";
                    break;
                case 501:
                    statusText = "Not Implemented";
                    break;
                case 505:
                    statusText = "HTTP Version Not Supported";
                    break;
                case 411:
                    statusText = "Length Required";
                    break;
                default:
                    statusText = "Unknown";
                    break;
            }
        }

        public byte[] Format()
        {
            StringBuilder output = new StringBuilder($"{HttpVersion} {statusCode} {statusText}{headersDelimitor}");
            foreach (Header h in Headers)
            {
                output.Append($"{h.Name}: {h.Value}{headersDelimitor}");
            }
            output.Append(headersDelimitor);
            byte[] finalOutput = Encoding.ASCII.GetBytes(output.ToString());
            int outputSize = finalOutput.Length;
            Array.Resize<byte>(ref finalOutput, outputSize + Content.Length);
            Array.Copy(Content, 0, finalOutput, outputSize, Content.Length);
            return finalOutput;
        }
    }
}