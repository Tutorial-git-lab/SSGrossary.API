using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface IRole
    {
        List<Role> GetAll();

        bool Add(Role role);

        bool Update(Role role);

        bool Delete(int Id);

        Role GetById(int Id);
    }
}
