using System;
namespace Server
{
    public class Response
    {
        private int statusCode, contentLength;
        private String statusText, contentMessage;

        public Response(int statusCode, String contentMessage)
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
            this.contentMessage = contentMessage;
            contentLength = contentMessage.Length;
        }
        override public String ToString()
        {
            return statusCode.ToString() + " " + statusText + "\r\nContent-length: " + contentLength + "\r\n\r\n" + contentMessage;
        }
    }
}