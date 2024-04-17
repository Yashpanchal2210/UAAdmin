using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UAAdmin;

public partial class UrbanAutoMasterContext : DbContext
{
    public UrbanAutoMasterContext()
    {
    }

    public UrbanAutoMasterContext(DbContextOptions<UrbanAutoMasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

    public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }

    public virtual DbSet<VehicleDetail> VehicleDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-Q1O8T76\\SQLEXPRESS;user=UrbanAutoDB;password=sa@123;database=UrbanAutoMaster;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A04FE786A5C");

            entity.Property(e => e.ClientId).ValueGeneratedNever();

            entity.HasOne(d => d.SubscriptionPlan).WithMany(p => p.Clients).HasConstraintName("FK_SubscriptionPlanID");
        });

        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("PK__Subscrip__755C22D79CBEB3EB");

            entity.Property(e => e.PlanId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SuperAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__SuperAdm__719FE4E87ACC9591");

            entity.Property(e => e.AdminId).ValueGeneratedNever();
        });

        modelBuilder.Entity<VehicleDetail>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__VehicleD__7516F4ECAFD3C033");

            entity.Property(e => e.ImageId).ValueGeneratedNever();

            entity.HasOne(d => d.Client).WithMany(p => p.VehicleDetails).HasConstraintName("FK_ClientID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
