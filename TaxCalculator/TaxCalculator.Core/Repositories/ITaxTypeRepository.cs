using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories
{
    public interface ITaxTypeRepository : IRepository<TaxType>
    {
        TaxType GetTaxTypeById(int id);
    }
}
