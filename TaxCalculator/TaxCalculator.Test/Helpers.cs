using System.Collections.Generic;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Test
{
    internal abstract class Helpers
    {

        public static IEnumerable<TaxType> CreateTaxTypes()
        {
            return new List<TaxType> {
                new TaxType { Id = 1, TaxTypeDescription = "Flat value"},
                new TaxType{ Id = 2, TaxTypeDescription = "Flat Rate"},
                new TaxType{Id = 3, TaxTypeDescription = "Progressive rate" }
            };
        }
    }
}
