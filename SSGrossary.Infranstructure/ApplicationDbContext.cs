using Microsoft.EntityFrameworkCore;
using SSGrossary.Domain.Entities;

namespace SSGrossary.Infranstructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }

    }
}
