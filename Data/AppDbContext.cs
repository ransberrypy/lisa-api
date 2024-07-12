using Microsoft.EntityFrameworkCore;
using LisaApi.Models;
namespace LisaApi.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Lease> Leases { get; set; }
    public DbSet<TenantLease> TenantLeases { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Witness> Witnesses { get; set; }


    public void SaveTenantLease(TenantLease tenantLease)
    {
        // Round the AmountPaid property to 2 decimal places before saving
        tenantLease.AmountPaid = decimal.Round(tenantLease.AmountPaid, 2);
        // Add the TenantLease object to the DbSet
        TenantLeases.Add(tenantLease);
        // Save the changes to the database
        SaveChanges();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TenantLease>()
            .HasKey(tp => new { tp.PropertyId, tp.TenantId });

        modelBuilder.Entity<TenantLease>()
            .HasOne(tp => tp.Property)
            .WithMany(p => p.TenantLease)
            .HasForeignKey(tp => tp.PropertyId);

        modelBuilder.Entity<TenantLease>()
            .HasOne(tp => tp.Tenant)
            .WithMany(t => t.TenantLease)
            .HasForeignKey(tp => tp.TenantId);
    }

}

