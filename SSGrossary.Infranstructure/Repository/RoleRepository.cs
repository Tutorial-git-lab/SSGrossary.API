using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.Infranstructure.Repository
{
    public class RoleRepository : IRole
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public bool Add(Role role)
        {
           _context.Roles.Add(role);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == Id);
            _context.Roles.Remove(role);
            return true;
        }

        public List<Role> GetAll()
        {
            return _context.Roles.ToList();

        }

        public Role GetById(int Id)
        {
            return _context.Roles.Find(Id);
        }

        public bool Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return true;
        }
    }
}
