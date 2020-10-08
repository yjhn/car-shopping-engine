using System;
using System.IO;
using System.Text;
using Backend;
using System.Collections.Generic;
namespace Server
{
    public class RequestHandler
    {
        private String rawRequest;
        public RequestHandler(String rawRequest)
        {
            this.rawRequest = rawRequest;
        }
        public String HandleRequest()
        {
            Response r;
            try
            {
                Request newRequest = Parse();
                switch (newRequest.Method)
                {
                    case "GET":
                        r = ProcessGet(newRequest);
                        break;
                    case "POST":
                        r = ProcessPost(newRequest);
                        break;
                    case "DELETE":
                        r = ProcessDelete(newRequest);
                        break;
                    default:
                        r = ProcessUnknown(newRequest);
                        break;
                }
            }
            catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentException || e is ArgumentNullException || e is PathTooLongException || e is NotSupportedException)
            {
                r = new Response(400, e.Message);
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                r = new Response(404, e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                r = new Response(403, e.Message);
            }
            catch (Exception e)
            {
                r = new Response(500, e.Message);
            }

            return r.ToString();
        }

        private Request Parse()
        {
            int methodEnd = rawRequest.IndexOf(" ");
            String method = rawRequest.Substring(0, methodEnd);
            int resourceEnd = rawRequest.IndexOf("\r\n");
            methodEnd++;
            String resource = rawRequest.Substring(methodEnd, resourceEnd - methodEnd);
            int headersEnd = rawRequest.IndexOf("\r\n\r\n") + 4;
            String contentMessage = rawRequest.Substring(headersEnd, rawRequest.Length - headersEnd);

            // Content Length attribute must be explicitly extracted from Content-length header and checked with a message itself (in later version)
            Request parsing = new Request(method, resource, contentMessage);
            return parsing;
        }

        private Response ProcessGet(Request req)
        {
            Response r;
            string res = req.Resource;
            if (!res.StartsWith("/"))
                throw new ArgumentException("INVALID RESOURCE");
            int resNameEnd = res.IndexOf("?");
            List<Query> queries = new List<Query>();
            if (resNameEnd == -1)
                resNameEnd = res.Length;
            else
                queries = SeparateQueries(res.Substring(resNameEnd + 1, res.Length - resNameEnd - 1));
            string resName = res.Substring(1, resNameEnd - 1);
            foreach (Query q in queries)
            {
                Console.WriteLine("Name: " + q.Name + "; value: " + q.Value);
                if (string.IsNullOrEmpty(q.Name) || string.IsNullOrEmpty(q.Value))
                    throw new ArgumentException("INVALID RESOURCE QUERY: " + q.ToString());
            }
            switch (resName)
            {
                case "CARS":
                    r = ProcessCars(queries);
                    break;
                default:
                    throw new ArgumentException("NOT IMPLEMENTED YET");
                    break;
            }
            r = new Response(100, "");
            return r;
        }

        private Response ProcessPost(Request req)
        {
            StreamWriter file = new StreamWriter(req.Resource, true);
            file.Write(req.ContentMessage);
            file.Close();
            Response r = new Response(201, "");
            return r;
        }

        private Response ProcessDelete(Request req)
        {
            File.Delete(req.Resource);
            Response r = new Response(200, "");
            return r;
        }

        private Response ProcessUnknown(Request req)
        {
            return new Response(400, "UNKNOWN METHOD: " + req.Method);
        }

        private Response ProcessCars(List<Query> queries)
        {
            foreach (Query q in queries)
            {
                switch (q.Name)
                {
                    case "SORTBY":
                        {
                            string sortBy = q.Value;
                            /*Type enumType = typeof(SortingCriteria);
                            SortingCriteria criteria = (SortingCriteria)Enum.Parse(enumType, "Unknown");
                            foreach (string name in SortingCriteria.GetNames(enumType))
                            {
                                if (name == sortBy)
                                {
                                    criteria = (SortingCriteria)Enum.Parse(enumType, name);
                                    break;
                                }
                            }*/
                        }
                        break;
                    default:
                        throw new ArgumentException("UNKNOWN QUERY: " + q.Name);
                }
            }
            return new Response(100, "");
        }

        private List<Query> SeparateQueries(string queryList)
        {
            string[] queries = queryList.Split('&', StringSplitOptions.None);
            string[] pair;
            List<Query> separated = new List<Query>();
            foreach (string q in queries)
                if (!string.IsNullOrEmpty(q))
                {
                    pair = q.Split('=', 2, StringSplitOptions.None);
                    separated.Add(new Query(pair[0], pair[1]));
                }
            return separated;
        }
    }
}