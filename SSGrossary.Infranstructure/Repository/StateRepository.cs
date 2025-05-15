using SSGrossary.Domain.Entities;
using SSGrossary.Domain.Interfaces;

namespace SSGrossary.Infranstructure.Repository
{
    public class StateRepository : IState
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }


        public bool Add(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var states = _context.States.Find(Id);
            _context.States.Remove(states);
            _context.SaveChanges();
            return true;
        }

        public List<State> GetAll()
        {
            return _context.States.ToList();
        }

        public bool Update(State state)
        {
            _context.States.Update(state);
            _context.SaveChanges();
            return true;
        }
    }
}
