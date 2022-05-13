using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AutoShowroomFinal
{
    public partial class DBAutoContext : DbContext
    {
        public DBAutoContext()
        {
        }

        public DBAutoContext(DbContextOptions<DBAutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AutoShowroom> AutoShowrooms { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarAutoShowroom> CarAutoShowrooms { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CountryCar> CountryCars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= OLENAKARDASH-PC; Database=DBAuto; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoShowroom>(entity =>
            {
                entity.ToTable("AutoShowroom");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.Info).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Info).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cars_Brand");
            });

            modelBuilder.Entity<CarAutoShowroom>(entity =>
            {
                entity.ToTable("CarAutoShowroom");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CarId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CarAutoShowrooms)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarAutoShowroom_AutoShowroom");

                entity.HasOne(d => d.Showroom)
                    .WithMany(p => p.CarAutoShowrooms)
                    .HasForeignKey(d => d.ShowroomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CarAutoShowroom_AutoShowroom1");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Info).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CountryCar>(entity =>
            {
                entity.HasOne(d => d.Car)
                    .WithMany(p => p.CountryCars)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryCars_Cars");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryCars)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryCars_Country");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
