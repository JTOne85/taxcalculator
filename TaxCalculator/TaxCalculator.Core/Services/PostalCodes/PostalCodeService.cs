using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories.PostalCodes;

namespace TaxCalculator.Core.Services.PostalCodes
{
    public class PostalCodeService : IPostalCodeService
    {
        private IPostalCodeRepository _postalCodeRepository;

        public PostalCodeService(IPostalCodeRepository postalCodeRepository)
        {
            _postalCodeRepository = postalCodeRepository;
        }

        public IEnumerable<PostalCode> GetAllPostalCodes()
        {
            return _postalCodeRepository.GetAll();
        }

        public PostalCode GetPostalCodeFromCode(string postCode)
        {
            return _postalCodeRepository.GetAll().FirstOrDefault(p => p.PostalCode1 == postCode);
        }
    }
}
