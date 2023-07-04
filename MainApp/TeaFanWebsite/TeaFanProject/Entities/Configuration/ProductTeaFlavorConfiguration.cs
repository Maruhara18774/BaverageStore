using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductTeaFlavorConfiguration : IEntityTypeConfiguration<ProductTeaFlavor>
    {
        public void Configure(EntityTypeBuilder<ProductTeaFlavor> builder)
        {
            builder.ToTable("ProductTeaFlavors");
            builder.HasKey(x => x.ProductTeaFlavorID);
            builder.HasOne(x => x.ProductTea).WithMany(x => x.ProductTeaFlavors).HasForeignKey(x => x.ProductTeaID);
            builder.HasOne(x => x.Flavor).WithMany(x => x.ProductTeaFlavors).HasForeignKey(x => x.FlavorID);
        }
    }
}
