using System.Linq;
using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories
{
    public class TaxTypeRepository : Repository<TaxType>, ITaxTypeRepository
    {
        public TaxTypeRepository(TaxManContext taxmanContext) : base(taxmanContext) { }

        public TaxType GetTaxTypeById(int taxTypeID)
        {
            return GetAll().FirstOrDefault(t => t.Id == taxTypeID);
        }
    }
}
