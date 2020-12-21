using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class User : IEquatable<User>
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public string Username { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }
        public long Phone { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Role { get; set; }

        [Required]
        [Column(TypeName = "binary(32)")]
        public byte[] HashedPassword { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        public ICollection<Vehicle> LikedAds { get; set; }
        public ICollection<Vehicle> UploadedAds { get; set; }
        public bool Disabled { get; set; }

        // this constructor sets default values
        public User()
        {
            Role = UserRole.User;
            LikedAds = new List<Vehicle>();
            Disabled = false;
        }


        // not sure if these are needed

        public bool Equals(User other)
        {
            if(other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            return other.Username == Username;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }

    public static class UserRole
    {
        public const string Admin = "admin";
        public const string User = "user";
    }
}
