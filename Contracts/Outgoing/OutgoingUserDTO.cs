using System;
using System.Collections.Generic;

namespace Contracts.Outgoing
{
    public class OutgoingUserDTO
    {
        public string Username { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<int> LikedAds { get; set; }
        public DateTime Created { get; set; }
    }
}
