using System;
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

        internal static IEnumerable<PostalCode> CreatePostalCodes()
        {
            return new List<PostalCode> {
              new PostalCode { Id = 1, PostalCode1 = "7441", TaxTypeId = 3},
              new PostalCode { Id = 2, PostalCode1 = "A100", TaxTypeId = 1},
              new PostalCode { Id = 3, PostalCode1 = "7000", TaxTypeId = 2},
              new PostalCode { Id = 4, PostalCode1 = "1000", TaxTypeId = 3}
            };
        }
    }
}
