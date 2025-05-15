using SSGrossary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGrossary.Infranstructure.Repository
{
    public interface IUser
    {
        List<User> GetAll();

        bool Add(User user);

        bool Update(User user);

        bool Delete(int Id);
    }
}
