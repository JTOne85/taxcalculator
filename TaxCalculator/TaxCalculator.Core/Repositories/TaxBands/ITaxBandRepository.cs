using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Repositories.TaxBands
{
    public interface ITaxBandRepository: IRepository<TaxBand>
    {
        IEnumerable<TaxBand> GetTaxBandsByTaxTypeId(int id);
    }
}
