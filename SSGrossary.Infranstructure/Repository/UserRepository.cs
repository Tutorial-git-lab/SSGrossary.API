using SSGrossary.Domain.Entities;

namespace SSGrossary.Infranstructure.Repository
{
    public class UserRepository:IUser
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public bool Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var user = _context.Users.Find();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}
