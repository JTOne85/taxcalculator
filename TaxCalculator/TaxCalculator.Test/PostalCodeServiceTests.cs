using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.PostalCodes;
using TaxCalculator.Core.Services.PostalCodes;

namespace TaxCalculator.Test
{
    [TestFixture]
    public class PostalCodeServiceTests
    {
        private PostalCodeService _postalCodeService;
        private Mock<IPostalCodeRepository> _postCodeRepository;
        private IEnumerable<PostalCode> _postCodes;

        [SetUp]
        public void Setup()
        {
            _postCodes = Helpers.CreatePostalCodes();
            _postCodeRepository = new Mock<IPostalCodeRepository>();
            _postCodeRepository.Setup(p => p.GetAll()).Returns(_postCodes.AsQueryable());

            _postalCodeService = new PostalCodeService(_postCodeRepository.Object);
        }

        [Test]
        public void ShouldGetAllPostalCodes()
        {
            // Act
            var allCodes = _postalCodeService.GetAllPostalCodes();

            // Assert
            Assert.That(allCodes.Count(), Is.EqualTo(_postCodes.Count()));
        }

        [TestCase("7441", 3)]
        [TestCase("A100", 1)]
        [TestCase("7000", 2)]
        [TestCase("1000", 3)]
        public void ShouldGetTaxTypeIdByPostalCode(string postCode, int taxTypeId)
        {
            // Act
            var code = _postalCodeService.GetPostalCodeFromCode(postCode);

            // Assert
            Assert.That(code.TaxTypeId, Is.EqualTo(taxTypeId));            
        }
    }
}