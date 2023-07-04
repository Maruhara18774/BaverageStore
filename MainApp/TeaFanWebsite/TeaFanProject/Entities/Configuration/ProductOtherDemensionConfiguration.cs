using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductOtherDemensionConfiguration : IEntityTypeConfiguration<ProductOtherDemension>
    {
        public void Configure(EntityTypeBuilder<ProductOtherDemension> builder)
        {
            builder.ToTable("ProductOtherDemensions");
            builder.HasKey(x => x.ProductOtherDemensionID);
            builder.HasOne(x => x.ProductOther).WithMany(x => x.ProductOtherDemensions).HasForeignKey(x => x.ProductOtherID);
            builder.HasOne(x => x.Demension).WithMany(x => x.OtherDemensions).HasForeignKey(x => x.DemensionID);
            builder.Property(x => x.Value).HasDefaultValue(0);
        }
    }
}
