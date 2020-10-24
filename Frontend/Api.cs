using DataTypes;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
namespace Frontend
{

    public class Api
    {
        private Response r = null;
        public List<Car> GetCars()
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "cars";
            r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public List<Car> GetCars(int resultAmount)
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "cars";
            req.Queries.Add("result_amount", resultAmount.ToString());
            r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public List<Car> SortBy(SortingCriteria sortBy, int? resultAmount = null, List<Car> carListToSort = null)
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "cars";
            req.Queries.Add("sortby", sortBy.ToString());
            if (resultAmount != null)
                req.Queries.Add("result_amount", resultAmount.ToString());
            if (carListToSort != null)
            {
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                byte[] listContent = JsonSerializer.SerializeToUtf8Bytes<List<Car>>(carListToSort);
                req.Headers.Add(new Header("Content-length", listContent.Length.ToString()));
                req.Content = Encoding.ASCII.GetString(listContent);
            }
            r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public List<Car> Filter(CarFilters filters, SortingCriteria? sortBy = null, int? resultAmount = null)
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "cars/filters";
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
            r = GetResponse(req);
            return JsonSerializer.Deserialize<List<Car>>(r.Content);
        }

        public Car GetCar(int id)
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "cars";
            req.Queries.Add("id", id.ToString());
            r = GetResponse(req);
            return JsonSerializer.Deserialize<Car>(r.Content);
        }

        public int? AddCar(Car car)
        {
            Request req = new Request();
            req.Method = "POST";
            req.Resource = "cars";
            req.Headers.Add(new Header("Content-type", MakeType("json")));
            byte[] carContent = JsonSerializer.SerializeToUtf8Bytes<Car>(car);
            req.Headers.Add(new Header("Content-length", carContent.Length.ToString()));
            req.Content = Encoding.ASCII.GetString(carContent);
            r = GetResponse(req);
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

        public bool DeleteCar(int id)
        {
            Request req = new Request();
            req.Method = "DELETE";
            req.Resource = "cars";
            req.Queries.Add("id", id.ToString());
            r = GetResponse(req);
            bool result;
            if (string.IsNullOrEmpty(req.Content))
                result = true;
            else
                result = false;
            return result;
        }

        public bool AddUser(User user)
        {
            Request req = new Request();
            req.Method = "POST";
            req.Resource = "users";
            byte[] userContent = JsonSerializer.SerializeToUtf8Bytes<User>(user);
            req.Content = userContent.ToString();
            req.Queries.Add("Content-type", MakeType("json"));
            req.Queries.Add("Content-length", userContent.Length.ToString());
            r = GetResponse(req);
            bool added = false;
            if (r.StatusCode == 201)
                added = true;
            return added;
        }

        public bool DeleteUser(string username)
        {
            Request req = new Request();
            req.Method = "DELETE";
            req.Resource = "cars";
            req.Queries.Add("username", username);
            r = GetResponse(req);
            bool deleted = false;
            if (string.IsNullOrEmpty(Encoding.ASCII.GetString(r.Content)))
                deleted = true;
            return deleted;
        }

        public User GetUser(string username)
        {
            Request req = new Request();
            req.Method = "GET";
            req.Resource = "users";
            req.Queries.Add("username", username);
            r = GetResponse(req);
            return JsonSerializer.Deserialize<User>(r.Content);
        }

        private Response GetResponse(Request req)
        {
            return Client.FromString2Response(Client.GetRawResponse(req));
        }

        private string MakeType(string key)
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

    }
}