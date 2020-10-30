using DataTypes;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Backend
{
    public class UserList : IUserDb
    {
        private readonly List<User> _userList;
        private readonly FileReader _userDataReader;
        private readonly FileWriter _userDataWriter;
        private readonly Logger _logger;

        public UserList(Logger logger, string userDbPath = null)
        {
            _logger = logger;
            _userDataReader = new FileReader(logger, userDbPath);
            _userDataWriter = new FileWriter(logger, userDbPath);
            _userList = _userDataReader.GetAllUserData();
        }

        // returns null if not found
        public byte[] GetUser(string username)
        {
            User user = _userList.Find(user => user.Username == username);
            return user != null ? JsonSerializer.SerializeToUtf8Bytes<User>(user) : null;
        }

        public bool AddUser(byte[] user)
        {
            try
            {
                User u = JsonSerializer.Deserialize<User>(user);
                if (!CheckIfExists(u.Username))
                {
                    _userList.Add(u);
                    return _userDataWriter.WriteUserData(u); // make filewriter be able to write serialized data
                }
                else
                {
                    return false;
                }
            }
            catch (JsonException e)
            {
                _logger.LogException(new Exception("Cannot add user due to bad serialization", e));
                return false;
            }
            catch (Exception e)
            {
                _logger.LogException(e);
                return false;
            }
        }

        public bool DeleteUser(string username)
        {
            return _userList.RemoveAll(user => user.Username == username) == 1 && _userDataWriter.DeleteUser(username);
        }

        public bool CheckIfExists(string username)
        {
            return _userList.Exists(user => user.Username.Equals(username));
        }

        public bool Authenticate(string username, string hashedPassword)
        {
            return _userList.Exists((user) => user.Username.Equals(username) && user.HashedPassword.Equals(hashedPassword));
        }
    }
}
