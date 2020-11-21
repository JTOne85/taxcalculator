using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Services
{
    public interface ITaxTypeService
    {
        IEnumerable<TaxType> GetAll();
        TaxType GetTaxTypeById(int id);
    }
}
