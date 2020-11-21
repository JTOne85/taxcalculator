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
            //modelBuilder.Entity<PostalCode>(entity =>
            //{
            //    entity.HasKey(e => new { e.PostalCode1, e.TaxTypeId })
            //        .HasName("PK_postcode");

            //    entity.ToTable("PostalCode");

            //    entity.Property(e => e.PostalCode1)
            //        .HasMaxLength(10)
            //        .HasColumnName("PostalCode");
            //});

            //modelBuilder.Entity<TaxBand>(entity =>
            //{
            //    entity.HasKey(e => e.TaxRateCode)
            //        .HasName("PK__TaxBands__58C0182AAF938850");

            //    entity.Property(e => e.TaxRateCode).HasMaxLength(3);

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.LowerLimit).HasColumnType("decimal(9, 3)");

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.UpperLimit).HasColumnType("decimal(9, 3)");
            //});

            //modelBuilder.Entity<TaxCalculation>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.CalculatedTaxValue).HasColumnType("decimal(10, 3)");

            //    entity.Property(e => e.DateCreated).HasColumnType("datetime");

            //    entity.Property(e => e.IncomeValue).HasColumnType("decimal(9, 2)");

            //    entity.Property(e => e.PostalCode)
            //        .IsRequired()
            //        .HasMaxLength(10);
            //});

            //modelBuilder.Entity<TaxRate>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.RateValue).HasColumnType("decimal(8, 3)");

            //    entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<TaxType>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("TaxType");

            //    entity.Property(e => e.TaxTypeDescription)
            //        .IsRequired()
            //        .HasMaxLength(255);
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
