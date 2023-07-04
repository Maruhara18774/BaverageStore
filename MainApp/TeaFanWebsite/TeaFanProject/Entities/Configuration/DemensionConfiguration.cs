using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class DemensionConfiguration : IEntityTypeConfiguration<Demension>
    {
        public void Configure(EntityTypeBuilder<Demension> builder)
        {
            builder.ToTable("Demensions");
            builder.HasKey(x => x.DemensionID);
            builder.Property(x => x.DemensionName).HasMaxLength(150);
        }
    }
}
