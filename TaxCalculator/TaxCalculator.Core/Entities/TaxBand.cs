using System;

namespace TaxCalculator.Core.Entities
{
    public partial class TaxBand
    {
        public int Id { get; set; }
        public string TaxRateCode { get; set; }
        public decimal? LowerLimit { get; set; }
        public decimal? UpperLimit { get; set; }
        public int TaxTypeId{ get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
