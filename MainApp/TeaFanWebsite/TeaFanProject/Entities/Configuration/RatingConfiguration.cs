using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeaFanProject.Entities.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Ratings");
            builder.HasKey(x => x.RatingID);
            builder.HasOne(x => x.User).WithMany(x => x.Ratings).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Product).WithMany(x => x.Ratings).HasForeignKey(x => x.ProductID);
            builder.Property(x => x.StarCount).HasDefaultValue(0);
            builder.Property(x => x.Title).HasMaxLength(150);
        }
    }
}
