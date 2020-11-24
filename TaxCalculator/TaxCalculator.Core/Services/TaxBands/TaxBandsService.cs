using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.TaxBands;

namespace TaxCalculator.Core.Services.TaxBands
{
    public class TaxBandsService : ITaxBandsService
    {
        private ITaxBandRepository _taxBandRepository;

        public TaxBandsService(ITaxBandRepository taxBandRepository)
        {
            _taxBandRepository = taxBandRepository;
        }
        public IEnumerable<TaxBand> GetAllTaxBands()
        {
            var bands = _taxBandRepository.GetAll().Where(b => b.IsActive);
            return bands;
        }

        public TaxBand GetTaxBandById(int id)
        {
            return GetAllTaxBands().FirstOrDefault(b => b.Id == id);
        }

        public TaxBand GetTaxBandByRateCode(string rateCode)
        {
            return GetAllTaxBands().FirstOrDefault(b => b.TaxRateCode == rateCode);
        }

        public TaxBand GetProgressiveTaxBandByIncomeAndTaxType(decimal value)
        {
            return GetAllTaxBands().FirstOrDefault(b => value >= b.LowerLimit && value <= b.UpperLimit);
        }
    }
}
