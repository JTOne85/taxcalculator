using System;
using System.Linq;
using TaxCalculator.Core.Context;

namespace TaxCalculator.Core.Repositories
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class, new()
    {
        protected readonly TaxManContext Context;

        public Repository(TaxManContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return Context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entity: {ex.Message}");
            }
        }

    }
}
