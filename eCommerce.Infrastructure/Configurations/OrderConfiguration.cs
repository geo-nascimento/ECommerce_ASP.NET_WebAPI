using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.TotalValue).HasPrecision(10, 2);
        builder.Property(o => o.Status).HasConversion<string>().HasMaxLength(15).IsRequired();

        builder
            .HasMany(o => o.Products)
            .WithMany(p => p.Orders);
        builder
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);
    }
}