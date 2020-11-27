using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxTypes
{
    public interface ITaxTypeRepository : IRepository<TaxType>
    {
        TaxType GetTaxTypeById(int id);
    }
}
