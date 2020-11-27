using System;
using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories;
using TaxCalculator.Core.Repositories.PostalCodes;
using TaxCalculator.Core.Repositories.TaxBands;
using TaxCalculator.Core.Repositories.TaxRates;
using TaxCalculator.Core.Repositories.TaxTypes;

namespace TaxCalculator.Core.Services.TaxRates
{
    public class TaxRatesService : ITaxRatesService
    {
        private ITaxRatesRepository _taxRatesRepository;
        private readonly IPostalCodeRepository _postalCodeRepository;
        private readonly ITaxTypeRepository _taxTypeRepository;
        private readonly ITaxBandRepository _taxBandRepository;

        public TaxRatesService(ITaxRatesRepository taxRatesRepository, IPostalCodeRepository postalCodeRepository, ITaxTypeRepository taxTypeRepository, ITaxBandRepository taxBandRepository)
        {
            _taxRatesRepository = taxRatesRepository;
            _postalCodeRepository = postalCodeRepository;
            _taxTypeRepository = taxTypeRepository;
            _taxBandRepository = taxBandRepository;
        }

        public IEnumerable<TaxRate> GetAll()
        {
            return _taxRatesRepository.GetAll();
        }

        public IEnumerable<TaxRate> GetTaxRatesByTaxType(int taxTypeId)
        {
            return GetAll().Where(r => r.TaxTypeId == taxTypeId);
        }

        public TaxType GetTaxTypeByPostalCode(string postCode)
        {
            var postalCode = _postalCodeRepository.GetAll().FirstOrDefault(c => c.PostalCode1 == postCode);
            return _taxTypeRepository.GetTaxTypeById(postalCode.TaxTypeId);
        }

        public TaxRate GetTaxRateByIncomeAndPostalCode(in int income, string postalCode)
        {
            var taxType = GetTaxTypeByPostalCode(postalCode);
            var taxBand = GetTaxBandByTaxTypeAndIncome(taxType.Id, income);
            var taxRate = _taxRatesRepository.GetTaxRateByTaxBandId(taxBand.Id);
            return taxRate;
            
        }

        private TaxBand GetTaxBandByTaxTypeAndIncome(int taxTypeId, decimal income)
        {
            var taxBands = _taxBandRepository.GetTaxBandsByTaxTypeId(taxTypeId);
             return taxBands.FirstOrDefault(b => income >= b.LowerLimit && income <= b.UpperLimit);
        }
    }

}