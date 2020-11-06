using DataTypes;
using System;
using System.Collections.Generic;

namespace Frontend
{
    public class UserInfo
    {
        private readonly IApi _api;

        public string Username { get; private set; }
        public List<int> LikedAds { get; private set; }

        private string Token { get; set; }

        public List<Car> LikedCarList { get; private set; }

        public MinimalUser User
        {
            // use setter when logging in and out
            // when logging out, set this to null
            set
            {
                // only let a new user log in once the last has loggd out
                if (value != null && Username == null)
                {
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Token = value.Token;
                    GetLikedCars();
                    if (LikedCarList == null)
                    {
                        LikedCarList = new List<Car>();
                    }
                    LoginStateChanged.Invoke();
                }
                else if (Username != null)
                {
                    // this happens if user logs out
                    // update liked ads of the user who logged out
                    _api.UpdateLikedAds(Token, LikedAds);

                    // reset user info
                    Username = null;
                    LikedAds = null;
                    Token = null;
                    LoginStateChanged.Invoke();
                }
            }
        }

        public UserInfo(IApi api)
        {
            _api = api;
        }

        public Action LoginStateChanged = delegate { };

        private async void GetLikedCars()
        {
            // load user liked ads from server, this should not return null
            LikedCarList = await _api.GetLikedCars(Token, 0, 100);

            // temporary
            //if(LikedCarList == null)
            //{
            //    LikedCarList = new List<Car>();
            //}
        }
    }
}
