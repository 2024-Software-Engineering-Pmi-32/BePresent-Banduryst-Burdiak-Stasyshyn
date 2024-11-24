namespace bepresent_wpf.BLL
{
    using bepresent_wpf.DAL;

    public class UserService : IUserService
    {
        private readonly UserRepository UserRepository;

        public UserService(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Register(string username, string passwordH)
        {
            var user = new User { username = username, password = passwordH };
            UserRepository.RegisterUser(user);
        }

        public User GetUser(string username)
        {
            return UserRepository.GetUserByUsername(username);
        }
    }
}