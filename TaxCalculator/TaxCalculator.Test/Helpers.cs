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

        internal static IEnumerable<TaxBand> CreateTaxBands()
        {
            return new List<TaxBand>
            {
                new TaxBand{ Id = 1, TaxRateCode = "FV0", LowerLimit = 0m, UpperLimit = 199999.99m, IsActive = true},
                new TaxBand{ Id = 2, TaxRateCode = "FV1", LowerLimit = 200000.00m, IsActive = true},
                new TaxBand{ Id = 3, TaxRateCode = "FR" , IsActive = true},
                new TaxBand{ Id = 4, TaxRateCode = "P0", LowerLimit = 0, UpperLimit = 8350.99m, IsActive = true},
                new TaxBand{ Id = 5, TaxRateCode = "P1", LowerLimit = 8351.00m, UpperLimit = 33950.99m, IsActive = true},
                new TaxBand{ Id = 6, TaxRateCode = "P2", LowerLimit = 33951.00m, UpperLimit = 82250.99m, IsActive = true},
                new TaxBand{ Id = 7, TaxRateCode = "P3", LowerLimit = 82251.00m, UpperLimit = 171550.99m, IsActive = true},
                new TaxBand{ Id = 8, TaxRateCode = "P4", LowerLimit = 171551.00m, UpperLimit = 372950.99m, IsActive = true},
                new TaxBand{ Id = 9, TaxRateCode = "P5", LowerLimit = 372951.00m, IsActive = true }
            };
        }
    }
}
