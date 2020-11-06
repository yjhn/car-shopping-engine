using Backend;
using DataTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Server
{
    public class RequestHandler
    {
        readonly private string _rawRequest;
        private Response _r;
        readonly private IDatabase _db;
        readonly private Logger _logger;
        public RequestHandler(string rawRequest, IDatabase db, Logger logger)
        {
            _rawRequest = rawRequest;
            _logger = logger;
            _db = db;
        }

        public byte[] HandleRequest(out bool isAllRequest)
        {
            try
            {
                Request newRequest = ParseRequest();
                Validation isValid = ValidateRequest(newRequest);
                if (isValid != Validation.OK)
                {
                    isAllRequest = false;
                    _r = MakeResponse(isValid);
                }
                else
                {
                    isAllRequest = true;
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
                            _r = MakeResponse(501);
                            break;
                    }
                }
            }
            catch (Exception e) when (e is ArgumentOutOfRangeException || e is ArgumentException || e is ArgumentNullException)
            {
                _logger.LogException(e);
                _r = MakeResponse(400);
                isAllRequest = false;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                _r = MakeResponse(500);
                isAllRequest = false;
            }

            return _r.Format();
        }

        private Request ParseRequest()
        {
            Regex regex = new Regex(@$"^(?<method>[\w]+) (?<url>https?:\/\/([a-zA-Z\d\.\-_]+\.)*[a-zA-Z]+(:\d{1,5})?)?\/(?<resource>[a-zA-Z\/\d&_]*)(\?(?<queries>(?<query>&?(?<queryName>[a-zA-Z\d_\-]+)=(?<queryValue>[a-zA-Z\d_\-~%\+]+))*))? (?<httpVersion>[\w\/\d\.]+){ServerConstants.HeaderSeparator}(?<headers>(?<headerName>[a-zA-Z\-]+):\s*(?<headerValue>[^\r\n]+){ServerConstants.HeaderSeparator})+{ServerConstants.HeaderSeparator}(?<content>[\d\D]*)$");
            if (!regex.IsMatch(_rawRequest))
                throw new ArgumentException("Invalid request");
            GroupCollection groups = regex.Matches(_rawRequest)[0].Groups;
            string method = groups["method"].Value.ToUpper();
            string url = groups["url"].Value;
            string resource = groups["resource"].Value;
            CaptureCollection names = groups["queryName"].Captures;
            CaptureCollection values = groups["queryValue"].Captures;
            Dictionary<string, string> queries = new Dictionary<string, string>();
            for (int i = 0; i < names.Count; i++)
                queries.Add(names[i].Value, WebUtility.UrlDecode(values[i].Value));
            string httpVersion = groups["httpVersion"].Value;
            names = groups["headerName"].Captures;
            values = groups["headerValue"].Captures;
            List<Header> headers = new List<Header>();
            for (int i = 0; i < names.Count; i++)
                if (!Header.Contains(headers, names[i].Value.ToUpper()))
                    headers.Add(new Header(names[i].Value.ToUpper(), values[i].Value));
                else
                    throw new ArgumentException("DuplicateHeader");
            byte[] content = Encoding.ASCII.GetBytes(groups["content"].Value);
            Request parsing = new Request(method, url, resource, queries, httpVersion, headers, content);
            return parsing;
        }

        private Validation ValidateRequest(Request req)
        {
            if (req.HttpVersion != ServerConstants.HttpVersion)
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
            if (!string.IsNullOrEmpty(url))
            {
                int hostFromUrlIndex = url.IndexOf("://") + 3;
                string hostFromUrl = url.Substring(hostFromUrlIndex, url.Length - hostFromUrlIndex);
                if (hostFromUrl != hostValue)
                    return Validation.HostMismatch;
            }
            if (Header.Contains(headers, "CONTENT-LENGTH"))
            {
                int contentLength = int.Parse(Header.GetValueByName(headers, "CONTENT-LENGTH"));
                if (req.Content.Length > contentLength)
                {
                    string contentString = Encoding.ASCII.GetString(req.Content);
                    contentString = contentString.Substring(0, contentLength);
                    req.Content = Encoding.ASCII.GetBytes(contentString);
                }
                else if (req.Content.Length < contentLength)
                    return Validation.RequestTimeout;
            }

            if (req.Content.Length > 0 && !Header.Contains(headers, "CONTENT-LENGTH"))
                return Validation.NoContentLength;
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
                    GetCars(req);
                    break;
                case "cars/filters":
                    GetFilteredCars(req.Queries);
                    break;
                case "cars/liked":
                    GetLikedCars(req.Queries, Header.GetValueByName(req.Headers, "TOKEN"));
                    break;
                case "cars/uploaded":
                    GetUploadedCars(req.Queries);
                    break;
                case "users":
                    GetUser(req.Queries["username"]);
                    break;
                default:
                    _r = MakeResponse(404);
                    break;
            }
        }

        private void ProcessPost(Request req)
        {
            string contentType = "application/x-www-form-urlencoded";
            if (Header.Contains(req.Headers, "CONTENT-TYPE"))
                contentType = Header.GetValueByName(req.Headers, "CONTENT-TYPE");
            Response unsupportedType = MakeResponse(415);
            switch (req.Resource)
            {
                case "cars":
                    //if (!Verify(req))
                    //return;
                    if (contentType.StartsWith("application/json"))
                        AddCar(req.Content);
                    else
                        _r = unsupportedType;
                    break;
                case "users":
                    if (contentType.StartsWith("application/json"))
                        AddUser(req.Content);
                    else
                        _r = unsupportedType;
                    break;
                case "users/login":
                    if (contentType == "application/x-www-form-urlencoded")
                        Login(Encoding.ASCII.GetString(req.Content));
                    else
                        _r = unsupportedType;
                    break;
                case "users/update-liked-ads":
                    if (contentType.StartsWith("application/json"))
                        updateAds(Header.GetValueByName(req.Headers, "TOKEN"), req.Content);
                    else
                        _r = unsupportedType;
                    break;
                default:
                    _r = MakeResponse(404);
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
                case "cars":
                    result = DeleteCar(int.Parse(req.Queries["id"]));
                    break;
                case "users":
                    result = DeleteUser(req.Queries["username"]);
                    break;
                default:
                    _r = MakeResponse(404);
                    break;
            }
            if (!result)
                _r = MakeResponse(200, SetContent("Deletion failed"), "text/plain");
            else
                _r = MakeResponse(200);
        }

        private void updateAds(string token, byte[] ads)
        {
            bool result = _db.UpdateLikedAds(token, ads);
            if (result)
                _r = MakeResponse(200);
            else
                _r = MakeResponse(404);
        }

        private void GetCars(Request req)
        {
            Dictionary<string, string> queries = req.Queries;
            int amount = 50, startIndex = 0;
            SortingCriteria? criteria = null;
            if (queries.ContainsKey("sort_by"))
            {
                criteria = GetSortingCriteria(queries["sort_by"]);
            }
            if (queries.ContainsKey("amount"))
            {
                amount = int.Parse(queries["amount"]);
            }
            if (queries.ContainsKey("start_index"))
            {
                startIndex = int.Parse(queries["start_index"]);
            }
            byte[] responseBody;
            if (criteria != null)
            {
                bool sortAscending = true;
                if (queries.ContainsKey("sort_ascending"))
                    sortAscending = bool.Parse(queries["sort_ascending"]);
                responseBody = _db.GetSortedCarsJson((SortingCriteria)criteria, sortAscending, startIndex, amount);
            }
            else
            {
                responseBody = new byte[0];
            }

            _r = MakeResponse(200, responseBody);
        }

        private void GetUser(string username)
        {
            byte[] responseBody = _db.GetUserInfoJson(username);
            _r = MakeResponse(200, responseBody);
        }

        private void AddCar(byte[] carData)
        {
            bool result = _db.AddCarJson(carData);
            if (result)
            {
                _r = MakeResponse(201);
                IDatabase cs = _db;
                int id = cs.GetLastCarId();
                _r.Headers.Add(new Header("Location", $"{ServerConstants.Scheme}://{ServerConstants.HostForClients}:{ServerConstants.Port}/cars/{id}"));
            }
            else
                _r = MakeResponse(204);
        }

        private void AddUser(byte[] userData)
        {
            if (_db.AddUserJson(userData))
            {
                _r = MakeResponse(201);
            }
            else
            {
                _r = MakeResponse(204);
            }
        }

        private bool DeleteCar(int id)
        {
            return _db.DeleteCar(id);
        }

        private bool DeleteUser(string username)
        {
            return _db.DeleteUser(username);
        }

        private Response MakeResponse(Validation v)
        {
            int statusCode = 0;
            if (v == Validation.HttpVersionNotSupported)
                statusCode = 505;
            else if (v == Validation.NoContentLength)
                statusCode = 411;
            else if (v == Validation.RequestTimeout)
                statusCode = 408;
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
            List<Header> headers = new List<Header>
            {
                new Header("Connection", "close"),
                new Header("Date", DateTime.Now.ToUniversalTime().ToString("r")),
                new Header("Server", "UnquestionableSolutions")
            };
            if (content.Length > 0)
                headers.Add(new Header("Content-type", $"{contentType}; charset=utf-8"));
            headers.Add(new Header("Content-length", content.Length.ToString()));
            r.Headers = headers;
            return r;
        }

        private void GetFilteredCars(Dictionary<string, string> queries)
        {
            SortingCriteria? criteria = null;
            int amount = 50, startIndex = 0;
            CarFilters cf = new CarFilters();
            if (queries.ContainsKey("brand"))
                cf.Brand = queries["brand"];
            if (queries.ContainsKey("model"))
                cf.Model = queries["model"];
            if (queries.ContainsKey("used"))
                cf.Used = bool.Parse(queries["used"]);
            if (queries.ContainsKey("price_from"))
                cf.PriceFrom = int.Parse(queries["price_from"]);
            if (queries.ContainsKey("price_to"))
                cf.PriceTo = int.Parse(queries["price_to"]);
            if (queries.ContainsKey("username"))
                cf.Username = queries["username"];
            if (queries.ContainsKey("year_from"))
                cf.YearFrom = int.Parse(queries["year_from"]);
            if (queries.ContainsKey("year_to"))
                cf.YearTo = int.Parse(queries["year_to"]);
            if (queries.ContainsKey("fuel_type"))
                cf.FuelType = (FuelType)Enum.Parse(typeof(FuelType), queries["fuel_type"]);
            if (queries.ContainsKey("chassis_type"))
                cf.ChassisType = (ChassisType)Enum.Parse(typeof(ChassisType), queries["chassis_type"]);
            if (queries.ContainsKey("amount"))
                amount = int.Parse(queries["amount"]);
            if (queries.ContainsKey("sort_by"))
                criteria = GetSortingCriteria(queries["sort_by"]);
            bool sortAscending = true;
            if (queries.ContainsKey("sort_ascending"))
                sortAscending = bool.Parse(queries["sort_ascending"]);
            if (queries.ContainsKey("start_index"))
                startIndex = int.Parse(queries["start_index"]);
            _r = MakeResponse(200, _db.GetFilteredCarsJson(cf, (SortingCriteria)criteria, sortAscending, startIndex, amount));
        }

        private void GetLikedCars(Dictionary<string, string> queries, string token)
        {
            int startIndex = int.Parse(queries["start_index"]);
            int amount = int.Parse(queries["amount"]);
            byte[] favouriteCars = _db.GetUserLikedAds(token, startIndex, amount);
            _r = MakeResponse(200, favouriteCars);
        }

        private void GetUploadedCars(Dictionary<string, string> queries)
        {
            int startIndex = int.Parse(queries["start_index"]);
            int amount = int.Parse(queries["amount"]);
            string username = queries["username"];
            byte[] uploadedCars = _db.GetUserUploadedAds(username, startIndex, amount);
            _r = MakeResponse(200, uploadedCars);
        }

        private byte[] SetContent(string output)
        {
            return System.Text.Encoding.ASCII.GetBytes(output);
        }

        private void Login(string loginData)
        {
            Regex loginValidation = new Regex(@"^username=(?<username>[\d\D]+)&hashed_password=(?<hashedPassword>[\d\D]+)$");
            if (!loginValidation.IsMatch(loginData))
                _r = MakeResponse(400);
            else
            {
                GroupCollection groups = loginValidation.Matches(loginData)[0].Groups;
                string username = groups["username"].Value;
                string hashedPassword = groups["hashedPassword"].Value;
                byte[] loginOperation = _db.Authenticate(username, hashedPassword);
                if (loginOperation != null)
                    _r = MakeResponse(200, loginOperation);
                else
                    _r = MakeResponse(400);
            }
        }

        private SortingCriteria? GetSortingCriteria(string criteriaString)
        {
            SortingCriteria? criteria = null;
            Type sortingType = typeof(SortingCriteria);
            foreach (string name in SortingCriteria.GetNames(sortingType))
            {
                if (name == criteriaString)
                {
                    criteria = (SortingCriteria)Enum.Parse(sortingType, name);
                    break;
                }
            }
            return criteria;
        }
    }

    enum Validation
    {
        HttpVersionNotSupported,
        InvalidHost,
        HostMismatch,
        NoContentLength,
        NoHost,
        RequestTimeout,
        OK
    };
}