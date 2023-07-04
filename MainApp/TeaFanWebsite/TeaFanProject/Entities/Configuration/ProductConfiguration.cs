using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductID);
            builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandID);
            builder.HasOne(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.TypeID);
            builder.Property(x => x.Price).HasDefaultValue(0);
            builder.Property(x => x.SalePrice).HasDefaultValue(0);
            builder.Property(x => x.Quantity).HasDefaultValue(0);
        }
    }
}
