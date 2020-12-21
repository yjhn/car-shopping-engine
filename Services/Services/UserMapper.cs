using Contracts.Incoming;
using Contracts.Outgoing;
using Models;
using Services.Repositories;
using System.Collections.Generic;

namespace Services.Services
{
    public class UserMapper
    {
        private readonly IVehicleRepository _repository;

        public UserMapper(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public User ToEntity(IncomingUserDTO user)
        {
            if (user == null) return null;

            User u = new()
            {
                Username = user.Username,
                Phone = user.Phone,
                Email = user.Email,
                //LikedAds = user.LikedAds == null || user.LikedAds.Count == 0? new List<Vehicle>() : (ICollection<Vehicle>)_repository.GetVehicles(user.LikedAds),
                HashedPassword = Utilities.EncryptPassword(user.Password, user.Username)
            };
            return u;
        }

        public OutgoingUserDTO ToOutgoingDTO(User user)
        {
            if (user == null) return null;

            OutgoingUserDTO u = new()
            {
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                //LikedAds = (List<int>)user.LikedAds,
                Created = user.Created
            };
            return u;
        }
    }
}
