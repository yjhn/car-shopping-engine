using System;
using System.Diagnostics.CodeAnalysis;

namespace DataTypes
{
    public class User : IEquatable<User>
    {
        // unique db key = username
        public User(string username, long phone1, string hashedPassword, string email, long phone2 = 0)
        {
            Username = username;
            Phone1 = phone1;
            Phone2 = phone2;
            HashedPassword = hashedPassword;
            Email = email;
        }

        public User()
        {
            ;
        }
        public string Username { get; set; }
        public long Phone1 { get; set; }
        public long Phone2 { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }

        public bool Equals(User other)
        {
            return this.Username == other.Username;
        }
    }
}
