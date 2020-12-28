using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Services;
using System.Linq;

namespace Services.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(this IncomingUserDTO user)
        {
            if (user == null)
                return null;

            User u = new()
            {
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                HashedPassword = Utilities.EncryptPassword(user.Password, user.Username)
            };
            return u;
        }

        public static OutgoingUserDTO ToOutgoingDTO(this User user)
        {
            if (user == null)
                return null;

            OutgoingUserDTO u = new()
            {
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                LikedAds = user.LikedAds.Select(v => v.Id),
                Created = user.Created
            };
            return u;
        }

        public static OutgoingFullUserDTO ToOutgoingFullDTO(this User user)
        {
            if (user == null)
                return null;

            OutgoingFullUserDTO u = new()
            {
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                LikedAds = user.LikedAds.Select(v => v.Id),
                Created = user.Created,
                Role = user.Role,
                Disabled = user.Disabled,
                UploadedAds = user.UploadedAds.Select(a => a.Id)
            };
            return u;
        }
    }
}
