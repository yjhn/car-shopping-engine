using DataTypes;
using System;
using System.Collections.Generic;

namespace Frontend
{
    public class UserInfo
    {
        private readonly IApi _api;
        public string Username { get; private set; }
        public string Email { get; private set; }
        public long Phone { get; private set; }
        public List<int> LikedAds { get; private set; }

        private string Token { get; set; }

        // this CAN NEVER be set to null
        public List<Car> LikedCarList { get; private set; } = new List<Car>();

        public MinimalUser User
        {
            // use setter when logging in and out
            // when logging out, set this to null
            set
            {
                // only let a new user log in once the last has loggd out
                if (value != null && Username == null)
                {
                    Token = value.Token;
                    GetLikedCars();
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Email = value.Email;
                    Phone = value.Phone;
                    LoginStateChanged.Invoke();
                }
                else if (Username != null)
                {
                    // this happens if user logs out
                    // update liked ads of the user who just logged out
                    _api.UpdateLikedAds(Token, LikedAds);
                    // reset user info
                    Username = null;
                    LikedAds = null;
                    Token = null;
                    Email = null;
                    Phone = -1;
                    // clear the liked cars list to prepare for another user
                    LikedCarList.Clear();
                    LoginStateChanged.Invoke();
                }
            }
        }

        public UserInfo(IApi api)
        {
            _api = api;
        }

        public Action LoginStateChanged = delegate { };
        public Action LikedCarListUpdated = delegate { };

        //public async Task<List<Car>> GetLikedCarList()
        //{
        //    // use cached liked car list if it is available
        //    if (LikedCarList != null)
        //    {
        //        return LikedCarList;
        //    }
        //    else
        //    {
        //        LikedCarList = await _api.GetLikedCars(Token, 0, 100);
        //        return LikedCarList;
        //    }
        //}

        private async void GetLikedCars()
        {
            // this will probably cause bugs when one user logs in then instantly out, then another instantly logs in
            List<Car> temp = await _api.GetLikedCars(Token, 0, 100);
            // user might have logged out while we were fetching data
            if (temp != null && Username != null)
            {
                LikedCarList.AddRange(temp);
                LikedCarListUpdated.Invoke();
            }
        }
    }
}
