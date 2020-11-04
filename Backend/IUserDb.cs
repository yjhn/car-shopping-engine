namespace Backend
{
    public interface IUserDb
    {
        // args: user serialized to UTF-8 JSON
        public bool AddUserJson(byte[] user);

        // returns: true, if removal is successful, false if not
        public bool DeleteUser(string username);

        // returns: user serialized to UTF-8 JSON
        public byte[] GetUserInfoJson(string username);

        // returns: true, if user already exists, false otherwise
        public bool CheckIfExists(string username);

        // returns: true, if such a user exists, false otherwise
        public bool Authenticate(string username, string hashedPassword);
    }
}
