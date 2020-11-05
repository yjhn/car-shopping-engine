using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class MinimalUser
    {
        public MinimalUser() { }

        public MinimalUser(string username, string token, long phone, string email)
        {
            Username = username;
            Phone = phone;
            Token = token;
            Email = email;
            LikedAds = new List<int>();
        }

        public string Username { get; set; }
        public long Phone { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public List<int> LikedAds { get; set; }
    }
}
