using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public class Response
    {
        private string _statusText;
        private int _statusCode;
        public int StatusCode
        {
            get
            {
                return _statusCode;
            }
            set
            {
                _statusCode = value;
                _statusText = value switch
                {
                    200 => "OK",
                    201 => "Created",
                    204 => "No Content",
                    400 => "Bad Request",
                    401 => "Unauthorized",
                    404 => "Not Found",
                    408 => "Request Timeout",
                    411 => "Length Required",
                    415 => "Unsupported Media Type",
                    500 => "Internal Server Error",
                    501 => "Not Implemented",
                    505 => "HTTP Version Not Supported",
                    _ => "Unknown",
                };
            }
        }

        private readonly string _httpVersion;
        public List<Header> Headers
        { set; get; }
        public byte[] Content
        { set; get; }

        public Response(string httpVersion)
        {
            _httpVersion = httpVersion;
        }

        public byte[] Format()
        {
            StringBuilder output = new StringBuilder($"{_httpVersion} {_statusCode} {_statusText}\r\n");
            foreach (Header h in Headers)
            {
                output.Append($"{h.Name}: {h.Value}\r\n");
            }
            output.Append("\r\n");
            byte[] finalOutput = Encoding.UTF8.GetBytes(output.ToString());
            int outputSize = finalOutput.Length;
            Array.Resize<byte>(ref finalOutput, outputSize + Content.Length);
            Array.Copy(Content, 0, finalOutput, outputSize, Content.Length);
            return finalOutput;
        }
    }
}