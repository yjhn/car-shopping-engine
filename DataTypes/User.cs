using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class User
    {
        // unique db key = username
        public User(string username, Int64 phone, string hashedPassword, string email)
        {
            Username = username;
            Phone = phone;
            HashedPassword = hashedPassword;
            Email = email;
        }

        // required for deserialization
        public User() { }

        public string Username { get; set; }
        public Int64 Phone { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public List<int> LikedAds { get; set; }
    }
}
