using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Entities;
using TeaFanProject.Entities.Configuration;

namespace TeaFanProject.Data
{
    public class ApplicationDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTea> ProductTeas { get; set; }
        public DbSet<ProductTeaFlavor> ProductTeaFlavors { get; set; }
        public DbSet<ProductOther> ProductOthers { get; set; }
        public DbSet<Demension> Demensions { get; set; }
        public DbSet<ProductOtherDemension> ProductOtherDemensions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FlavorConfiguration());
            builder.ApplyConfiguration(new ProductTypeConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ProductImageConfiguration());
            builder.ApplyConfiguration(new ProductTeaConfiguration());
            builder.ApplyConfiguration(new ProductTeaFlavorConfiguration());
            builder.ApplyConfiguration(new ProductOtherConfiguration());
            builder.ApplyConfiguration(new DemensionConfiguration());
            builder.ApplyConfiguration(new ProductOtherDemensionConfiguration());
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CartDetailConfiguration());

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims").HasKey(x => x.Id);

        }
    }
}
