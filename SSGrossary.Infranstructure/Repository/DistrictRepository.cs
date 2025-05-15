using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.Infranstructure.Repository
{
    public class DistrictRepository:IDistrict
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public bool Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var districts = _context.Districts.Find(Id);
            _context.Districts.Remove(districts);
            _context.SaveChanges();
            return true;
        }

        public List<District> GetAll()
        {
            return _context.Districts.ToList();
        }

        public bool Update(District district)
        {
            _context.Districts.Update(district);
            _context.SaveChanges();
            return true;
        }
    }
}
