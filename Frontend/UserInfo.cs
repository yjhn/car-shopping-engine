using DataTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Frontend
{
    public class UserInfo
    {
        private readonly IApi _api;
        //private readonly int _likedAdsInPage;

        //public bool CanFetchMoreLikedAds { get; private set; } = true;
        public string Username { get; private set; }
        public string Email { get; private set; }
        public long Phone { get; private set; }
        public List<int> LikedAds { get; private set; }

        public string Token { get; private set; }

        //public readonly List<Car> CarsLikedInCurrentSession = new List<Car>();

        public MinimalUser User
        {
            // use setter when logging in and out
            // when logging out, set this to null
            set
            {
                // only let a new user log in once the last has logged out
                if (value != null && Username == null)
                {
                    Token = value.Token;
                    // prefetch more ads in advance to know if there is more
                    //GetSortedLikedCars(value.Username, 0, 2 * _likedAdsInPage);
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Email = value.Email;
                    Phone = value.Phone;
                    LoginStateChanged.Invoke();
                }
                else if (value == null && Username != null)
                {
                    // this happens if user logs out
                    // update liked ads of the user who just logged out
                    UpdateLikedAds();
                    // reset user info
                    Username = null;
                    LikedAds = null;
                    Token = null;
                    Email = null;
                    Phone = -1;
                    //CanFetchMoreLikedAds = true;
                    // clear the liked cars list to prepare for another user
                    //CarsLikedInCurrentSession.Clear();
                    LoginStateChanged.Invoke();
                }
            }
        }

        public UserInfo(IApi api/*, int likedAdsInPage*/)
        {
            //_likedAdsInPage = likedAdsInPage;
            _api = api;
        }

        public Action LoginStateChanged = delegate { };

        public Task<bool?> UpdateLikedAds()
        {
            return _api.UpdateLikedAds(Token, LikedAds);
        }
        //public delegate void ListUpdated<T>(T addedItems);
        //public ListUpdated<List<Car>> LikedCarListUpdated = delegate { };

        //public async Task<List<Car>> GetLikedCarList()
        //{
        //    // use cached liked car list if it is available
        //    if (CarsLikedInCurrentSession != null)
        //    {
        //        return CarsLikedInCurrentSession;
        //    }
        //    else
        //    {
        //        CarsLikedInCurrentSession = await _api.GetSortedLikedCars(Token, 0, 100);
        //        return CarsLikedInCurrentSession;
        //    }
        //}

        //private async void GetSortedLikedCars(string username, int startIndex, int amount)
        //{
        //    // we only fetch anything if there is something to be fetched
        //    if (CanFetchMoreLikedAds)
        //    {
        //        // this will probably cause bugs when one user logs in then instantly out, then another instantly logs in
        //        List<Car> temp = await _api.GetSortedLikedCars(Token, startIndex, amount);
        //        // user might have logged out while we were fetching data
        //        // check if the same user is still logged in
        //        if (temp != null)
        //        {
        //            if (Username == username)
        //            {
        //                CarsLikedInCurrentSession.AddRange(temp);
        //                if (temp.Count < amount)
        //                {
        //                    CanFetchMoreLikedAds = false;
        //                }
        //                LikedCarListUpdated.Invoke(temp);
        //            }
        //        }
        //        else if (Username == username)
        //        {
        //            CanFetchMoreLikedAds = false;
        //        }
        //    }
        //}

        //public List<Car> GetLikedCarsPage(int pageNr)
        //{
        //    int startIndex = (pageNr - 1) * _likedAdsInPage;
        //    // if we already have enough ads
        //    // it should be impossible for this to be false if more ads can be fetched
        //    if (CarsLikedInCurrentSession.Count >= startIndex)
        //    {
        //        if (CanFetchMoreLikedAds)
        //        {
        //            GetSortedLikedCars(Username, startIndex, _likedAdsInPage);

        //            return CarsLikedInCurrentSession.Skip(startIndex).Take(_likedAdsInPage).ToList();
        //        }
        //        else
        //        {
        //            return CarsLikedInCurrentSession.Skip(startIndex).Take(_likedAdsInPage).ToList();
        //        }
        //    }
        //    else
        //    {
        //        // if we don't have enough ads, there is nothing we can do
        //        return null;
        //    }
        //}
        //    // fetch the required data from server
        //    // we could make server return total amount of results to avoid pointless queries
        //    if (_canFetchMoreLikedAds)
        //    {
        //        GetSortedLikedCars(Username, startIndex, amount);
        //        return CarsLikedInCurrentSession.Count > startIndex ? CarsLikedInCurrentSession.Skip(startIndex).Take(amount).ToList() : null;
        //        //if (CarsLikedInCurrentSession.Count > startIndex)
        //        //{
        //        //    return CarsLikedInCurrentSession.Skip(startIndex).Take(amount).ToList();
        //        //}
        //        //else
        //        //{
        //        //    // return null if query to the server didn't give us anything
        //        //    return null;
        //        //}
        //    }
        //    else
        //    {
        //        // return null if we don't have enough ads and we can't get more
        //        return null;
        //    }
        //}
        //}
    }
}
