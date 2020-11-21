using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories;
using TaxCalculator.Core.Services;

namespace TaxCalculator.Test
{
    [TestFixture]
    public class TaxTypeServiceTests
    {
        private TaxTypeService _taxTypeService;
        private Mock<ITaxTypeRepository> _taxTypeRepository;

        [SetUp]
        public void Setup()
        {
            _taxTypeRepository = new Mock<ITaxTypeRepository>();

            _taxTypeService = new TaxTypeService(_taxTypeRepository.Object);
        }

        [Test]
        public void ShouldGetAllTaxTypes()
        {
            // Arrange
            var taxTypes = Helpers.CreateTaxTypes();
            _taxTypeRepository.Setup(r => r.GetAll()).Returns(taxTypes.AsQueryable());

            // Act
            var allTypes = _taxTypeService.GetAll();

            // Assert
            Assert.AreEqual(allTypes.Count(), 3);
        }

        [Test]
        [TestCase(1, "Flat value")]
        [TestCase(2, "Flat Rate")]
        [TestCase(3, "Progressive rate")]
        public void ShouldGetTaxTypeById(int id, string description)
        {
            // Arrange
            var taxTypes = Helpers.CreateTaxTypes();
            _taxTypeRepository.Setup(r => r.GetAll()).Returns(taxTypes.AsQueryable());

            // Act
            var taxType = _taxTypeService.GetTaxTypeById(id);

            // Assert
            Assert.That(taxType.Id, Is.EqualTo(id));
            Assert.That(taxType.TaxTypeDescription, Is.EqualTo(description));


        }
    }
}

