namespace bepresent_wpf.DAL
{
    using System.Linq;
    public class UserRepository
    {
        private readonly DataContext Context;

        public UserRepository(DataContext context)
        {
            Context = context;
        }

        public void RegisterUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public virtual User GetUserByUsername(string username)
        {
            return Context.Users.FirstOrDefault(u => u.username == username);
        }
    }
}