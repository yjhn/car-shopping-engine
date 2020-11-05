using DataTypes;
using System.Collections.Generic;

namespace Frontend
{
    public class UserInfo
    {
        private readonly IApi _api;
        //private MinimalUser _user;

        public UserInfo(IApi api)
        {
            _api = api;
        }

        public MinimalUser User
        {
            // use setter when logging in and logging out
            set
            {
                if (value != null)
                {
                    //_user = value;
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Token = value.Token;
                }
                else
                {
                    // this happens if user logs out

                    // we need to send updated user info to the server in this case
                    //_user.LikedAds = LikedAds;
                    // call Api
                    _api.UpdateLikedAds(Token, LikedAds);

                    // reset user info
                    Username = null;
                    LikedAds = null;
                    Token = null;
                    //_user = null;
                }
            }
        }

        public string Username { get; private set; }
        public List<int> LikedAds { get; private set; }

        internal string Token { get; private set; }
    }
}
