using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class FlavorConfiguration : IEntityTypeConfiguration<Flavor>
    {
        public void Configure(EntityTypeBuilder<Flavor> builder)
        {
            builder.ToTable("Flavors");
            builder.HasKey(x => x.FlavorID);
            builder.Property(x => x.FlavorName).HasMaxLength(20);
        }
    }
}
