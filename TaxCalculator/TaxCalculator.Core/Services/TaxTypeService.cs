using System.Collections.Generic;
using System.Linq;
using TaxCalculator.Core.Entities;
using TaxCalculator.Core.Repositories;
using TaxCalculator.Core.Repositories.TaxTypes;

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

        public TaxType GetTaxTypeById(int Id)
        {
            return _taxTypeRepository.GetAll().FirstOrDefault(t => t.Id == Id);
        }

    }
}
