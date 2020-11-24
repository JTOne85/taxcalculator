using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxBands
{
    public class TaxBandRepository : Repository<TaxBand>, ITaxBandRepository
    {
        public TaxBandRepository(TaxManContext taxManContext) : base(taxManContext) { }
    }
}
