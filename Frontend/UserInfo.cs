using DataTypes;
using System.Collections.Generic;

namespace Frontend
{
    // class to keep track of login and user state
    public static class UserInfo
    {
        public static MinimalUser User
        {
            // use getter when logging out
            get
            {
                // liked ads list might have changed while user was logged in
                User.LikedAds = LikedAds;
                return User;
            }
            // use setter when logging in
            set
            {
                if (value != null)
                {
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Token = value.Token;
                }
                else
                {
                    // this happens if user logs out
                    Username = null;
                    LikedAds = null;
                    Token = null;
                }
            }
        }
        public static string Username { get; private set; }
        public static List<int> LikedAds { get; private set; }

        internal static string Token { get; private set; }
    }
}
