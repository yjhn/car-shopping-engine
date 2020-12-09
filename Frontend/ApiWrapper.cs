using DataTypes;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Frontend
{
    public class ApiWrapper : IApiWrapper
    {
        private readonly BasicAuthenticationCredentials credentials = new BasicAuthenticationCredentials();
        private readonly Uri _serverUri;
        private readonly IServer _api;
        private readonly Ping _ping = new Ping();
        public event Action NoServerResponse = delegate { };

        public ApiWrapper(Uri serverUri)
        {
            _serverUri = serverUri;
            _api = new Server(_serverUri, credentials);
        }

        public async Task<bool> PingServer()
        {
            var reply = await _ping.SendPingAsync(_serverUri.Host);
            return reply.Status == IPStatus.Success;
        }

        public async Task<Response> PostUser(User user)
        {
            try
            {
                var result = await _api.PostUserAsync(ConvertToFrontendUser(user));
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<(User user,Response response)> GetUser(string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                var result = await _api.GetUserAsync(username);
                return (ConvertToUser(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null, Response.NoResponse);
            }
        }

        public async Task<Response> DeleteUser(string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DeleteUserAsync(username);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> UpdateUser(string username, string password, User user)
        {
            PrepareApi(username, password);
            try
            {
                await _api.PutUserAsync(ConvertToFrontendUser(user),username);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<(Car ad,Response response)> GetAd(int id)
        {
            try
            {
                var car = await _api.GetAdAsync(id);
                return (ConvertToCar(car),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<Response> PostAd(Car car, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                var result = await _api.PostAdAsync(ConvertToFrontendCar(car), username);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> UpdateAd(Car car, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.PutAdAsync(ConvertToFrontendCar(car), username);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                // this happens when server returns invalid response code (this means that user has set some value to some shit)
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                // this happens when there is no connection
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> DeleteAd(int id, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DeleteAdAsync(id);
                return Response.Ok;
            }
            catch (HttpOperationException) { return Response.InvalidResponse; }
            catch (HttpRequestException) { NoServerResponse.Invoke(); return Response.NoResponse; }
        }

        public async Task<(List<Car> adList,Response response)> GetSortedAds(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetSortedAdsAsync((int)sortBy, sortAscending, startIndex, amount);
                return (GetCarList(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<(List<Car> adList, Response response)> GetAds(int[] ids)
        {
            try
            {
                var result = await _api.GetAdsAsync(GetNullableIntList(ids));
                return (GetCarList(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<(List<Car> adList, Response response)> GetFilteredAds(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetFilteredAdsAsync((int)sortBy, sortAscending, startIndex, amount, filters.Brand, filters.Model, filters.Used, filters.PriceFrom,
                    filters.PriceTo, filters.Username, filters.YearFrom, filters.YearTo, (int?)filters.FuelType, (int?)filters.ChassisType);
                return (GetCarList(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<(List<Car> adList, Response response)> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            PrepareApi(username, password);
            try
            {
                var result = await _api.GetUserLikedAdsAsync(username, (int)sortBy, sortAscending, startIndex, amount);
                return (GetCarList(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<(List<Car> adList, Response response)> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            try
            {
                var result = await _api.GetUserUploadedAdsAsync(username, (int)sortBy, sortAscending, startIndex, amount);
                return (GetCarList(result),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }


        public async Task<Response> DeleteUsers(string[] usernames, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DeleteUsersAsync(usernames);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> DeleteAds(int[] ids, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DeleteAdsAsync(GetNullableIntList(ids));
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<(List<Car> adList, Response response)> GetDisabledAds(string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                var ads = await _api.GetDisabledAdsAsync();
                return (GetCarList(ads),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<(List<User> users, Response response)> GetDisabledUsers(string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                var users = await _api.GetDisabledUsersAsync();
                return (GetUserList(users), Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }

        public async Task<Response> DisableUsers(string[] usernames, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DisableUsersAsync(usernames);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> HideAds(int[] ids, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.DisableAdsAsync(GetNullableIntList(ids));
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> EnableUsers(string[] usernames, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.EnableUsersAsync(usernames);
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<Response> UnhideAds(int[] ids, string username, string password)
        {
            PrepareApi(username, password);
            try
            {
                await _api.EnableAdsAsync(GetNullableIntList(ids));
                return Response.Ok;
            }
            catch (HttpOperationException)
            {
                return Response.InvalidResponse;
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return Response.NoResponse;
            }
        }

        public async Task<(User user, Response response)> GetFullUser(string user, string username,string password)
        {
            PrepareApi(username, password);
            try
            {
                var fullUser = await _api.GetFullUserAsync(user);
                return (ConvertToUser(fullUser),Response.Ok);
            }
            catch (HttpOperationException)
            {
                return (null,Response.InvalidResponse);
            }
            catch (HttpRequestException)
            {
                NoServerResponse.Invoke();
                return (null,Response.NoResponse);
            }
        }


        // For HTTP Basic Auth
        private void PrepareApi(string username, string password)
        {
            // update credentials if the user has changed
            //if (credentials.UserName != username || credentials.Password != password)
            //{
                credentials.UserName = username;
                credentials.Password = password;
            //}
        }



        // Converter methods //

        private static List<int?> GetNullableIntList(int[] ints)
        {
            var a = new List<int?>();
            foreach(int i in ints)
            {
                a.Add(i);
            }
            return a;
        }

        private static List<User> GetUserList(IList<Models.User> list)
        {
            List<User> users = new List<User>();
            foreach (Models.User u in list)
            {
                users.Add(ConvertToUser(u));
            }
            return users;
        }

        private static List<Car> GetCarList(IList<Models.Car> list)
        {
            List<Car> vehicles = new List<Car>();
            foreach (Models.Car c in list)
            {
                vehicles.Add(ConvertToCar(c));
            }
            return vehicles;
        }

        private static Models.Car ConvertToFrontendCar(Car c)
        {
            var car = new Models.Car()
            {
                Id = c.Id,
                UploaderUsername = c.UploaderUsername,
                Price = c.Price,
                UploadDate = c.UploadDate,
                Brand = c.Brand,
                Model = c.Model,
                Used = c.Used,
                DateOfPurchase = ConvertToFrontendYearMonth(c.DateOfPurchase),
                Engine = ConvertToFrontendEngine(c.Engine),
                FuelType = (int)c.FuelType,
                ChassisType = (int)c.ChassisType,
                Color = c.Color,
                GearboxType = (int)c.GearboxType,
                TotalKilometersDriven = c.TotalKilometersDriven,
                DriveWheels = (int)c.DriveWheels,
                Defects = c.Defects,
                SteeringWheelPosition = (int)c.SteeringWheelPosition,
                NumberOfDoors = (int)c.NumberOfDoors,
                NumberOfCylinders = c.NumberOfCylinders,
                NumberOfGears = c.NumberOfGears,
                Seats = c.Seats,
                NextVehicleInspection = ConvertToFrontendYearMonth(c.NextVehicleInspection),
                WheelSize = c.WheelSize,
                Weight = c.Weight,
                EuroStandard = (int)c.EuroStandard,
                OriginalPurchaseCountry = c.OriginalPurchaseCountry,
                Vin = c.Vin,
                AdditionalProperties = c.AdditionalProperties,
                Images = c.Images,
                Comment = c.Comment,
                Hidden = c.Hidden
            };

            return car;
        }

        private static Models.Engine ConvertToFrontendEngine(Engine engine)
        {
            if (engine == null)
            {
                return null;
            }
            Models.Engine e = new Models.Engine()
            {
                Hp = engine.Hp,
                Kw = engine.Kw,
                Volume = engine.Volume,
                Type = (int)engine.Type
            };
            return e;
        }

        private static Models.YearMonth ConvertToFrontendYearMonth(YearMonth dateOfPurchase)
        {
            if (dateOfPurchase == null)
            {
                return null;
            }
            Models.YearMonth y = new Models.YearMonth()
            {
                Year = dateOfPurchase.Year,
                Month = dateOfPurchase.Month
            };
            return y;
        }

        private static Car ConvertToCar(Frontend.Models.Car c)
        {
            var car = new Car()
            {
                Id = (int)c.Id,
                UploaderUsername = c.UploaderUsername,
                Price = (int)c.Price,
                UploadDate = (DateTime)c.UploadDate,
                Brand = c.Brand,
                Model = c.Model,
                Used = (bool)c.Used,
                DateOfPurchase = ConvertToYearMonth(c.DateOfPurchase),
                Engine = ConvertToEngine(c.Engine),
                FuelType = (FuelType)c.FuelType,
                ChassisType = (ChassisType)c.ChassisType,
                Color = c.Color,
                GearboxType = (GearboxType)c.GearboxType,
                TotalKilometersDriven = (int)c.TotalKilometersDriven,
                DriveWheels = (DriveWheels)c.DriveWheels,
                Defects = (List<string>)c.Defects,
                SteeringWheelPosition = (SteeringWheelPosition)c.SteeringWheelPosition,
                NumberOfDoors = (NumberOfDoors)c.NumberOfDoors,
                NumberOfCylinders = (int)c.NumberOfCylinders,
                NumberOfGears = (int)c.NumberOfGears,
                Seats = (int)c.Seats,
                NextVehicleInspection = ConvertToYearMonth(c.NextVehicleInspection),
                WheelSize = c.WheelSize,
                Weight = (int)c.Weight,
                EuroStandard = (EuroStandard)c.EuroStandard,
                OriginalPurchaseCountry = c.OriginalPurchaseCountry,
                Vin = c.Vin,
                AdditionalProperties = (List<string>)c.AdditionalProperties,
                Images = (List<string>)c.Images,
                Comment = c.Comment,
                Hidden = (bool)c.Hidden
            };

            return car;
        }

        private static Engine ConvertToEngine(Frontend.Models.Engine engine)
        {
            if (engine == null)
            {
                return null;
            }
            Engine e = new Engine()
            {
                Hp = (int)engine.Hp,
                Kw = (int)engine.Kw,
                Volume = (float?)engine.Volume,
                Type = (EngineType)engine.Type
            };
            return e;
        }

        private static YearMonth ConvertToYearMonth(Frontend.Models.YearMonth dateOfPurchase)
        {
            if (dateOfPurchase == null)
            {
                return null;
            }
            YearMonth y = new YearMonth()
            {
                Year = (int)dateOfPurchase.Year,
                Month = (int)dateOfPurchase.Month
            };
            return y;
        }

        private static User ConvertToUser(Frontend.Models.User u)
        {
            // get liked ads manually, because auto cast does not work
            var ads = new List<int>(0);
            foreach (int adId in u.LikedAds)
            {
                ads.Add(adId);
            }

            var user = new User()
            {
                Username = u.Username,
                HashedPassword = u.HashedPassword,
                LikedAds = ads,
                Phone = (long)u.Phone,
                Email = u.Email,
                Role = u.Role,
                Disabled = (bool)u.Disabled
            };
            return user;
        }

        private static Frontend.Models.User ConvertToFrontendUser(User u)
        {
            // get liked ads manually, because auto cast does not work
            var ads = new List<int?>(0);
            u.LikedAds.ForEach(id => ads.Add(id));

            var user = new Frontend.Models.User()
            {
                Username = u.Username,
                HashedPassword = u.HashedPassword,
                LikedAds = ads,
                Phone = u.Phone,
                Email = u.Email,
                Role = u.Role,
                Disabled = u.Disabled
            };
            return user;
        }
    }
}
