using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Home_Work.Models.Data.Entity;

namespace Home_Work.Models.Data
{
    public partial class HomeWorkDbContext : DbContext
    {
        public HomeWorkDbContext()
        {
        }

        public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblItem> TblItems { get; set; } = null!;
        public virtual DbSet<TblPartner> TblPartners { get; set; } = null!;
        public virtual DbSet<TblPartnerType> TblPartnerTypes { get; set; } = null!;
        public virtual DbSet<TblPurchase> TblPurchases { get; set; } = null!;
        public virtual DbSet<TblPurchaseDetail> TblPurchaseDetails { get; set; } = null!;
        public virtual DbSet<TblSale> TblSales { get; set; } = null!;
        public virtual DbSet<TblSalesDetail> TblSalesDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog = HomeWork; Trusted_Connection = True; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.IntItemId);

                entity.ToTable("tblItem");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumStockQuantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numStockQuantity");

                entity.Property(e => e.StrItemName)
                    .HasMaxLength(250)
                    .HasColumnName("strItemName");
            });

            modelBuilder.Entity<TblPartner>(entity =>
            {
                entity.HasKey(e => e.IntPartnerId);

                entity.ToTable("tblPartner");

                entity.Property(e => e.IntPartnerId).HasColumnName("intPartnerId");

                entity.Property(e => e.IntPartnerTypeId).HasColumnName("intPartnerTypeId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrPartnerName)
                    .HasMaxLength(250)
                    .HasColumnName("strPartnerName");
            });

            modelBuilder.Entity<TblPartnerType>(entity =>
            {
                entity.HasKey(e => e.IntPartnerTypeId);

                entity.ToTable("tblPartnerType");

                entity.Property(e => e.IntPartnerTypeId).HasColumnName("intPartnerTypeId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StrPartnerTypeName)
                    .HasMaxLength(250)
                    .HasColumnName("strPartnerTypeName");
            });

            modelBuilder.Entity<TblPurchase>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseId);

                entity.ToTable("tblPurchase");

                entity.Property(e => e.IntPurchaseId).HasColumnName("intPurchaseId");

                entity.Property(e => e.DtePurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePurchaseDate");

                entity.Property(e => e.IntSupplierId).HasColumnName("intSupplierId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TblPurchaseDetail>(entity =>
            {
                entity.HasKey(e => e.IntPurchaseDetailsId);

                entity.ToTable("tblPurchaseDetails");

                entity.Property(e => e.IntPurchaseDetailsId).HasColumnName("intPurchaseDetailsId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntPurchaseId).HasColumnName("intPurchaseId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumQuantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numQuantity");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");
            });

            modelBuilder.Entity<TblSale>(entity =>
            {
                entity.HasKey(e => e.IntSalesId);

                entity.ToTable("tblSales");

                entity.Property(e => e.IntSalesId).HasColumnName("intSalesId");

                entity.Property(e => e.DteSalesDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSalesDate");

                entity.Property(e => e.IntCustomerId).HasColumnName("intCustomerId");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(10)
                    .HasColumnName("isActive")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblSalesDetail>(entity =>
            {
                entity.HasKey(e => e.IntSalesDetailsId);

                entity.ToTable("tblSalesDetails");

                entity.Property(e => e.IntSalesDetailsId).HasColumnName("intSalesDetailsId");

                entity.Property(e => e.IntItemId).HasColumnName("intItemId");

                entity.Property(e => e.IntSalesId).HasColumnName("intSalesId");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NumQuantity)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numQuantity");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
