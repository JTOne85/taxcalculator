using System.Collections.Generic;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories;

namespace TaxCalculator.Core.Services
{
    public class TaxTypeService : ITaxTypeService
    {
        private readonly ITaxTypeRepository _taxTypeRepository;

        public TaxTypeService(ITaxTypeRepository taxTypeRepository)
        {
            _taxTypeRepository = taxTypeRepository;
        }

        public IEnumerable<TaxType> GetAll()
        {
            return _taxTypeRepository.GetAll();
        }
    }
}
