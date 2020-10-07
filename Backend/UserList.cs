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

        public UserList(Logger logger, FileReader reader, FileWriter writer)
        {
            userDataReader = reader;
            userDataWriter = writer;
            userList = userDataReader.GetAllUserData();
        }

        public void AddUser(User user)
        {
            userList.Add(user);
            userDataWriter.WriteUserData(user);
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
