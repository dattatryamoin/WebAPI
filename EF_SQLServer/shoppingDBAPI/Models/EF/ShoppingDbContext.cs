using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shoppingDBAPI.Models.EF;

public partial class ShoppingDbContext : DbContext
{
    public ShoppingDbContext()
    {
    }

    public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductsList> ProductsLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=shoppingDB;integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductsList>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__products__DD37D91A32EAA5C3");

            entity.ToTable("productsList");

            entity.Property(e => e.Pid)
                .ValueGeneratedNever()
                .HasColumnName("pid");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PImage)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("pImage");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice)
                .HasColumnType("money")
                .HasColumnName("pPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
