using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Mock<TaxBandRepository> _taxBandsRepository;
        private IEnumerable<TaxBand> _taxBands;

        [SetUp]
        public void SetUp() {
            _taxBands = Helpers.CreateTaxBands();
            _taxBandsRepository = new Mock<TaxBandRepository>();
            _taxBandsRepository.Setup(r => r.GetAll()).Returns(_taxBands.AsQueryable());

            _taxBandsService = new TaxBandsService(_taxBandsRepository.Object);
        }


        /*
         * new TaxBand{ Id = 1, TaxRateCode = "FV0", LowerLimit = 0m, UpperLimit = 199999.99m},
                new TaxBand{ Id = 2, TaxRateCode = "FV1", LowerLimit = 200000.00m},
                new TaxBand{ Id = 3, TaxRateCode = "FR" },
                new TaxBand{ Id = 4, TaxRateCode = "P0", LowerLimit = 0, UpperLimit = 8350.99m},
                new TaxBand{ Id = 5, TaxRateCode = "P1", LowerLimit = 8351.00m, UpperLimit = 33950.99m},
                new TaxBand{ Id = 6, TaxRateCode = "P2", LowerLimit = 33951.00m, UpperLimit = 82250.99m},
                new TaxBand{ Id = 7, TaxRateCode = "P3", LowerLimit = 82251.00m, UpperLimit = 171550.99m},
                new TaxBand{ Id = 8, TaxRateCode = "P4", LowerLimit = 171551.00m, UpperLimit = 372950.99m},
                new TaxBand{ Id = 9, TaxRateCode = "P5", LowerLimit = 372951.00m}
         * */
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
            // Arrange
            var id = 1;

            // Act
            var taxBand = _taxBandsService.GetTaxBandById(id)

            // Assert
            Assert.That()
        }

        [Test]
        public void ShouldGetAllTaxBands() {
            // Arrange

            // Act
            _taxBandsService.GetAllTaxBands();

            // Assert
        }
        

    }
}
