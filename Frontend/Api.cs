using DataTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Frontend
{
    public class Api : IApi
    {
        // event to tell the UI that there is no connection to server
        public event Action NoServerResponse = delegate { };


        // this is not needed
        //public Task<List<Car>> GetCars(int startIndex, int amount)
        //{
        //    return Task.Run<List<Car>>(() =>
        //    {
        //        Request req = ReqInit("GET", "cars");
        //        req.Queries.Add("amount", amount.ToString());
        //        req.Queries.Add("start_index", startIndex.ToString());
        //        Response r = GetResponse(req);
        //        if (r == null)
        //        {
        //            NoServerResponse.Invoke();
        //            return null;
        //        }
        //        return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
        //    });
        //}

        public Task<List<Car>> SortBy(SortingCriteria sortBy, int startIndex, int amount, bool sortAscending)
        {
            // to be able to await a task we first need to create it
            return Task.Run<List<Car>>(() =>
            {
                Request req = ReqInit("GET", "cars");
                req.Queries.Add("sort_by", sortBy.ToString());
                req.Queries.Add("amount", amount.ToString());
                req.Queries.Add("sort_ascending", sortAscending.ToString());
                req.Queries.Add("start_index", startIndex.ToString());
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
            });
        }

        public Task<List<Car>> SearchVehicles(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return Task.Run<List<Car>>(() =>
            {
                Request req = ReqInit("GET", "cars/filters");
                req.Queries.Add("amount", amount.ToString());
                req.Queries.Add("sort_by", sortBy.ToString());
                req.Queries.Add("sort_ascending", sortAscending.ToString());
                req.Queries.Add("start_index", startIndex.ToString());
                if (!string.IsNullOrEmpty(filters.Brand))
                    req.Queries.Add("brand", filters.Brand);
                if (!string.IsNullOrEmpty(filters.Model))
                    req.Queries.Add("model", filters.Model);
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
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.Content.Length > 0 ? JsonSerializer.Deserialize<List<Car>>(r.Content) : null;
            });
        }

        // this is not currently used and will probably not be used
        //public Task<Car> GetCar(int id)
        //{
        //    return Task.Run<Car>(() =>
        //    {
        //        Request req = ReqInit("GET", "cars");
        //        req.Queries.Add("id", id.ToString());
        //        Response r = GetResponse(req);
        //        if (r == null)
        //        {
        //            NoServerResponse.Invoke();
        //            return null;
        //        }
        //        return r.Content.Length > 0 ? JsonSerializer.Deserialize<Car>(r.Content) : null;
        //    });
        //}

        // this probably should not return int
        public Task<int?> AddCar(Car car)
        {
            return Task.Run<int?>(() =>
            {
                Request req = ReqInit("POST", "cars");
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                byte[] carContent = JsonSerializer.SerializeToUtf8Bytes<Car>(car);
                req.Headers.Add(new Header("Content-length", carContent.Length.ToString()));
                req.Content = carContent;
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                int? id;
                switch (r.StatusCode)
                {
                    case 201:
                        string locationValue = Header.GetValueByName(r.Headers, "LOCATION");
                        int lastSlash = locationValue.LastIndexOf("/");
                        string idInString = locationValue.Substring(lastSlash + 1, locationValue.Length - lastSlash - 1);
                        id = int.Parse(idInString);
                        break;
                    default:
                        id = null;
                        break;
                }
                return id;
            });
        }

        public Task<bool?> DeleteCar(int id)
        {
            return Task.Run<bool?>(() =>
            {
                Request req = ReqInit("DELETE", "cars");
                req.Queries.Add("id", id.ToString());
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.Content.Length > 0;
            });
        }

        public Task<bool?> AddUser(User user)
        {
            return Task.Run<bool?>(() =>
            {
                Request req = ReqInit("POST", "users");
                byte[] userContent = JsonSerializer.SerializeToUtf8Bytes<User>(user);
                req.Content = userContent;
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                req.Headers.Add(new Header("Content-length", userContent.Length.ToString()));
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.StatusCode == 201;
            });
        }

        public Task<bool?> DeleteUser(string username)
        {
            return Task.Run<bool?>(() =>
            {
                Request req = ReqInit("DELETE", "cars");
                req.Queries.Add("username", username);
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.Content.Length == 0;
            });
        }

        public Task<MinimalUser> GetUser(string username, string hashedPassword)
        {
            return Task.Run<MinimalUser>(() =>
            {
                Request req = ReqInit("POST", "users/login");
                string content = "username=" + username + "&hashed_password=" + hashedPassword;
                req.Headers.Add(new Header("Content-length", content.Length.ToString()));
                req.Content = Encoding.ASCII.GetBytes(content);
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                if (r.Content == null || r.Content.Length == 0)
                {
                    return null;
                }
                return JsonSerializer.Deserialize<MinimalUser>(r.Content);
            });
        }

        public Task<bool?> UpdateLikedAds(string token, List<int> likedAds)
        {
            return Task.Run<bool?>(() =>
            {
                Request req = ReqInit("POST", "users/update-liked-ads");
                byte[] likedAdsContent = JsonSerializer.SerializeToUtf8Bytes<List<int>>(likedAds);
                req.Headers.Add(new Header("token", token));
                req.Headers.Add(new Header("Content-length", likedAdsContent.Length.ToString()));
                req.Headers.Add(new Header("Content-type", MakeType("json")));
                req.Content = likedAdsContent;
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                return r.StatusCode == 200;
            });
        }

        public Task<List<Car>> GetSortedLikedCars(string token, int startIndex, int amount)
        {
            return Task.Run<List<Car>>(() =>
            {
                Request req = ReqInit("GET", "cars/liked");
                req.Queries.Add("amount", amount.ToString());
                req.Queries.Add("start_index", startIndex.ToString());
                req.Headers.Add(new Header("token", token));
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }
                // if server returns anything, it cannot be null (it may be an empty list)
                List<Car> likedCarList = JsonSerializer.Deserialize<List<Car>>(r.Content);
                return likedCarList;

            });
        }

        public Task<List<Car>> GetSortedUploadedCars(string username, int startIndex, int amount)
        {
            return Task.Run<List<Car>>(() =>
            {
                Request req = ReqInit("GET", "cars/uploaded");
                req.Queries.Add("amount", amount.ToString());
                req.Queries.Add("start_index", startIndex.ToString());
                req.Queries.Add("username", username);
                Response r = GetResponse(req);
                if (r == null)
                {
                    NoServerResponse.Invoke();
                    return null;
                }

                // if server returns anything, it cannot be null (it may be an empty list)
                List<Car> uploadedCarList = JsonSerializer.Deserialize<List<Car>>(r.Content);
                return uploadedCarList;
            }
 );
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

        private Request ReqInit(string method, string resource)
        {
            Request req = new Request
            {
                Method = method,
                Resource = resource,
                Queries = new Dictionary<string, string>(),
                Headers = new List<Header>()
            };
            return req;
        }

        private Response GetResponse(Request req)
        {
            return Client.FromStringToResponse(Client.GetRawResponse(req));
        }
    }
}