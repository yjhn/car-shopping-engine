using System;
using System.Collections.Generic;
namespace Server
{
    public class Request
    {
        private string method, resource, contentMessage;
        private List<Query> queries;
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
        public List<Query> Queries
        {
            get { return queries; }
        }
        public Request(string method, string resource, string contentMessage, List<Query> queries)
        {
            this.method = method;
            this.resource = resource;
            this.contentMessage = contentMessage;
            this.queries = queries;
        }
    }
}