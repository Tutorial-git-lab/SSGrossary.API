using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface IUser
    {
        List<User> GetAll();

        bool Add(User  user);

        User GetById(int Id);

        User Login(string email,string password);
    }
}
