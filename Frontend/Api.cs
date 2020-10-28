using DataTypes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Frontend
{
    public class Api
    {
        // event to tell the UI that there is no connection to server
        public static event Action noServerResponse = delegate {};

        public static List<Car> GetCars(int startIndex, int amount)
        {
            // TODO: adapt to server API changes
            Request req = reqInit("GET", "cars");
            req.Queries.Add("amount", amount.ToString());
            Response r = GetResponse(req);
            if(r == null)
            {
                noServerResponse.Invoke();
                return null;
            }
            return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
        }

        public static List<Car> SortBy(SortingCriteria sortBy, int startIndex, int amount, List<Car> carListToSort = null)
        {
            // TODO: adapt to server API changes
            Request req = reqInit("GET", "cars");
            req.Queries.Add("sortby", sortBy.ToString());
            req.Queries.Add("amount", amount.ToString());
            if (carListToSort != null)
            {
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                byte[] listContent = JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort);
                req.Headers.Add(new Header("Content-length", listContent.Length.ToString()));
                req.Content = listContent;
            }
            Response r = GetResponse(req);
            if(r == null)
            {
                return null;
            }
            return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
        }

        public static List<Car> SearchVehicles(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            // TODO: adapt to server API changes
            Request req = reqInit("GET", "cars/filters");
            req.Queries.Add("amount", amount.ToString());
            req.Queries.Add("sort_by", sortBy.ToString());
            req.Queries.Add("sort_ascending", sortAscending.ToString());
            if (!string.IsNullOrEmpty(filters.Brand))
                req.Queries.Add("brand", filters.Brand);
            if (!string.IsNullOrEmpty(filters.Model))
                req.Queries.Add("model", filters.Model);
            if (filters.Used.HasValue)
                req.Queries.Add("used", filters.Used.ToString());
            if (filters.PriceFrom.HasValue)
                req.Queries.Add("price_from", filters.PriceFrom.ToString());
            if (filters.PriceTo.HasValue)
                req.Queries.Add("price_to", filters.PriceTo.ToString());
            if (filters.Used.HasValue)
                req.Queries.Add("used", filters.Used.ToString());
            if (!string.IsNullOrEmpty(filters.Username))
                req.Queries.Add("username", filters.Username);
            if (filters.YearFrom.HasValue)
                req.Queries.Add("year_from", filters.YearFrom.ToString());
            if (filters.YearTo.HasValue)
                req.Queries.Add("year_to", filters.YearTo.ToString());
            if (filters.FuelType.HasValue)
                req.Queries.Add("fuel_type", filters.FuelType.ToString());
            if (filters.ChassisType.HasValue)
                req.Queries.Add("chassis_type", filters.ChassisType.ToString());
            Response r = GetResponse(req);
            return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
        }

        public static Car GetCar(int id)
        {
            Request req = reqInit("GET", "cars");
            req.Queries.Add("id", id.ToString());
            Response r = GetResponse(req);
            return r.Content.Length > 0 ? JsonSerializer.Deserialize<Car>(r.Content) : null;
        }

        public static int? AddCar(Car car)
        {
            Request req = reqInit("POST", "cars");
            req.Headers.Add(new Header("Content-type", MakeType("json")));
            byte[] carContent = JsonSerializer.SerializeToUtf8Bytes<Car>(car);
            req.Headers.Add(new Header("Content-length", carContent.Length.ToString()));
            System.Diagnostics.Debug.WriteLine("ilgis" + carContent.Length);
            req.Content = carContent;
            Response r = GetResponse(req);
            System.Diagnostics.Debug.WriteLine(System.Text.Encoding.ASCII.GetString(r.Format()));
            int? id;
            switch (r.StatusCode)
            {
                case 201:
                    string locationValue = Header.GetValueByName(r.Headers, "location");
 //                   int lastSlash = locationValue.LastIndexOf("/");
 //                   string idInString = locationValue.Substring(lastSlash, locationValue.Length - lastSlash - 1);
 //                   id = int.Parse(idInString);
                    break;
                default:
                    id = null;
                    break;
            }
            return id;
        }

        public static bool DeleteCar(int id)
        {
            Request req = reqInit("DELETE", "cars");
            req.Queries.Add("id", id.ToString());
            Response r = GetResponse(req);
            bool result;
            if (r.Content.Length > 0)
                result = true;
            else
                result = false;
            return result;
        }

        public static bool AddUser(User user)
        {
            Request req = reqInit("POST", "users");
            byte[] userContent = JsonSerializer.SerializeToUtf8Bytes<User>(user);
            req.Content = userContent;
            req.Headers.Add(new Header("Content-type", MakeType("json")));
            req.Headers.Add(new Header("Content-length", userContent.Length.ToString()));
            Response r = GetResponse(req);
            bool added = false;
            if (r.StatusCode == 201)
                added = true;
            return added;
        }

        public static bool DeleteUser(string username)
        {
            Request req = reqInit("DELETE", "cars");
            req.Queries.Add("username", username);
            Response r = GetResponse(req);
            bool deleted = false;
            if (r.Content.Length == 0)
                deleted = true;
            return deleted;
        }

        public static User GetUser(string username)
        {
            Request req = reqInit("GET", "users");
            req.Queries.Add("username", username);
            Response r = GetResponse(req);
            return r.Content.Length > 0 ? JsonSerializer.Deserialize<User>(r.Content) : null;
        }

        private static string MakeType(string key)
        {
            string contentType;
            switch (key)
            {
                case "json":
                    contentType = "application/json";
                    break;
                default:
                    contentType = "application/x-www-form-urlencoded";
                    break;
            }
            contentType += "; charset=utf-8";
            System.Diagnostics.Debug.WriteLine(contentType);
            return contentType;
        }

        private static Request reqInit(string method, string resource)
        {
            Request req = new Request();
            req.Method = method;
            req.Resource = resource;
            req.Queries = new Dictionary<string, string>();
            req.Headers = new List<Header>();
            return req;
        }

        private static Response GetResponse(Request req)
        {
            return Client.FromStringToResponse(Client.GetRawResponse(req));
        }
    }
}