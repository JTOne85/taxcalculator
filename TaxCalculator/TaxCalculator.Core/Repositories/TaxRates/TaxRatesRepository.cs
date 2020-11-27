using System.Linq;
using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxRates
{
    public class TaxRatesRepository : Repository<TaxRate>, ITaxRatesRepository
    {
        public TaxRatesRepository(TaxManContext context) : base(context) { }
        public TaxRate GetTaxRateByTaxBandId(int taxBandId)
        {
            return GetAll().FirstOrDefault(r => r.TaxBandId == taxBandId);
        }
    }
}