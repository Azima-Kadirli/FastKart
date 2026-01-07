using FastKart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastKart.Configuration;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p=>p.Price).IsRequired().HasColumnType("decimal(18,2)");
        //builder.HasOne(p => p.Shop).WithMany(s => s.Products).HasPrincipalKey(p=>p.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p=>p.Shops).WithMany(p => p.Products);
    }
}