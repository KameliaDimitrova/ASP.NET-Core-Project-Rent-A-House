using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentAHouse.Data.Model;

namespace RentAHouse.Data;
public class RentAHouseDbContext : IdentityDbContext
{
    public RentAHouseDbContext(DbContextOptions<RentAHouseDbContext> options)
        : base(options)
    {
    }

    public DbSet<Region> Regions { get; init; }

    public DbSet<Municipality> Municipalities { get; init; }

    public DbSet<Settlement> Settlements { get; init; }

    public DbSet<House> Houses { get; init; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Region>()
            .HasMany(r => r.Municipalities);

        builder
            .Entity<Municipality>()
            .HasOne(r => r.Region)
            .WithMany(x => x.Municipalities)
            .HasForeignKey(r => r.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<Municipality>()
            .HasOne(r => r.Region)
            .WithMany(x => x.Municipalities)
            .HasForeignKey(r => r.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<Settlement>()
            .HasOne(r => r.Municipality)
            .WithMany(x => x.Settlements)
            .HasForeignKey(r => r.MunicipalityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<House>()
            .HasOne(h => h.Settlement)
            .WithMany(h => h.Houses)
            .HasForeignKey(h => h.SettlementId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(builder);
    }
}
