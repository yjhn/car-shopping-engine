using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Backend
{
    public class UserList
    {
        private List<User> userList;
        private FileReader userDataReader;
        private FileWriter userDataWriter;
        private Logger logger;
        private int lastUserId = 0;

        public UserList(Logger logger, string userDbPath = null)
        {
            this.logger = logger;
            userDataReader = new FileReader(logger, userDbPath);
            userDataWriter = new FileWriter(logger, userDbPath);
            userList = userDataReader.GetAllUserData();
            lastUserId = userDataReader.lastUserId;
        }

        // returns null if not found
        private User GetUser(int id)
        {
            return userList.Find(user => user.Id == id);
        }

        public byte[] JsonGetUser(int id)
        {
            return JsonSerializer.SerializeToUtf8Bytes<User>(GetUser(id));
        }

        private void AddUser(User user)
        {
            userList.Add(user);
            userDataWriter.WriteUserData(user);
            if (user.Id > lastUserId)
            {
                lastUserId = user.Id;
            }
        }

        public void JsonAddUser(byte[] user)
        {
            try
            {
                AddUser(JsonSerializer.Deserialize<User>(user));
            }
            catch (Exception e)
            {
                logger.LogException(new BackendException("Cannot add user due to bad serialization", e));
            }
        }

        public void DeleteUser(int id)
        {
            foreach (User user in userList)
            {
                if (user.Id == id)
                {
                    userList.Remove(user);
                    userDataWriter.DeleteCar(id);
                }
            }
        }
    }
}
