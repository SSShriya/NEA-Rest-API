using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NEA_Rest_API.Models;

public partial class NeaContext : DbContext
{
    public NeaContext()
    {
    }

    public NeaContext(DbContextOptions<NeaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pairing> Pairings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pairing>(entity =>
        {
            entity.HasKey(e => new { e.PairingId}).HasName("PK__pairings__CB9A1CDF6DC5F187");

            entity.ToTable("pairings");
            entity.Property(e => e.User1).HasColumnName("user1");
            entity.Property(e => e.User2).HasColumnName("user2");

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__CB9A1CDF6DC5F187");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Username)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
