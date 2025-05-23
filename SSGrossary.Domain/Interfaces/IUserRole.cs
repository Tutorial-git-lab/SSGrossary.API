using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface IUserRole
    {
        List<UserRole> GetAll();

        bool Add(UserRole userRole);

        bool Update(UserRole userRole);

        bool Delete(int Id);

        UserRole GetById(int Id);
    }
}
