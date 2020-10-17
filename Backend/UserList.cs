using System;
using System.Collections.Generic;
using System.Text.Json;
using DataTypes;

namespace Backend
{
    public class UserList : IUserDb
    {
        private List<User> userList;
        private FileReader userDataReader;
        private FileWriter userDataWriter;
        private Logger logger;

        public UserList(Logger logger, string userDbPath = null)
        {
            this.logger = logger;
            userDataReader = new FileReader(logger, userDbPath);
            userDataWriter = new FileWriter(logger, userDbPath);
            userList = userDataReader.GetAllUserData();
        }

        // returns null if not found
        public byte[] GetUser(string username)
        {
            User user = userList.Find(user => user.Username == username);
            return user != null? JsonSerializer.SerializeToUtf8Bytes<User>(user) : null;
        }

        public bool AddUser(byte[] user)
        {
            try
            {
                User u = JsonSerializer.Deserialize<User>(user);
                if (!CheckIfExists(u.Username))
                {
                    userList.Add(u);
                    return userDataWriter.WriteUserData(u); // make filewriter be able to write serialized data
                }
                else
                {
                    return false;
                }
            }
            catch (JsonException e)
            {
                logger.LogException(new Exception("Cannot add user due to bad serialization", e));
                return false;
            }
            catch (Exception e)
            {
                logger.LogException(e);
                return false;
            }
        }

        public bool DeleteUser(string username)
        {
            return userList.RemoveAll(user => user.Username == username) == 1 && userDataWriter.DeleteUser(username);
        }

        public bool CheckIfExists(string username)
        {
            return userList.Exists(user => user.Username.Equals(username));
        }
    }
}
