using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using DataTypes;

namespace Frontend
{
    public class Api
    {
        public static List<Car> GetCars()
        {
            Request req = reqInnit("GET", "cars");
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public static List<Car> GetCars(int resultAmount)
        {
            Request req = reqInnit("GET", "cars");
            req.Queries.Add("result_amount", resultAmount.ToString());
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public static List<Car> SortBy(SortingCriteria sortBy, int? resultAmount = null, List<Car> carListToSort = null)
        {
            Request req = reqInnit("GET", "cars");
            req.Queries.Add("sortby", sortBy.ToString());
            if (resultAmount != null)
                req.Queries.Add("result_amount", resultAmount.ToString());
            if (carListToSort != null)
            {
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                byte[] listContent = JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort);
                req.Headers.Add(new Header("Content-length", listContent.Length.ToString()));
                req.Content = listContent;
            }
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public static List<Car> SearchCars(CarFilters filters, SortingCriteria? sortBy = null, int? resultAmount = null)
        {
            Request req = reqInnit("GET", "cars/filters");
            if (resultAmount != null)
                req.Queries.Add("result_amount", resultAmount.ToString());
            if (sortBy != null)
                req.Queries.Add("sort_by", sortBy.ToString());
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
            if (!string.IsNullOrEmpty(filters.Username))
                req.Queries.Add("username", filters.Username);
            if (filters.YearFrom.HasValue)
                req.Queries.Add("year_from", filters.YearFrom.ToString());
            if (filters.YearTo.HasValue)
                req.Queries.Add("year_to", filters.YearTo.ToString());
            if (filters.FuelType.HasValue)
                req.Queries.Add("fuel_type", filters.FuelType.ToString());
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public static Car GetCar(int id)
        {
            Request req = reqInnit("GET", "cars");
            req.Queries.Add("id", id.ToString());
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<Car>(r.Content);
        }

        public static int? AddCar(Car car)
        {
            Request req = reqInnit("POST", "cars");
            req.Headers.Add(new Header("Content-type", MakeType("json")));
            byte[] carContent = JsonSerializer.SerializeToUtf8Bytes<Car>(car);
            req.Headers.Add(new Header("Content-length", carContent.Length.ToString()));
            req.Content = carContent;
            Response r = GetResponse(req);
            int? id;
            switch (r.StatusCode)
            {
                case 201:
                    string locationValue = Header.GetValueByName(r.Headers, "location");
                    int lastSlash = locationValue.LastIndexOf("/");
                    string idInString = locationValue.Substring(lastSlash, locationValue.Length - lastSlash - 1);
                    id = int.Parse(idInString);
                    break;
                default:
                    id = null;
                    break;
            }
            return id;
        }

        public static bool DeleteCar(int id)
        {
            Request req = reqInnit("DELETE", "cars");
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
            Request req = reqInnit("POST", "users");
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
            Request req = reqInnit("DELETE", "cars");
            req.Queries.Add("username", username);
            Response r = GetResponse(req);
            bool deleted = false;
            if (r.Content.Length == 0)
                deleted = true;
            return deleted;
        }

        public static User GetUser(string username)
        {
            Request req = reqInnit("GET", "users");
            req.Queries.Add("username", username);
            Response r = GetResponse(req);
            return JsonSerializer.Deserialize<User>(r.Content);
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
            return contentType;
        }

        private static Request reqInnit(string method, string resource)
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