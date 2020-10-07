using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    class UserList
    {
        private List<User> userList;
        private FileReader userDataReader;
        private FileWriter userDataWriter;
        private int lastUserId = 0;

        public UserList(Logger logger, FileReader reader, FileWriter writer)
        {
            userDataReader = reader;
            userDataWriter = writer;
            userList = userDataReader.GetAllUserData();
            lastUserId = userDataReader.lastUserId;
        }

        // returns null if not found
        public User GetUser(int id)
        {
            return userList.Find(user => user.Id == id);
        }

        public void AddUser(User user)
        {
            userList.Add(user);
            userDataWriter.WriteUserData(user);
            if(user.Id > lastUserId)
            {
                lastUserId = user.Id;
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
