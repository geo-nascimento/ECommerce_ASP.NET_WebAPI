using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.DatabaseContext;

public class eCommerceDbContext : DbContext
{
    public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options)
    {
        
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Avaluation>? Avaluations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(eCommerceDbContext).Assembly);
    }
}