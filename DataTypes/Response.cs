using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public class Response
    {
        public int StatusCode
        { get; }
        private string _statusText;
        public List<Header> Headers
        { set; get; }
        public byte[] Content
        { set; get; }

        public Response(int statusCode)
        {
            StatusCode = statusCode;
            switch (statusCode)
            {
                case 200:
                    _statusText = "OK";
                    break;
                case 201:
                    _statusText = "Created";
                    break;
                case 204:
                    _statusText = "No Content";
                    break;
                case 400:
                    _statusText = "Bad Request";
                    break;
                case 401:
                    _statusText = "Unauthorized";
                    break;
                case 404:
                    _statusText = "Not Found";
                    break;
                case 408:
                    _statusText = "Request Timeout";
                    break;
                case 411:
                    _statusText = "Length Required";
                    break;
                case 415:
                    _statusText = "Unsupported Media Type";
                    break;
                case 500:
                    _statusText = "Internal Server Error";
                    break;
                case 501:
                    _statusText = "Not Implemented";
                    break;
                case 505:
                    _statusText = "HTTP Version Not Supported";
                    break;
                default:
                    _statusText = "Unknown";
                    break;
            }
        }

        public byte[] Format()
        {
            StringBuilder output = new StringBuilder($"{ServerConstants.HttpVersion} {StatusCode} {_statusText}{ServerConstants.HeaderSeparator}");
            foreach (Header h in Headers)
            {
                output.Append($"{h.Name}: {h.Value}{ServerConstants.HeaderSeparator}");
            }
            output.Append(ServerConstants.HeaderSeparator);
            byte[] finalOutput = Encoding.ASCII.GetBytes(output.ToString());
            int outputSize = finalOutput.Length;
            Array.Resize<byte>(ref finalOutput, outputSize + Content.Length);
            Array.Copy(Content, 0, finalOutput, outputSize, Content.Length);
            return finalOutput;
        }
    }
}