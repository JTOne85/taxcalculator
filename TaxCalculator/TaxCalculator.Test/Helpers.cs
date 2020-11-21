using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Test
{
    internal abstract class Helpers
    {

        public static IEnumerable<TaxType> CreateTaxTypes()
        {
            return new List<TaxType>();
        }
    }
}
