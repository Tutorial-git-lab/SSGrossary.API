using SSGrossary.Application.DTO;
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

        public User Login(LoginRequest loginRequest)
        {
            var user=_context.Users.FirstOrDefault(x=>x.Email == loginRequest.Email && x.Password==loginRequest.Password);
            return user;

            
        }   
    }
}
