using System;
namespace Server
{
    public class Request
    {
        private string method, resource, contentMessage;
        public string Method
        {
            get { return method; }
        }
        public string Resource
        {
            get { return resource; }
        }
        public String ContentMessage
        {
            get { return contentMessage; }
        }
        public Request(string method, string resource, string contentMessage)
        {
            this.method = method;
            this.resource = resource;
            this.contentMessage = contentMessage;
        }
    }
}