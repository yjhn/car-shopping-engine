#define DEBUG
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Backend;
using System.Diagnostics;
using System.Text.RegularExpressions;
namespace Server
{
    public class RequestHandler
    {
        private String rawRequest;
        private const bool debugMode = true;
        private Response r;

        public RequestHandler(String rawRequest)
        {
            this.rawRequest = rawRequest;
        }

        public byte[] HandleRequest()
        {
            try
            {
                Request newRequest = ParseRequest();
                Validation isValid = ValidateRequest(newRequest);
                if (isValid != Validation.OK)
                    return MakeResponse(isValid).Format();
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
                        throw new ArgumentException("UnknownMethod");
                }
            }
            catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentException || e is ArgumentNullException)
            {
                r = MakeResponse(400, "", e.ToString());
            }
            catch (Exception e)
            {
                r = MakeResponse(500, "", e.ToString());
            }

            return r.Format();
        }

        private Request ParseRequest()
        {
            Regex regex = new Regex(@"^(?<method>[\w]+)\s(?<url>(https?:\/\/)?([a-zA-Z\d\.\-_]+\.)*[a-zA-Z]+(:\d{1,5})?)?\/(?<resource>[a-zA-Z\/\d&_]*)(\?(?<queries>(?<query>&?(?<queryName>[a-zA-Z\d_\-]+)=(?<queryValue>[a-zA-Z\d_\-]+))*))?\s(?<httpVersion>[\w\/\d\.]+)\r\n(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[a-zA-Z\,\.:\/\?\d&_]+)\r\n)+\r\n(?<content>[\d\D]*)$");
            if (!regex.IsMatch(rawRequest))
                throw new ArgumentException("Invalid request");
            GroupCollection groups = regex.Matches(rawRequest)[0].Groups;
            string method = groups["method"].Value.ToUpper();
            string url = groups["url"].Value;
            string resource = groups["resource"].Value;
            CaptureCollection names = groups["queryName"].Captures;
            CaptureCollection values = groups["queryValue"].Captures;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            for (int i = 0; i < names.Count; i++)
                queries.Add(names[i].Value, values[i].Value);
            string httpVersion = groups["httpVersion"].Value;
            names = groups["headerName"].Captures;
            values = groups["headerValue"].Captures;
            List<Header> headers = new List<Header>();
            for (int i = 0; i < names.Count; i++)
                if (!Header.Contains(headers, names[i].Value))
                    headers.Add(new Header(names[i].Value.ToUpper(), values[i].Value));
                else
                    throw new ArgumentException("DuplicateHeader");
            string content = groups["content"].Value;
            Request parsing = new Request(method, url, resource, queries, httpVersion, headers, content);
            return parsing;
        }

        private Validation ValidateRequest(Request req)
        {
            if (req.HttpVersion != "HTTP/1.1")
                return Validation.HttpVersionNotSupported;

            // check Host header
            List<Header> headers = req.Headers;
            if (!Header.Contains(headers, "HOST"))
                return Validation.NoHost;

            // Host header validity
            string hostValue = Header.GetValueByName(headers, "HOST");
            Regex hostRegex = new Regex(@"^([a-zA-Z\d\.\-_]+\.)*[a-zA-Z]+(:\d{1,5})?$");
            if (!hostRegex.IsMatch(hostValue))
                return Validation.InvalidHost;

            // if full URL was set in resource part, its Host header should match it
            string url = req.Url;
            if (url.StartsWith("http"))
            {
                int hostFromUrlIndex = url.IndexOf("://") + 3;
                string hostFromUrl = url.Substring(hostFromUrlIndex, url.Length - hostFromUrlIndex);
                if (hostFromUrl != hostValue)
                    return Validation.HostMismatch;
            }

            if (req.Method == "POST" && !Header.Contains(headers, "CONTENT-LENGTH"))
                return Validation.NoContentLength;

            return Validation.OK;
        }

        private Response ProcessGet(Request req)
        {
            Response r;
            string res = req.Resource;
            switch (res)
            {
                case "cars":
                    r = GetCars(req);
                    break;
                case "user":
                    r = GetUser(req);
                    break;
                default:
                    r = MakeResponse(404, "", req.Resource);
                    break;
            }
            return r;
        }

        private Response ProcessPost(Request req)
        {
            Response r = MakeResponse(201, "");
            switch (req.Resource)
            {
                case "CARS":
                    AddCar(System.Text.Encoding.ASCII.GetBytes(req.Content));
                    break;
                case "SIGNUP":
                    {
                        bool success = true;
                        //AddUser(System.Text.Encoding.ASCII.GetBytes(req.Content));
                        if (!success)
                            r = MakeResponse(400, "This username already exists", "");
                    }
                    break;
                case "LOGIN":
                    //r = LogIn(req.Content);
                    break;

                default:
                    r = MakeResponse(404, "", req.Resource);
                    break;
            }
            return r;
        }

        private Response ProcessDelete(Request req)
        {
            Response r = MakeResponse(200, "");
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
                    r = MakeResponse(404, "", req.Resource);
                    break;
            }
            return r;
        }

        private Response GetCars(Request req)
        {
            int id = -1, resultAmount = -1;
            bool getSorted = false, getById = false, amountSet = false;
            ArgumentException incompatible = new ArgumentException("Incompatible queries");
            Type enumType = typeof(SortingCriteria);
            SortingCriteria criteria = (SortingCriteria)Enum.Parse(enumType, "Unknown");
            Dictionary<string, string> queries = req.Queries;
            foreach (KeyValuePair<string, string> kvp in queries)
            {
                switch (kvp.Key)
                {
                    case "SORTBY":
                        {
                            if (getById)
                                throw incompatible;
                            getSorted = true;
                            string sortBy = kvp.Value;
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
                            id = int.Parse(kvp.Value);
                        }
                        break;
                    case "RESULTAMOUNT":
                        {
                            if (getById)
                                throw incompatible;
                            resultAmount = int.Parse(kvp.Value);
                            amountSet = true;
                        }
                        break;
                    default:
                        throw new ArgumentException($"Unknown query: {kvp.Key}");
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

            return MakeResponse(200, responseBody);
        }

        private int GetId(Request req)
        {
            Dictionary<string, string> queries = req.Queries;
            string idValue;
            try
            {
                idValue = queries["ID"];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("ID is required");
            }
            int id = int.Parse(idValue);
            return id;
        }

        private Response GetUser(Request req)
        {
            int id = GetId(req);
            byte[] responseBody = new UserList(new Logger()).JsonGetUser(id.ToString());
            return MakeResponse(200, responseBody);
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
            new UserList(new Logger()).DeleteUser(id.ToString());
        }

        private Response MakeResponse(Validation v)
        {
            string debugOutput = v.ToString();
            int statusCode = 0;
            if (v == Validation.HttpVersionNotSupported)
                statusCode = 505;
            else if (v == Validation.NoContentLength)
                statusCode = 411;
            else
                statusCode = 400;
            return MakeResponse(statusCode, "", debugOutput);
        }

        private Response MakeResponse(int statusCode, string content, string debugOutput)
        {
            if (debugMode)
                Debug.WriteLine(debugOutput);
            return MakeResponse(statusCode, System.Text.Encoding.ASCII.GetBytes(content));
        }

        private Response MakeResponse(int statusCode, string content)
        {
            return MakeResponse(statusCode, System.Text.Encoding.ASCII.GetBytes(content));
        }

        private Response MakeResponse(int statusCode, byte[] content)
        {
            Response r = new Response(statusCode);
            r.Content = content;
            List<Header> headers = new List<Header>();
            headers.Add(new Header("Connection", "close"));
            headers.Add(new Header("Date", DateTime.UtcNow.ToString()));
            headers.Add(new Header("Server", "UnquestionableSolutions"));
            headers.Add(new Header("Content-Length", content.Length.ToString()));
            r.Headers = headers;
            return r;
        }


        private Response LogIn(byte[] loginData)
        {
            string loginDataStr = System.Text.Encoding.ASCII.GetString(loginData);
            return new Response(100);
        }

        enum Validation
        {
            HttpVersionNotSupported,
            InvalidHost,
            HostMismatch,
            NoContentLength,
            NoHost,
            OK
        };
    }
}