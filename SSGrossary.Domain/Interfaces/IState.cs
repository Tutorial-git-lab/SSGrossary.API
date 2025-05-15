using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface IState
    {
        List<State> GetAll();

        bool Add(State state);

        bool Update(State state);

        bool Delete(int Id);
    }
}
