using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CreditCarbonAPI.Models;

public partial class CarbonCreditContext : DbContext
{
    public CarbonCreditContext()
    {
    }

    public CarbonCreditContext(DbContextOptions<CarbonCreditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarbonMarket> CarbonMarkets { get; set; }

    public virtual DbSet<ProjectCarbon> ProjectCarbons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TechnologyType> TechnologyTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=C1001226\\SQLEXPRESS;Database=CarbonCredit;User=sa; Password=1234; TrustServerCertificate=True; Encrypt=False; MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarbonMarket>(entity =>
        {
            entity.HasKey(e => e.CarbonMarketsId);

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProjectCarbon).WithMany(p => p.CarbonMarkets)
                .HasForeignKey(d => d.ProjectCarbonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarbonMarkets_ProjectCarbon");
        });

        modelBuilder.Entity<ProjectCarbon>(entity =>
        {
            entity.ToTable("ProjectCarbon");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Coordinator).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Developer).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.LocationCoordinates).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.ProjectDescription).HasMaxLength(255);
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Tel).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.ProjectCarbons)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Status");

            entity.HasOne(d => d.TechnologyType).WithMany(p => p.ProjectCarbons)
                .HasForeignKey(d => d.TechnologyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_TechnologyType");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectCarbons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK_StagesStatus");

            entity.ToTable("Status");

            entity.Property(e => e.StatusText).HasMaxLength(20);
        });

        modelBuilder.Entity<TechnologyType>(entity =>
        {
            entity.ToTable("TechnologyType");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TechnologyTypeCode).HasMaxLength(50);
            entity.Property(e => e.TechnologyTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Business).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.Tel).HasMaxLength(10);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Wallet).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WalletCarbon).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
