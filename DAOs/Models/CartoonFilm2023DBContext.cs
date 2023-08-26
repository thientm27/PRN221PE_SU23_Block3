using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DAOs.Models
{
    public partial class CartoonFilm2023DBContext : DbContext
    {
        public CartoonFilm2023DBContext()
        {
        }

        public CartoonFilm2023DBContext(DbContextOptions<CartoonFilm2023DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartoonFilmInformation> CartoonFilmInformations { get; set; } = null!;
        public virtual DbSet<MemberAccount> MemberAccounts { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("server =(local); database = CartoonFilm2023DB;uid=sa;pwd=123456;TrustServerCertificate=True");
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionString"];
            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartoonFilmInformation>(entity =>
            {
                entity.HasKey(e => e.CartoonFilmId)
                    .HasName("PK__CartoonF__BEE8C084A5EB6F45");

                entity.ToTable("CartoonFilmInformation");

                entity.Property(e => e.CartoonFilmId).ValueGeneratedNever();

                entity.Property(e => e.CartoonFilmDescription).HasMaxLength(250);

                entity.Property(e => e.CartoonFilmName).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProducerId).HasMaxLength(30);

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.CartoonFilmInformations)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__CartoonFi__Produ__3C69FB99");
            });

            modelBuilder.Entity<MemberAccount>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__MemberAc__0CF04B38477EAD39");

                entity.ToTable("MemberAccount");

                entity.HasIndex(e => e.Email, "UQ__MemberAc__A9D10534E3D721BF")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("MemberID");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.FullName).HasMaxLength(60);

                entity.Property(e => e.Password).HasMaxLength(40);
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.ToTable("Producer");

                entity.Property(e => e.ProducerId).HasMaxLength(30);

                entity.Property(e => e.Country).HasMaxLength(60);

                entity.Property(e => e.ProducerDescription).HasMaxLength(250);

                entity.Property(e => e.ProducerName).HasMaxLength(90);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
