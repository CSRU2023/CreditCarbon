using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CreditCarbonAPI.Models;

public partial class CarbonCreditContext : DbContext
{
    public CarbonCreditContext(DbContextOptions<CarbonCreditContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProjectCarbon> ProjectCarbons { get; set; }

    public virtual DbSet<ProjectCarbonDeveloper> ProjectCarbonDevelopers { get; set; }

    public virtual DbSet<ProjectCarbonMarket> ProjectCarbonMarkets { get; set; }

    public virtual DbSet<ProjectCarbonStatus> ProjectCarbonStatuses { get; set; }

    public virtual DbSet<ProjectCarbonTransaction> ProjectCarbonTransactions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TechnologyType> TechnologyTypes { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletTransaction> WalletTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectCarbon>(entity =>
        {
            entity.ToTable("ProjectCarbon");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Coordinator).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.LocationCoordinates).HasMaxLength(255);
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.ProjectDescription).HasMaxLength(255);
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.ProjectOwner).HasMaxLength(255);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Tel).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.TechnologyType).WithMany(p => p.ProjectCarbons)
                .HasForeignKey(d => d.TechnologyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_TechnologyType");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectCarbons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_User");
        });

        modelBuilder.Entity<ProjectCarbonDeveloper>(entity =>
        {
            entity.ToTable("ProjectCarbon_Developer");

            entity.Property(e => e.ProjectCarbonDeveloperId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectCarbon_DeveloperId");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Coordinator).HasMaxLength(100);
            entity.Property(e => e.Developer).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(50);
            entity.Property(e => e.ProjectCarbonId).ValueGeneratedOnAdd();
            entity.Property(e => e.Tel).HasMaxLength(10);

            entity.HasOne(d => d.ProjectCarbon).WithMany(p => p.ProjectCarbonDevelopers)
                .HasForeignKey(d => d.ProjectCarbonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Developer_ProjectCarbon");
        });

        modelBuilder.Entity<ProjectCarbonMarket>(entity =>
        {
            entity.HasKey(e => e.ProjectCarbonMarketsId).HasName("PK_CarbonMarkets");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProjectCarbon).WithMany(p => p.ProjectCarbonMarkets)
                .HasForeignKey(d => d.ProjectCarbonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbonMarkets_ProjectCarbon");
        });

        modelBuilder.Entity<ProjectCarbonStatus>(entity =>
        {
            entity.ToTable("ProjectCarbon_Status");

            entity.Property(e => e.ProjectCarbonStatusId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectCarbon_StatusId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Massage).HasMaxLength(100);

            entity.HasOne(d => d.ProjectCarbon).WithMany(p => p.ProjectCarbonStatuses)
                .HasForeignKey(d => d.ProjectCarbonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Status_ProjectCarbon");

            entity.HasOne(d => d.Status).WithMany(p => p.ProjectCarbonStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Status_Status");
        });

        modelBuilder.Entity<ProjectCarbonTransaction>(entity =>
        {
            entity.ToTable("ProjectCarbon_Transaction");

            entity.Property(e => e.ProjectCarbonTransactionId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectCarbon_TransactionId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Massage).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ProjectCarbon).WithMany(p => p.ProjectCarbonTransactions)
                .HasForeignKey(d => d.ProjectCarbonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Transaction_ProjectCarbon");

            entity.HasOne(d => d.TransactionType).WithMany(p => p.ProjectCarbonTransactions)
                .HasForeignKey(d => d.TransactionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProjectCarbon_Transaction_TransactionType");
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

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TechnologyType>(entity =>
        {
            entity.ToTable("TechnologyType");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TechnologyTypeCode).HasMaxLength(50);
            entity.Property(e => e.TechnologyTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.ToTable("TransactionType");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.TransactionTypeCode).HasMaxLength(50);
            entity.Property(e => e.TransactionTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.AmphurKhet)
                .HasMaxLength(100)
                .HasColumnName("Amphur_Khet");
            entity.Property(e => e.Business).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Occupation).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(10);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity.Property(e => e.Province).HasMaxLength(100);
            entity.Property(e => e.TambolKhwaeng)
                .HasMaxLength(100)
                .HasColumnName("Tambol_Khwaeng");
            entity.Property(e => e.Tel).HasMaxLength(10);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasColumnName("Zip_Code");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WalletCarbon).HasColumnType("numeric(18, 2)");
            entity.Property(e => e.WalletMoney).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<WalletTransaction>(entity =>
        {
            entity.ToTable("WalletTransaction");

            entity.Property(e => e.WalletTransactionId).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Massage).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WalletCarbon).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WalletMoney).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
