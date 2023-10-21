using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Manufacturer).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Value).HasPrecision(10, 2).IsRequired();
        builder.Property(p => p.Stock).IsRequired();
        
        //Relações
        builder
            .HasMany(p => p.Orders)
            .WithMany(p => p.Products);
        builder
            .HasMany(p => p.Avaluations)
            .WithOne(a => a.Product)
            .HasForeignKey(a => a.ProductId);
        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

    }
}