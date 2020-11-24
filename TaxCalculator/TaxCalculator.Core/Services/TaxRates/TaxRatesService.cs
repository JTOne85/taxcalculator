using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.PostalCodes;
using TaxCalculator.Core.Repositories.TaxRates;

namespace TaxCalculator.Core.Services.TaxRates
{
    public class TaxRatesService : ITaxRatesService
    {
        private ITaxRatesRepository _taxRatesRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;

        public TaxRatesService(ITaxRatesRepository taxRatesRepository, IPostalCodeRepository postalCodeRepository)
        {
            _taxRatesRepository = taxRatesRepository;
            _postalCodeRepository = postalCodeRepository;
        }

        public IEnumerable<TaxRate> GetAll()
        {
            return _taxRatesRepository.GetAll();
        }

        public IEnumerable<TaxRate> GetTaxRatesByTaxType(int taxTypeId)
        {
            return GetAll().Where(r => r.TaxTypeId == taxTypeId);
        }
    }
}