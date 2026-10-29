using DotnetApi.Entities;
using DotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Data;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Permission> Permision { get; set; }

    public DbSet<RolePermission> RolePermission { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
           modelBuilder.Entity<RolePermission>()
        .HasOne(rp => rp.Role)
        .WithMany(r => r.RolePermissions)
        .HasForeignKey(rp => rp.RoleId);

    modelBuilder.Entity<RolePermission>()
        .HasOne(rp => rp.Permission)
        .WithMany(p => p.RolePermissions)
        .HasForeignKey(rp => rp.PermissionId);

    modelBuilder.Entity<RolePermission>()
        .HasIndex(rp => new { rp.RoleId, rp.PermissionId })
        .IsUnique();

    modelBuilder.Entity<Permission>()
        .HasIndex(p => p.Name)
        .IsUnique();
    }
}