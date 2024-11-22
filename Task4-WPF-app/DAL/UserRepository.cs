using bepresent_wpf.DAL;
using System.Linq;

namespace bepresent_wpf.DAL
{
    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.username == username);
        }
    }
}