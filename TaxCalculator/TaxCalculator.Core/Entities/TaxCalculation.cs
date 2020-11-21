using System;

namespace TaxCalculator.Core.Entities
{
    public partial class TaxCalculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public int TaxTypeId { get; set; }
        public int TaxRateId { get; set; }
        public int TaxBandId { get; set; }
        public decimal IncomeValue { get; set; }
        public decimal CalculatedTaxValue { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
