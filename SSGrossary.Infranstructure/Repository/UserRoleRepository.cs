using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.Infranstructure.Repository
{
    public class UserRoleRepository:IUserRole
    {
        private readonly ApplicationDbContext _context;
        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public bool Add(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var userRole = _context.UserRoles.Find(Id);
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            return true;
        }

        public List<UserRole> GetAll()
        {
            return _context.UserRoles.ToList();
        }

        public UserRole GetById(int Id)
        {
            return _context.UserRoles.Find(Id);
        }

        public bool Update(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
            return true;
        }
    }
}
