using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes
{
    public class Response
    {
        public int StatusCode
        { get; }
        private readonly string _statusText;
        public List<Header> Headers
        { set; get; }
        public byte[] Content
        { set; get; }

        public Response(int statusCode)
        {
            StatusCode = statusCode;
            _statusText = statusCode switch
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

        public byte[] Format()
        {
            StringBuilder output = new StringBuilder($"{ServerConstants.HttpVersion} {StatusCode} {_statusText}{ServerConstants.HeaderSeparator}");
            foreach (Header h in Headers)
            {
                output.Append($"{h.Name}: {h.Value}{ServerConstants.HeaderSeparator}");
            }
            output.Append(ServerConstants.HeaderSeparator);
            byte[] finalOutput = Encoding.UTF8.GetBytes(output.ToString());
            int outputSize = finalOutput.Length;
            Array.Resize<byte>(ref finalOutput, outputSize + Content.Length);
            Array.Copy(Content, 0, finalOutput, outputSize, Content.Length);
            return finalOutput;
        }
    }
}