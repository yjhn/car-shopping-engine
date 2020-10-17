using System;
using System.Collections.Generic;
namespace Server
{
    public class Request
    {
        public string Method
        { get; }
        public string Resource
        { get; set; }
        public Dictionary<string, string> Queries
        { get; }
        public string HttpVersion
        { get; }
        public List<Header> Headers
        { get; }
        public String Content
        { get; }
        public Request(string method, string resource, Dictionary<string, string> queries, string httpVersion, List<Header> headers, string content)
        {
            Method = method;
            Resource = resource;
            Queries = queries;
            HttpVersion = httpVersion;
            Headers = headers;
            Content = content;
        }
    }
}