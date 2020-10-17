using System;
using System.Collections.Generic;
using System.Text;

namespace Backend
{
    public interface IUserDb
    {
        // args: user serialized to UTF-8 JSON
        public bool AddUser(byte[] user);

        // returns: true, if removal is successful, false if not
        public bool DeleteUser(string username);

        // returns: user serialized to UTF-8 JSON
        public byte[] GetUser(string username);

        // returns: true, if user already exists, false otherwise
        public bool CheckIfExists(string username);
    }
}
