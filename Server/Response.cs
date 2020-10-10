using System;
namespace Server
{
    public class Response
    {
        private int statusCode, contentLength;
        private String statusText;
        private byte[] contentMessage;

        private Response(int statusCode)
        {
            this.statusCode = statusCode;
            switch (statusCode)
            {
                case 200:
                    statusText = "OK";
                    break;
                case 201:
                    statusText = "CREATED";
                    break;
                case 400:
                    statusText = "BAD REQUEST";
                    break;
                case 403:
                    statusText = "FORBIDDEN";
                    break;
                case 404:
                    statusText = "NOT FOUND";
                    break;
                case 500:
                    statusText = "ERROR";
                    break;
                default:
                    statusText = "UNKNOWN";
                    break;
            }
        }

        public Response(int statusCode, String contentMessage)
: this(statusCode)
        {
            this.contentMessage = System.Text.Encoding.ASCII.GetBytes(contentMessage);
            contentLength = contentMessage.Length;
        }

        public Response(int statusCode, byte[] contentMessage)
        : this(statusCode)
        {
            this.contentMessage = contentMessage;
            contentLength = contentMessage.Length;
        }

        public byte[] Format()
        {
            String headers = $"{statusCode} {statusText}\r\nContent-length: {contentLength}\r\n\r\n";
            byte[] finalOutput = System.Text.Encoding.ASCII.GetBytes(headers);
            int headersSize = finalOutput.Length;
            Array.Resize<byte>(ref finalOutput, headersSize + contentMessage.Length);
            Array.Copy(contentMessage, 0, finalOutput, headersSize, contentMessage.Length);
            return finalOutput;
        }
    }
}