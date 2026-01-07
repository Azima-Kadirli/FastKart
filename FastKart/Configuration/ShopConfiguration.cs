using FastKart.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastKart.Configuration;

public class ShopConfiguration:IEntityTypeConfiguration<Shop>
{
    public void Configure(EntityTypeBuilder<Shop> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        //builder.HasMany(b => b.Products).WithOne(x => x.Shops).HasForeignKey(p => p.Id).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(s => s.Products).WithMany(p => p.Shops);
    }
}