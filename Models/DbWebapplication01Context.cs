using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Delicious_Food_Recipes.Models;

public partial class DbWebapplication01Context : DbContext
{
    public DbWebapplication01Context()
    {
    }

    public DbWebapplication01Context(DbContextOptions<DbWebapplication01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Favorite> Favorites { get; set; } // Yeni eklenen Favorites DbSet

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Users tablosu tanımı
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__users__B51D3DEAB1A558D6");

            entity.ToTable("users");

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("u_email");
            entity.Property(e => e.UKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("u_key");
            entity.Property(e => e.UName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("u_name");
        });

        // Favorites tablosu tanımı
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__favorites__ID");

            entity.ToTable("favorites");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.UserKey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserKey");
            entity.Property(e => e.RecipeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RecipeId");
            entity.Property(e => e.RecipeImgUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RecipeImgUrl");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RecipeName");
            entity.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GETDATE()"); // Varsayılan olarak tarih atanır
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
