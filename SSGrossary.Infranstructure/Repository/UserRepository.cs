using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.Infranstructure.Repository
{
    public class UserRepository:IUser
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public User GetById(int Id)
        {
            return _context.Users.Find(Id);
        }
    }
}
