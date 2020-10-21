using System;
using System.Collections.Generic;
namespace DataTypes
{
    public class Request
    {
        public string Method
        { get; set;}
        public string Url
        { get; set; }
        public string Resource
        { get; set; }
        public Dictionary<string, string> Queries
        { get; set; }
        public string HttpVersion
        { get; set;}
        public List<Header> Headers
        { get; set;}
        public String Content
        { get; set;}
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