using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class ProductTeaConfiguration : IEntityTypeConfiguration<ProductTea>
    {
        public void Configure(EntityTypeBuilder<ProductTea> builder)
        {
            builder.ToTable("ProductTeas");
            builder.HasKey(x => x.ProductTeaID);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductTeas).HasForeignKey(x => x.ProductID);
        }
    }
}
