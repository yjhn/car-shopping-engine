using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Backend;
namespace Server
{
    public class RequestHandler
    {
        private String rawRequest;
        public RequestHandler(String rawRequest)
        {
            this.rawRequest = rawRequest;
        }
        public byte[] HandleRequest()
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
            catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentException || e is ArgumentNullException)
            {
                r = new Response(400, e.Message);
            }
            catch (Exception e)
            {
                r = new Response(500, e.Message);
            }

            return r.Format();
        }

        private Request Parse()
        {
            int methodEnd = rawRequest.IndexOf(" ");
            String method = rawRequest.Substring(0, methodEnd);
            int resourceEnd = rawRequest.IndexOf("\r\n");
            methodEnd++;
            String resource = rawRequest.Substring(methodEnd, resourceEnd - methodEnd);
            if (!resource.StartsWith("/"))
                throw new ArgumentException("INVALID RESOURCE");
            int resNameEnd = resource.IndexOf("?");
            List<Query> queries = new List<Query>();
            if (resNameEnd == -1)
                resNameEnd = resource.Length;
            else
                queries = SeparateQueries(resource.Substring(resNameEnd + 1, resource.Length - resNameEnd - 1));
            string resName = resource.Substring(1, resNameEnd - 1);
            foreach (Query q in queries)
                if (string.IsNullOrEmpty(q.Name) || string.IsNullOrEmpty(q.Value))
                    throw new ArgumentException("INVALID RESOURCE QUERY: " + q.ToString());
            int headersEnd = rawRequest.IndexOf("\r\n\r\n") + 4;
            String contentMessage = rawRequest.Substring(headersEnd, rawRequest.Length - headersEnd);

            // Content Length attribute must be explicitly extracted from Content-length header and checked with a message itself (in later version)
            Request parsing = new Request(method, resName, contentMessage, queries);
            return parsing;
        }

        private Response ProcessGet(Request req)
        {
            Response r;
            string res = req.Resource;
            switch (res)
            {
                case "CARS":
                    r = GetCars(req);
                    break;
                case "USERS":
                    r = GetUsers(req);
                    break;
                default:
                    r = UnknownResource(req.Resource);
                    break;
            }
            return r;
        }

        private Response ProcessPost(Request req)
        {
            Response r = new Response(201, "");
            switch (req.Resource)
            {
                case "CARS":
                    AddCar(System.Text.Encoding.ASCII.GetBytes(req.ContentMessage));
                    break;
                case "USERS":
                    AddUser(System.Text.Encoding.ASCII.GetBytes(req.ContentMessage));
                    break;
                default:
                    r = UnknownResource(req.Resource);
                    break;
            }
            return r;
        }

        private Response ProcessDelete(Request req)
        {
            Response r = new Response(200, "");
            int id = GetId(req);
            switch (req.Resource)
            {
                case "CARS":
                    DeleteCar(id);
                    break;
                case "USERS":
                    DeleteUser(id);
                    break;
                default:
                    r = UnknownResource(req.Resource);
                    break;
            }
            return r;
        }

        private Response ProcessUnknown(Request req)
        {
            return new Response(400, "UNKNOWN METHOD: " + req.Method);
        }

        private Response GetCars(Request req)
        {
            int id = -1, resultAmount = -1;
            bool getSorted = false, getById = false, amountSet = false;
            ArgumentException incompatible = new ArgumentException("Incompatible queries");
            Type enumType = typeof(SortingCriteria);
            SortingCriteria criteria = (SortingCriteria)Enum.Parse(enumType, "Unknown");
            List<Query> queries = req.Queries;
            foreach (Query q in queries)
            {
                switch (q.Name)
                {
                    case "SORTBY":
                        {
                            if (getById)
                                throw incompatible;
                            getSorted = true;
                            string sortBy = q.Value;
                            foreach (string name in SortingCriteria.GetNames(enumType))
                            {
                                if (name == sortBy)
                                {
                                    criteria = (SortingCriteria)Enum.Parse(enumType, name);
                                    break;
                                }
                            }
                        }
                        break;
                    case "ID":
                        {
                            if (getSorted)
                                throw incompatible;
                            getById = true;
                            id = Int32.Parse(q.Value);
                        }
                        break;
                    case "RESULTAMOUNT":
                        {
                            if (getById)
                                throw incompatible;
                            resultAmount = Int32.Parse(q.Value);
                            amountSet = true;
                        }
                        break;
                    default:
                        throw new ArgumentException($"Unknown query: {q.Name}");
                }
            }
            byte[] responseBody;
            CarList cs = new CarList(new Logger());
            if (getById)
                responseBody = cs.JsonGetCar(id);
            else if (getSorted && amountSet)
                responseBody = cs.JsonSortBy(criteria, resultAmount);
            else if (getSorted)
                responseBody = cs.JsonSortBy(criteria);
            else if (amountSet)
                responseBody = cs.JsonGetCarList(resultAmount);
            else
                responseBody = cs.JsonGetCarList();

            return new Response(200, responseBody);
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

        private int GetId(Request req)
        {
            List<Query> queries = req.Queries;
            foreach (Query q in queries)
            {
                if (q.Name == "ID")
                    return Int32.Parse(q.Value);
            }
            throw new ArgumentException("ID is required");
        }

        private Response UnknownResource(String resName)
        {
            return new Response(400, $"Unknown resource: {resName}");
        }

        private Response GetUsers(Request req)
        {
            int id = GetId(req);
            byte[] responseBody = new UserList(new Logger()).JsonGetUser(id);
            return new Response(200, responseBody);
        }

        private void AddCar(byte[] carData)
        {
            new CarList(new Logger()).JsonAddCar(carData);
        }

        private void AddUser(byte[] userData)
        {
            new UserList(new Logger()).JsonAddUser(userData);
        }

        private void DeleteCar(int id)
        {
            new CarList(new Logger()).DeleteCar(id);
        }

        private void DeleteUser(int id)
        {
            new UserList(new Logger()).DeleteUser(id);
        }
    }
}