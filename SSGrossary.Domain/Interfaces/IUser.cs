using SSGrossary.Application.DTO;
using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface IUser
    {
        List<User> GetAll();

        bool Add(User  user);

        User Login(LoginRequest loginRequest);
    }
}
