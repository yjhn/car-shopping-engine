using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class MinimalUser
    {
        public MinimalUser() { }
        public MinimalUser(string username, string token, long phone1, string email)
        {
            Username = username;
            Phone1 = phone1;
            Token = token;
            Email = email;
        }

        public string Username { get; set; }
        public long Phone1 { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public List<int> LikedAds { get; set; }
    }
}
