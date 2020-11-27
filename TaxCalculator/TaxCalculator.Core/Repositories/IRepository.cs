using System.Linq;

namespace TaxCalculator.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    }
}
