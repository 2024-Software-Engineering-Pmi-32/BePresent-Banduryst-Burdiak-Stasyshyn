using bepresent_wpf.DAL;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace bepresent_wpf.BLL
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(string username, string passwordH)
        {
            var password = HashPassword(passwordH);
            var user = new User {username = username, password = passwordH};
            _userRepository.RegisterUser(user);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public User GetUser(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }
    }
}