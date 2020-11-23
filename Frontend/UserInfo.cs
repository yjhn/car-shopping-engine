using DataTypes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Frontend
{
    public class UserInfo
    {
        private readonly IApiWrapper _api;
        // username cannot be changed, so it can only be set here
        public string Username { get; private set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public List<int> LikedAds { get; private set; }
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == null)
                {
                    _password = value;
                }
                else
                {
                    // user changed password
                    _changedPassword = value;
                }
            }
        }
        private string _password;
        private string _changedPassword;
        private User _user;

        public User User
        {
            // use setter when logging in and out
            // when logging out, set this to null
            set
            {
                // only let a new user log in once the last has logged out
                if (value != null && Username == null)
                {
                    _user = value;
                    //Token = value.Token;
                    // prefetch more ads in advance to know if there is more
                    //GetSortedLikedCars(value.Username, 0, 2 * _likedAdsInPage);
                    // set cahnged password to null to know if user changed it
                    _changedPassword = null;
                    Username = value.Username;
                    LikedAds = value.LikedAds;
                    Email = value.Email;
                    Phone = value.Phone;
                    LoginStateChanged.Invoke();
                }
                else if (value == null && Username != null)
                {
                    // this happens if user logs out
                    // update liked ads of the user who just logged out
                    PutUser();
                    _user = null;
                    // reset user info
                    Username = null;
                    Password = null;
                    _changedPassword = null;
                    LikedAds = null;
                    //Token = null;
                    Email = null;
                    Phone = -1;
                    //CanFetchMoreLikedAds = true;
                    // clear the liked cars list to prepare for another user
                    //CarsLikedInCurrentSession.Clear();
                    LoginStateChanged.Invoke();
                }
            }
        }

        public UserInfo(IApiWrapper api)
        {
            //_likedAdsInPage = likedAdsInPage;
            _api = api;
        }

        public async Task<bool> Login(string username, string password)
        {
            User u = await _api.GetUser(username, password);
            if (u == null)
            {
                return false;
            }
            else
            {
                User = u;
                Password = password;
                return true;
            }
        }

        public Action LoginStateChanged = delegate { };

        public async void PutUser()
        {
            if (_changedPassword != null)
            {
                _user.HashedPassword = EncryptPassword(_changedPassword, Username);
            }
            _user.Email = Email;
            _user.Phone = Phone;
            if (Password == null)
            {
                throw new Exception();
            }
            await _api.UpdateUser(Username, Password, _user);
        }

        public async Task<List<Car>> GetUserLikedAds(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return await _api.GetUserLikedAds(Username, Password, sortBy, sortAscending, startIndex, amount);
        }

        public async Task<List<Car>> GetUserUploadedAds(SortingCriteria sortBy, bool sortAscending, int startIndex, int amount)
        {
            return await _api.GetUserUploadedAds(Username, sortBy, sortAscending, startIndex, amount);
        }

        public async Task<int> PostCar(Car uploadCar)
        {
            return await _api.PostCar(uploadCar, Username, Password);
        }

        private static string EncryptPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = string.Format("{0}{1}", salt, password);
            byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
            return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
        }
    }
}
