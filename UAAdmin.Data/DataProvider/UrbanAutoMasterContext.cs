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

    public virtual DbSet<AdminCred> AdminCreds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=NIKHIL-PANCHAL\\SQLEXPRESS;user=UrbanAuto;password=UA@123;database=UrbanAutoMaster;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminCred>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminCre__3214EC0793A4E102");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
