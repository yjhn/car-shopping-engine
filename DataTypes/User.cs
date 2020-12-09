using System;
using System.Collections.Generic;
using System.Text;

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
        public string Role { get; set; } = UserRole.User;
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public List<int> LikedAds { get; set; }
        public bool Disabled { get; set; } = false;

        public bool Equals(User other)
        {
            return other.Username == Username;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public override string ToString()
        {
            return $"-----------------------\n" +
                $"Username: {Username}\n" +
                $"Role: {Role}\n" +
                $"Phone: {Phone}\n" +
                $"Hashed Password: {HashedPassword}\n" +
                $"Email: {Email}\n" +
                $"Liked ads:{LikedAdsListToString()}\n" +
                $"Enabled: {!Disabled}\n" +
                $"-----------------------";
        }

        private string LikedAdsListToString()
        {
            StringBuilder s = new StringBuilder();
            foreach(int id in LikedAds)
            {
                s.Append($"\n  {id}");
            }
            return s.ToString();
        }
    }

    public static class UserRole
    {
        public const string Admin = "admin";
        public const string User = "user";
    }
}
