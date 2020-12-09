using DataTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend
{
    public interface IApiWrapper
    {
        public event Action NoServerResponse;
        Task<bool> PingServer();
        Task<Response> DeleteUser(string username, string password);
        Task<Response> DeleteAd(int id, string username, string password);
        Task<(Car ad, Response response)> GetAd(int id);
        Task<(List<Car> adList, Response response)> GetFilteredAds(CarFilters filters, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<(List<Car> adList, Response response)> GetSortedAds(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<(User user, Response response)> GetUser(string username, string password);
        Task<(List<Car> adList, Response response)> GetUserLikedAds(string username, string password, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<(List<Car> adList, Response response)> GetUserUploadedAds(string username, SortingCriteria sortBy, bool sortAscending, int startIndex, int amount);
        Task<Response> PostAd(Car car, string username, string password);
        Task<Response> PostUser(User user);
        Task<Response> UpdateUser(string username, string password, User user);
        Task<Response> UpdateAd(Car car, string username, string password);
        Task<Response> DeleteUsers(string[] usernames, string username, string password);
        Task<Response> DeleteAds(int[] ids, string username, string password);
        Task<(List<Car> adList, Response response)> GetDisabledAds(string username, string password);
        Task<(List<User> users, Response response)> GetDisabledUsers(string username, string password);
        Task<Response> DisableUsers(string[] usernames, string username, string password);
        Task<Response> HideAds(int[] ids, string username, string password);
        Task<Response> EnableUsers(string[] usernames, string username, string password);
        Task<(User user, Response response)> GetFullUser(string user, string username, string password);
        Task<(List<Car> adList, Response response)> GetAds(int[] ids);
        Task<Response> UnhideAds(int[] ids, string username, string password);
    }

    public enum Response
    {
        Ok,
        InvalidResponse,
        NoResponse
    }
}