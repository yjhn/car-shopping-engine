using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Incoming
{
    public class IncomingFullUserDTO
    {
        [Required]
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public long Phone { get; set; }
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<int> LikedAds { get; set; }
        public ICollection<int> UploadedAds { get; set; }
        [DefaultValue(false)]
        public bool Disabled { get; set; }
    }
}
