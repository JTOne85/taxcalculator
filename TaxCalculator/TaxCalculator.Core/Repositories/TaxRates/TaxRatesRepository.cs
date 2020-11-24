using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxRates
{
    public class TaxRatesRepository : Repository<TaxRate>, ITaxRatesRepository
    {
        public TaxRatesRepository(TaxManContext context) : base(context) { }
    }
}