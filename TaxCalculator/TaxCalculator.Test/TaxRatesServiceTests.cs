using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.PostalCodes;
using TaxCalculator.Core.Repositories.TaxRates;
using TaxCalculator.Core.Services.TaxRates;
namespace TaxCalculator.Test
{
    [TestFixture]
    public class TaxRatesServiceTests
    {
        private TaxRatesService _taxRatesService;
        private IEnumerable<TaxRate> _taxRates;
        private Mock<ITaxRatesRepository> _taxRatesRepository;
        private Mock<IPostalCodeRepository> _postalCodeRepository;



        [SetUp]
        public void Setup()
        {
            _taxRates = Helpers.CreateTaxRates();
            _taxRatesRepository = new Mock<ITaxRatesRepository>();
            _postalCodeRepository = new Mock<IPostalCodeRepository>();
            _taxRatesRepository.Setup(r => r.GetAll()).Returns(_taxRates.AsQueryable());
            

            _taxRatesService = new TaxRatesService(_taxRatesRepository.Object, _postalCodeRepository.Object);
        }

        [Test]
        public void ShouldGetAllActiveTaxRates()
        {
            // Arrange
            var taxRates = _taxRatesService.GetAll();

            // Assert
            Assert.That(taxRates.Count, Is.EqualTo(_taxRates.Count()));
        }

        [TestCase(1,new[] { 1,2})]
        [TestCase(2, new[] {3})]
        [TestCase(3, new[] { 4,5,6,7,8,9})]
        
        public void ShouldGetTaxRatesForTaxType(int taxTypeId, int[] taxBandIds)
        {
            // Arrange

            // Act 
            var taxRates = _taxRatesService.GetTaxRatesByTaxType(taxTypeId);

            // Assert
            Assert.That(taxRates.Count, Is.EqualTo(taxBandIds.Length));
            Assert.That(taxRates.Select(r => r.TaxBandId).ToList(), Is.EquivalentTo(taxBandIds.ToList()));
        }

        public void ShouldGetTaxTypeByPostalCode()
        {

        }

        public void ShouldGetTaxRatesByPostalCodeTaxTypeAndIncome()
        {

        }

        public void ShouldGetTaxBandsByPostalCodeTaxTypeAndIncome()
        {

        }
    }
}
