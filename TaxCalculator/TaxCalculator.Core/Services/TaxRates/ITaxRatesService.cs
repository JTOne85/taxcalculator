using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Services.TaxRates
{
    internal interface ITaxRatesService
    {
        IEnumerable<TaxRate> GetAll();
    }
}