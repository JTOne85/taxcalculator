using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Context;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxBands
{
    public class TaxBandRepository : Repository<TaxBand>, ITaxBandRepository
    {
        public TaxBandRepository(TaxManContext taxManContext) : base(taxManContext) { }
        public IEnumerable<TaxBand> GetTaxBandsByTaxTypeId(int taxTypeId)
        {
            return GetAll().Where(b => b.TaxTypeId == taxTypeId);
        }
    }
}
