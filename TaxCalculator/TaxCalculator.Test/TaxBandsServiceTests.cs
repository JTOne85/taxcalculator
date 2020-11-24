using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.TaxBands;
using TaxCalculator.Core.Services.TaxBands;

namespace TaxCalculator.Test
{
    [TestFixture]
    public class TaxBandsServiceTests
    {

        private TaxBandsService _taxBandsService;
        private Mock<ITaxBandRepository> _taxBandsRepository;
        private IEnumerable<TaxBand> _taxBands;

        [SetUp]
        public void SetUp()
        {
            _taxBands = Helpers.CreateTaxBands();
            _taxBandsRepository = new Mock<ITaxBandRepository>();
            _taxBandsRepository.Setup(r => r.GetAll()).Returns(_taxBands.AsQueryable());

            _taxBandsService = new TaxBandsService(_taxBandsRepository.Object);
        }

        [TestCase(1, 0, 199999.99, "FV0")]
        [TestCase(2, 200000, null, "FV1")]
        [TestCase(3, null, null, "FR")]
        [TestCase(4, 0, 8350.99, "P0")]
        [TestCase(5, 8351.00, 33950.99, "P1")]
        [TestCase(6, 33951.00, 82250.99, "P2")]
        [TestCase(7, 82251.00, 171550.99, "P3")]
        [TestCase(8, 171551.00, 372950.99, "P4")]
        [TestCase(9, 372951, null, "P5")]
        public void ShouldGetTaxBandById(int bandId, decimal? lowerLimit, decimal? upperLimit, string expectedRateCode)
        {
            // Act
            var taxBand = _taxBandsService.GetTaxBandById(bandId);

            // Assert
            Assert.That(taxBand.Id, Is.EqualTo(bandId));
            Assert.That(taxBand.TaxRateCode, Is.EqualTo(expectedRateCode));
        }

        [Test]
        public void ShouldGetAllTaxBands()
        {
            // Act
            var taxBands = _taxBandsService.GetAllTaxBands();

            // Assert
            Assert.That(taxBands.Count, Is.EqualTo(_taxBands.Count()));
        }

        [TestCase("FV0",0, 199999.99)]
        [TestCase("FV1",200000, null)]
        [TestCase("FR", null, null)]
        [TestCase("P0", 0, 8350.99)]
        [TestCase("P1", 8351.00, 33950.99)]
        [TestCase("P2", 33951.00, 82250.99)]
        [TestCase("P3", 82251.00, 171550.99)]
        [TestCase("P4", 171551.00, 372950.99)]
        [TestCase("P5", 372951, null)]

        public void ShouldGetTaxBandByRateCode(string rateCode, decimal? expectedLowerLimit, decimal? expectedUpperLimit)
        {
            // Act
            var taxBand = _taxBandsService.GetTaxBandByRateCode(rateCode);

            // Assert
            Assert.That(taxBand.TaxRateCode, Is.EqualTo(rateCode));
            Assert.That(taxBand.LowerLimit, Is.EqualTo(expectedLowerLimit));
            Assert.That(taxBand.UpperLimit, Is.EqualTo(expectedUpperLimit));

        }
    }
}
