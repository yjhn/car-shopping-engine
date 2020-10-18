using System;
using System.Collections.Generic;
namespace Server
{
    public class Request
    {
        public string Method
        { get; }
        public string Url
        { get; set; }
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
        public Request(string method, string url, string resource, Dictionary<string, string> queries, string httpVersion, List<Header> headers, string content)
        {
            Method = method;
            Url = url;
            Resource = resource;
            Queries = queries;
            HttpVersion = httpVersion;
            Headers = headers;
            Content = content;
        }
    }
}