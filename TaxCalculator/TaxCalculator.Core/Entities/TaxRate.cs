using System;

namespace TaxCalculator.Core.Entities
{
    public partial class TaxRate
    {
        public int Id { get; set; }
        public int TaxBandId { get; set; }
        public int TaxTypeId { get; set; }
        public decimal RateValue { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
