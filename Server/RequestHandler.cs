using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Backend;
using DataTypes;

namespace Server
{
    public class RequestHandler
    {
        private String rawRequest;
        private Response r;
        private ICarDb carDb;
        private IUserDb userDb;
        private Logger logger;
        private string protocol, host;
        private int port;
        public RequestHandler(String rawRequest, ICarDb carDb, IUserDb userDb, Logger logger, string protocol, string host, int port)
        {
            this.rawRequest = rawRequest;
            this.carDb = carDb;
            this.userDb = userDb;
            this.logger = logger;
            this.protocol = protocol;
            this.host = host;
            this.port = port;
        }

        public byte[] HandleRequest()
        {
            try
            {
                Request newRequest = ParseRequest();
                Validation isValid = ValidateRequest(newRequest);
                if (isValid != Validation.OK)
                    r = MakeResponse(isValid);
                else
                    switch (newRequest.Method)
                    {
                        case "GET":
                            ProcessGet(newRequest);
                            break;
                        case "POST":
                            ProcessPost(newRequest);
                            break;
                        case "DELETE":
                            ProcessDelete(newRequest);
                            break;
                        default:
                            r = MakeResponse(501);
                            break;
                    }
            }
            catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentException || e is ArgumentNullException)
            {
                logger.LogException(e);
                r = MakeResponse(400);
            }
            catch (Exception e)
            {
                logger.LogException(e);
                r = MakeResponse(500);
            }

            return r.Format();
        }

