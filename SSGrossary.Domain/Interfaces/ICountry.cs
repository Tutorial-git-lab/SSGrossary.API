using SSGrossary.Domain.Entities;

namespace SSGrossary.Domain.Interfaces
{
    public interface ICountry
    {
        List<Country> GetAll();

        bool Add(Country country);

        bool Update(Country country);

        bool Delete(int Id);
    }
}
