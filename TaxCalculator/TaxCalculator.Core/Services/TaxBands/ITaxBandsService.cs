using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Services.TaxBands
{
    interface ITaxBandsService
    {
        IEnumerable<TaxBand> GetAllTaxBands();
        TaxBand GetTaxBandById(int id);
        TaxBand GetTaxBandByRateCode(string rateCode);
    }
}
