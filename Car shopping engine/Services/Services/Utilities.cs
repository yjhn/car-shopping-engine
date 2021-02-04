using System.Security.Cryptography;
using System.Text;

namespace Services.Services
{
    public static class Utilities
    {
        public static byte[] EncryptPassword(string password, string username)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = string.Format("{0}{1}", username, password);
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            //byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
            //return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
        }
    }
}
