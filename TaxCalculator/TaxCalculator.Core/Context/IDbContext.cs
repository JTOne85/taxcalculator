using Microsoft.EntityFrameworkCore;

namespace TaxCalculator.Core.Context
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
