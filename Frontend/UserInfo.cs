using DataTypes;
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
                if (value != null)
                {
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Token = value.Token;
                    GetLikedCars();
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
                }
            }
        }

        public UserInfo(IApi api)
        {
            _api = api;

        }

        private async void GetLikedCars()
        {
            // load user liked ads from server
            LikedCarList = await _api.GetLikedCars(Username, 0, 15);

        }
    }
}
