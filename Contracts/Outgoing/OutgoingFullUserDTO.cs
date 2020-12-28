using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Outgoing
{
    public class OutgoingFullUserDTO
    {
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public long Phone { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> LikedAds { get; set; }
        public IEnumerable<int> UploadedAds { get; set; }
        public bool Disabled { get; set; }
    }
}
