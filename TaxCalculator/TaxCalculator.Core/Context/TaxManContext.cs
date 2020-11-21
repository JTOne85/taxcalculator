using Microsoft.EntityFrameworkCore;
using TaxCalculator.Core.Entities;

namespace TaxCalculator.Core.Context
{
    public partial class TaxManContext : DbContext
    {
        public TaxManContext()
        {
        }

        public TaxManContext(DbContextOptions<TaxManContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PostalCode> PostalCodes { get; set; }
        public virtual DbSet<TaxBand> TaxBands { get; set; }
        public virtual DbSet<TaxCalculation> TaxCalculations { get; set; }
        public virtual DbSet<TaxRate> TaxRates { get; set; }
        public virtual DbSet<TaxType> TaxTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
