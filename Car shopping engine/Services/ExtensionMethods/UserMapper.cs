using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace Services.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity(this IncomingUserDTO user)
        {
            if (user == null)
                return null;

            // create temporary liked ads list
            List<Vehicle> likedAds = new List<Vehicle>();
            if (user.LikedAds != null)
            {
                foreach (int id in user.LikedAds)
                {
                    likedAds.Add(new Vehicle { Id = id });
                }
            }

            User u = new()
            {
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                HashedPassword = Utilities.EncryptPassword(user.Password, user.Username),
                LikedAds = likedAds
            };
            return u;
        }

        public static User ToEntity(this IncomingFullUserDTO user)
        {
            if (user == null)
                return null;

            // create temporary liked ads list
            List<Vehicle> likedAds = new List<Vehicle>();
            if (user.LikedAds != null)
            {
                foreach (int id in user.LikedAds)
                {
                    likedAds.Add(new Vehicle { Id = id });
                }
            }


            User u = new()
            {
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                HashedPassword = Utilities.EncryptPassword(user.Password, user.Username),
                Role = user.Role ?? UserRole.User,
                LikedAds = likedAds
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
