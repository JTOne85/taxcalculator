using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxCalculator.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
    }
}
