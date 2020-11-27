using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories;
using TaxCalculator.Core.Repositories.PostalCodes;
using TaxCalculator.Core.Repositories.TaxBands;
using TaxCalculator.Core.Repositories.TaxRates;
using TaxCalculator.Core.Services.TaxRates;
namespace TaxCalculator.Test
{
    [TestFixture]
    public class TaxRatesServiceTests
    {
        private TaxRatesService _taxRatesService;
        private IEnumerable<TaxRate> _taxRates;
        private IEnumerable<PostalCode> _postalCodes;
        private IEnumerable<TaxType> _taxTypes;
        private IEnumerable<TaxBand> _taxBands;

        private Mock<ITaxRatesRepository> _taxRatesRepository;
        private Mock<IPostalCodeRepository> _postalCodeRepository;
        private Mock<ITaxTypeRepository> _taxTypeRepository;
        private Mock<ITaxBandRepository> _taxBandRepository;


        [SetUp]
        public void Setup()
        {
            _taxRates = Helpers.CreateTaxRates();
            _postalCodes = Helpers.CreatePostalCodes();
            _taxTypes = Helpers.CreateTaxTypes();
            _taxBands = Helpers.CreateTaxBands();

            _taxRatesRepository = new Mock<ITaxRatesRepository>();
            _taxRatesRepository.Setup(r => r.GetAll()).Returns(_taxRates.AsQueryable());

            _postalCodeRepository = new Mock<IPostalCodeRepository>();
            _postalCodeRepository.Setup(r => r.GetAll()).Returns(_postalCodes.AsQueryable());

            _taxBandRepository = new Mock<ITaxBandRepository>();
            _taxBandRepository.Setup(r => r.GetAll()).Returns(_taxBands.AsQueryable());

            _taxTypeRepository = new Mock<ITaxTypeRepository>();



            _taxRatesService = new TaxRatesService(_taxRatesRepository.Object, _postalCodeRepository.Object, _taxTypeRepository.Object, _taxBandRepository.Object);
        }

        [Test]
        public void ShouldGetAllActiveTaxRates()
        {
            // Arrange
            var taxRates = _taxRatesService.GetAll();

            // Assert
            Assert.That(taxRates.Count, Is.EqualTo(_taxRates.Count()));
        }

        [TestCase(1, new[] { 1, 2 })]
        [TestCase(2, new[] { 3 })]
        [TestCase(3, new[] { 4, 5, 6, 7, 8, 9 })]

        public void ShouldGetTaxRatesForTaxType(int taxTypeId, int[] taxBandIds)
        {
            // Arrange

            // Act 
            var taxRates = _taxRatesService.GetTaxRatesByTaxType(taxTypeId);

            // Assert
            Assert.That(taxRates.Count, Is.EqualTo(taxBandIds.Length));
            Assert.That(taxRates.Select(r => r.TaxBandId).ToList(), Is.EquivalentTo(taxBandIds.ToList()));
        }

        [TestCase("7441", "Progressive rate", 3)]
        [TestCase("A100", "Flat value", 1)]
        [TestCase("1000", "Flat Rate", 2)]
        [TestCase("7000", "Progressive rate", 3)]
        public void ShouldGetTaxTypeByPostalCode(string postCode, string expectedDescription, int taxTypeId)
        {
            // Arrange
            var expectedTaxType = _taxTypes.FirstOrDefault(t => t.Id == taxTypeId);
            _taxTypeRepository.Setup(r => r.GetTaxTypeById(It.IsAny<int>())).Returns(expectedTaxType);

            // Act
            var taxRates = _taxRatesService.GetTaxTypeByPostalCode(postCode);

            // Assert
            Assert.That(taxRates.TaxTypeDescription, Is.EqualTo(expectedDescription));
        }

        [Test]
        public void ShouldGetTaxRatesByPostalCodeTaxTypeAndIncome()
        {
            // Arrange
            var income = 10000;
            var postalCode = "7441";
            var taxTypeId = 3;
            var expectedTaxType = _taxTypes.FirstOrDefault(t => t.Id == taxTypeId);
            _taxTypeRepository.Setup(r => r.GetTaxTypeById(It.IsAny<int>())).Returns(expectedTaxType);

            _taxBandRepository.Setup(r => r.GetTaxBandsByTaxTypeId(It.IsAny<int>())).Returns(_taxBands.Where(b => b.TaxTypeId == taxTypeId));
            var band = _taxBands.FirstOrDefault(b => income >= b.LowerLimit && income <= b.UpperLimit && b.TaxTypeId == taxTypeId);
            _taxRatesRepository.Setup(r => r.GetTaxRateByTaxBandId(It.IsAny<int>())).Returns(_taxRates.FirstOrDefault(r => r.TaxBandId == band.Id));

            // Act
            var taxRate = _taxRatesService.GetTaxRateByIncomeAndPostalCode(income, postalCode);

            // Assert
            Assert.That(taxRate.TaxTypeId, Is.EqualTo(taxTypeId));
        }
    }
}