        private Request ParseRequest()
        {
            Regex regex = new Regex(@"^(?<method>[\w]+)\s(?<url>https?:\/\/([a-zA-Z\d\.\-_]+\.)*[a-zA-Z]+(:\d{1,5})?)?\/(?<resource>[a-zA-Z\/\d&_]*)(\?(?<queries>(?<query>&?(?<queryName>[a-zA-Z\d_\-]+)=(?<queryValue>[a-zA-Z\d_\-]+))*))?\s(?<httpVersion>[\w\/\d\.]+)\r\n(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[a-zA-Z\,\.:\/\?\d&_]+)\r\n)+\r\n(?<content>[\d\D]*)$");
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

        private void ProcessGet(Request req)
        {
            string res = req.Resource;
            switch (res)
            {
                case "cars":
                    GetCars(req.Queries);
                    break;
                case "cars/filtered":
                    GetFilteredCars(req.Queries);
                    break;
                case "user":
                    GetUser(req.Queries["username"]);
                    break;
                default:
                    r = MakeResponse(404);
                    break;
            }
        }

        private void ProcessPost(Request req)
        {
            switch (req.Resource)
            {
                case "car":
                    //if (!Verify(req))
                    //return;
                    AddCar(System.Text.Encoding.ASCII.GetBytes(req.Content));
                    break;
                case "signup":
                    AddUser(System.Text.Encoding.ASCII.GetBytes(req.Content));
                    break;
                case "login":
                    if (req.Queries.ContainsKey("username") && req.Queries.ContainsKey("hashedpassword"))
                        Login(req.Queries["username"], req.Queries["hashedpassword"]);
                    else
                        r = MakeResponse(400);
                    break;
                default:
                    r = MakeResponse(404);
                    break;
            }
        }

        private void ProcessDelete(Request req)
        {
            //if (!Verify(req))
            //return;
            bool result = true;
            switch (req.Resource)
            {
                case "car":
                    result = DeleteCar(int.Parse(req.Queries["id"]));
                    break;
                case "user":
                    result = DeleteUser(req.Queries["username"]);
                    break;
                default:
                    r = MakeResponse(404);
                    break;
            }
            if (!result)
                r = MakeResponse(200, SetContent("Deletion failed"), "text/plain");
            else
                r = MakeResponse(200);
        }

        private void GetCars(Dictionary<string, string> queries)
        {
            int id = -1, resultAmount = -1;
            bool getSorted = false, getById = false, amountSet = false;
            ArgumentException incompatible = new ArgumentException("Incompatible queries");
            Type enumType = typeof(SortingCriteria);
            SortingCriteria criteria = (SortingCriteria)Enum.Parse(enumType, "Unknown");
            if (queries.ContainsKey("id"))
            {
                id = int.Parse(queries["id"]);
                getById = true;
            }
            if (queries.ContainsKey("sortby"))
            {
                getSorted = true;
                if (getById)
                    throw incompatible;
                string sortBy = queries["sortby"];
                foreach (string name in SortingCriteria.GetNames(enumType))
                {
                    if (name == sortBy)
                    {
                        criteria = (SortingCriteria)Enum.Parse(enumType, name);
                        break;
                    }
                }
            }
            if (queries.ContainsKey("resultamount"))
            {
                if (getById)
                    throw incompatible;
                resultAmount = int.Parse(queries["resultamount"]);
                amountSet = true;
            }

            byte[] responseBody;
            if (getById)
                responseBody = carDb.GetCar(id);
            else if (getSorted && amountSet)
                responseBody = carDb.SortBy(criteria, resultAmount);
            else if (getSorted)
                responseBody = carDb.SortBy(criteria);
            else if (amountSet)
                responseBody = carDb.GetCarList(resultAmount);
            else
                responseBody = carDb.GetCarList();

            r = MakeResponse(200, responseBody);
        }

        private void GetUser(string username)
        {
            byte[] responseBody = userDb.GetUser(username);
            r = MakeResponse(200, responseBody);
        }

        private void AddCar(byte[] carData)
        {
            bool result = carDb.AddCar(carData);
            if (result)
            {
                r = MakeResponse(201);
                int id = new CarList(logger).lastCarId;
                r.Headers.Add(new Header("Location", "{protocol}://{host}:{port}/cars/{id}"));
            }
            else
                r = MakeResponse(200);
        }

        private void AddUser(byte[] userData)
        {
            bool result = userDb.AddUser(userData);
            if (result)
                r = MakeResponse(201);
            else
                r = MakeResponse(200);
        }

        private bool DeleteCar(int id)
        {
            return carDb.DeleteCar(id);
        }

        private bool DeleteUser(string username)
        {
            return userDb.DeleteUser(username);
        }

        private Response MakeResponse(Validation v)
        {
            int statusCode = 0;
            if (v == Validation.HttpVersionNotSupported)
                statusCode = 505;
            else if (v == Validation.NoContentLength)
                statusCode = 411;
            else
                statusCode = 400;
            return MakeResponse(statusCode);
        }

        private Response MakeResponse(int statusCode)
        {
            return MakeResponse(statusCode, SetContent(""));
        }

        private Response MakeResponse(int statusCode, byte[] content, string contentType = "application/json")
        {
            Response r = new Response(statusCode);
            r.Content = content;
            List<Header> headers = new List<Header>();
            headers.Add(new Header("Connection", "close"));
            headers.Add(new Header("Date", DateTime.Now.ToUniversalTime().ToString("r")));
            headers.Add(new Header("Server", "UnquestionableSolutions"));
            if (content.Length > 0)
                headers.Add(new Header("Content-Type", "{contentType}; charset=utf-8"));
            headers.Add(new Header("Content-Length", content.Length.ToString()));
            r.Headers = headers;
            return r;
        }

        private void Login(string username, string hashedPassword)
        {
            bool success = userDb.Authenticate(username, hashedPassword);
            if (!success)
                r = MakeResponse(400);
            else
                r = MakeResponse(201);
        }

        private void GetFilteredCars(Dictionary<string, string> queries)
        {
            CarFilters cf = new CarFilters();
            if (queries.ContainsKey("priceFrom"))
                cf.PriceFrom = int.Parse(queries["priceFrom"]);
            if (queries.ContainsKey("priceTo"))
                cf.PriceTo = int.Parse(queries["priceTo"]);
            if (queries.ContainsKey("username"))
                cf.Username = queries["username"];
            if (queries.ContainsKey("yearFrom"))
                cf.YearFrom = int.Parse(queries["yearFrom"]);
            if (queries.ContainsKey("yearTo"))
                cf.YearTo = int.Parse(queries["yearTo"]);
            if (queries.ContainsKey("fuelType"))
                cf.FuelType = (FuelType)Enum.Parse(typeof(FuelType), queries["fuelType"]);
            r = MakeResponse(200, carDb.Filter(cf));
        }

        private byte[] SetContent(string output)
        {
            return System.Text.Encoding.ASCII.GetBytes(output);
        }

        private bool Verify(Request req)
        {
            bool verified = Clients.Verify(int.Parse(req.Queries["session"]));
            if (!verified)
                r = MakeResponse(401);
            return verified;
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