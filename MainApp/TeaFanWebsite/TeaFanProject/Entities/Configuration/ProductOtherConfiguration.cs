using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductOtherConfiguration : IEntityTypeConfiguration<ProductOther>
    {
        public void Configure(EntityTypeBuilder<ProductOther> builder)
        {
            builder.ToTable("ProductOthers");
            builder.HasKey(x => x.ProductOtherID);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductOthers).HasForeignKey(x => x.ProductID);
        }
    }
}
