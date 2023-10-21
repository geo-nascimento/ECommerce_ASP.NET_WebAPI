using eCommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eCommerce.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Password).HasMaxLength(2000).IsRequired();
        builder.Property(u => u.BirthDate).IsRequired();
        builder.Property(u => u.PhoneNumber).HasMaxLength(15).IsRequired();


        builder
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId);
        builder
            .HasMany(u => u.Avaluations)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);
        

    }
}