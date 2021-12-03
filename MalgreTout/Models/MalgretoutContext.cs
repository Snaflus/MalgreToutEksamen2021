﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MalgreTout.Models
{
    public partial class MalgretoutContext : DbContext
    {
        public MalgretoutContext()
        {
        }

        public MalgretoutContext(DbContextOptions<MalgretoutContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contactperson> Contactpeople { get; set; }
        public virtual DbSet<DistributionPoint> DistributionPoints { get; set; }
        public virtual DbSet<NoOfMagazine> NoOfMagazines { get; set; }
        public virtual DbSet<OpeningHour> OpeningHours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MalgreTout;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contactperson>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK__Contactp__82ACC1CD6E12835E");

                entity.Property(e => e.Contactperson1).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Contactpeople)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Contactpe__Locat__76619304");
            });

            modelBuilder.Entity<DistributionPoint>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Distribu__D2BA00C20464E1FF");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Company).IsUnicode(false);
            });

            modelBuilder.Entity<NoOfMagazine>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__No_of_ma__D2BA00C2C8EFD312");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.NoOfMagazine)
                    .HasForeignKey<NoOfMagazine>(d => d.LocationId)
                    .HasConstraintName("FK__No_of_mag__Locat__73852659");
            });

            modelBuilder.Entity<OpeningHour>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__Opening___D2BA00C260D8F073");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.OpeningHour1).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.OpeningHour)
                    .HasForeignKey<OpeningHour>(d => d.LocationId)
                    .HasConstraintName("FK__Opening_h__Locat__70A8B9AE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}