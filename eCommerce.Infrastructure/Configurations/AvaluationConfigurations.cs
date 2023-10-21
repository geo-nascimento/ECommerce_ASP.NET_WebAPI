using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Configurations;

public class AvaluationConfigurations: IEntityTypeConfiguration<Avaluation>
{
    public void Configure(EntityTypeBuilder<Avaluation> builder)
    {
        builder.HasKey(a => a.Id);
        builder
            .Property(a => a.Grade)
            .HasPrecision(2, 2)
            .HasAnnotation("MinValue", 0)
            .HasAnnotation("MaxValue", 10)
            .IsRequired();
        builder
            .Property(a => a.Comment)
            .HasColumnType("TEXT")
            .IsRequired();

        builder
            .HasOne(a => a.User)
            .WithMany(u => u.Avaluations)
            .HasForeignKey(a => a.UserId);
        builder
            .HasOne(a => a.Product)
            .WithMany(p => p.Avaluations)
            .HasForeignKey(a => a.ProductId);
    }
}