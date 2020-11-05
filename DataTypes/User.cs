using System;
using System.Collections.Generic;

namespace DataTypes
{
    public class User : IEquatable<User>
    {
        // unique db key = username
        public User(string username, long phone, string hashedPassword, string email)
        {
            Username = username;
            Phone = phone;
            HashedPassword = hashedPassword;
            Email = email;
            LikedAds = new List<int>();
        }

        // required for deserialization
        public User() { }

        public string Username { get; set; }
        public long Phone { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public List<int> LikedAds { get; set; }

        public bool Equals(User other)
        {
            return other.Username == Username;
        }
    }
}
