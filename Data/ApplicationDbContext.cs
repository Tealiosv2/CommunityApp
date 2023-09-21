using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Models;

namespace CommunityApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        builder.Entity<City>().Property(c => c.ProvinceCode).IsRequired();
        builder.Entity<Province>().Property(p => p.ProvinceCode).HasMaxLength(30);

        builder.Entity<Province>().ToTable("Province");
        builder.Entity<City>().ToTable("City");

        builder.Seed();
    }
    public DbSet<Province>? Provinces { get; set; }
    public DbSet<City>? CIties { get; set; }
}
