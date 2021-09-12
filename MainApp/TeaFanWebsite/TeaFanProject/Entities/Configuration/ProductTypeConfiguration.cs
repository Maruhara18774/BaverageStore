using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");
            builder.HasKey(x => x.TypeID);
            builder.Property(x => x.TypeName).HasMaxLength(150);
            builder.HasOne(x => x.Category).WithMany(x => x.ProductTypes).HasForeignKey(x => x.CategoryID);
        }
    }
}
