using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaFanProject.Entities;

namespace TeaFanProject.Data
{
    public static class ModalSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = new Guid("61AE2038-97F2-45E5-91AE-08D961FA9BE8"),
                    Email = "annalee@teafan.com",
                    UserName = "annalee@teafan.com",
                    NormalizedUserName = "annalee@teafan.com",
                    PhoneNumber = "012545454541",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    FirstName = "Anna",
                    LastName = "Lee",
                    CreatedDate = new DateTime(2021, 2, 2),
                    ModifiedDate = new DateTime(2021, 2, 2),
                    Address = "22 St. Wall Street, Brooklyn, American",
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                },
                new User()
                {
                    Id = new Guid("170CA4BC-EF9F-4DE7-AE96-08D962DAD25F"),
                    Email = "chungha@teafan.com",
                    UserName = "chungha@teafan.com",
                    NormalizedUserName = "chungha@teafan.com",
                    PhoneNumber = "012545454541",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    FirstName = "Chung",
                    LastName = "Ha",
                    CreatedDate = new DateTime(2021, 2, 2),
                    ModifiedDate = new DateTime(2021, 2, 2),
                    Address = "22 St. Wall Street, Brooklyn, American",
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                },
                new User()
                {
                    Id = new Guid("0DD37C3C-4694-429E-623B-08D962DBDED7"),
                    Email = "quangdai@teafan.com",
                    UserName = "quangdai@teafan.com",
                    NormalizedUserName = "quangdai@teafan.com",
                    PhoneNumber = "012545454541",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    FirstName = "Dai",
                    LastName = "Quang",
                    CreatedDate = new DateTime(2021, 2, 2),
                    ModifiedDate = new DateTime(2021, 2, 2),
                    Address = "22 St. Wall Street, Brooklyn, American",
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                },
                new User()
                {
                    Id = new Guid("50892AC9-EBE0-4C8D-F28E-08D9638E12DC"),
                    Email = "suongnhi@teafan.com",
                    UserName = "suongnhi@teafan.com",
                    NormalizedUserName = "suongnhi@teafan.com",
                    PhoneNumber = "012545454541",
                    PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                    FirstName = "Suong",
                    LastName = "Nhi",
                    CreatedDate = new DateTime(2021, 2, 2),
                    ModifiedDate = new DateTime(2021, 2, 2),
                    Address = "22 St. Wall Street, Brooklyn, American",
                    SecurityStamp = "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP"
                }
             );


            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("54BA416F-6B89-4C53-873D-4FBD48506E6D"),
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                });


            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("61AE2038-97F2-45E5-91AE-08D961FA9BE8"),
                    RoleId = new Guid("54BA416F-6B89-4C53-873D-4FBD48506E6D"),
                },
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("170CA4BC-EF9F-4DE7-AE96-08D962DAD25F"),
                    RoleId = new Guid("54BA416F-6B89-4C53-873D-4FBD48506E6D"),
                },
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("0DD37C3C-4694-429E-623B-08D962DBDED7"),
                    RoleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                },
                new IdentityUserRole<Guid>
                {
                    UserId = new Guid("50892AC9-EBE0-4C8D-F28E-08D9638E12DC"),
                    RoleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                }
                );


            modelBuilder.Entity<Flavor>().HasData(
                new Flavor()
                {
                    FlavorID = 0,
                    FlavorName = "Sweet"
                },
                new Flavor()
                {
                    FlavorID = 1,
                    FlavorName = "Citrus"
                },
                new Flavor()
                {
                    FlavorID = 2,
                    FlavorName = "Smooth"
                },
                new Flavor()
                {
                    FlavorID = 3,
                    FlavorName = "Floral"
                },
                new Flavor()
                {
                    FlavorID = 4,
                    FlavorName = "Fruity"
                },
                new Flavor()
                {
                    FlavorID = 5,
                    FlavorName = "Spice"
                },
                new Flavor()
                {
                    FlavorID = 6,
                    FlavorName = "Minty"
                },
                new Flavor()
                {
                    FlavorID = 7,
                    FlavorName = "Round"
                },
                new Flavor()
                {
                    FlavorID = 8,
                    FlavorName = "Grassy"
                },
                new Flavor()
                {
                    FlavorID = 9,
                    FlavorName = "Fresh"
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryID = 0,
                    CategoryName = "Tea"
                },
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Packaged"
                },
                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Teaware"
                },
                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Gift"
                }
                );

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType()
                {
                    TypeID = 0,
                    TypeName = "Loose Leaf Teas",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 1,
                    TypeName = "Art of Tea Blends",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 2,
                    TypeName = "Organic Tea Blends",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 3,
                    TypeName = "Caffeine Free",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 4,
                    TypeName = "Green Tea",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 5,
                    TypeName = "Black Tea",
                    CategoryID = 0
                },
                new ProductType()
                {
                    TypeID = 6,
                    TypeName = "Tea Gifts",
                    CategoryID = 0
                }, 
                new ProductType()
                {
                    TypeID = 7,
                    TypeName = "Packaged Tea Collection",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 8,
                    TypeName = "Pyramid Sachets",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 9,
                    TypeName = "Organic Tea Blends",
                    CategoryID = 1
                }, 
                new ProductType()
                {
                    TypeID = 10,
                    TypeName = "Art of Tea Blends",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 11,
                    TypeName = "Caffeine Free",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 12,
                    TypeName = "Green Tea",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 13,
                    TypeName = "Black Tea",
                    CategoryID = 1
                },
                new ProductType()
                {
                    TypeID = 14,
                    TypeName = "Teaware",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 15,
                    TypeName = "Ritual Collection",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 16,
                    TypeName = "Iced Tea",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 17,
                    TypeName = "Tea Gifts",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 18,
                    TypeName = "Matcha",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 19,
                    TypeName = "Filter Bags",
                    CategoryID = 2
                },
                new ProductType()
                {
                    TypeID = 20,
                    TypeName = "Tea Gifts",
                    CategoryID = 3
                },
                new ProductType()
                {
                    TypeID = 21,
                    TypeName = "Tea of the Month",
                    CategoryID = 3
                },
                new ProductType()
                {
                    TypeID = 22,
                    TypeName = "Ritual Collection",
                    CategoryID = 3
                },
                new ProductType()
                {
                    TypeID = 23,
                    TypeName = "Sampler Packs",
                    CategoryID = 3
                },
                new ProductType()
                {
                    TypeID = 24,
                    TypeName = "Teaware",
                    CategoryID = 3
                },
                new ProductType()
                {
                    TypeID = 25,
                    TypeName = "Loose Leaf Teas",
                    CategoryID = 3
                }
                );

            modelBuilder.Entity<Brand>().HasData(
                new Brand()
                {
                    BrandID = 0,
                    BrandName = "Art of Tea",
                    Origin = "Japan"
                },
                new Brand()
                {
                    BrandID = 1,
                    BrandName = "Art of Tea",
                    Origin = "China"
                },
                new Brand()
                {
                    BrandID = 2,
                    BrandName = "Art of Tea",
                    Origin = "India"
                },
                new Brand()
                {
                    BrandID = 3,
                    BrandName = "Art of Tea",
                    Origin = "Taiwan"
                },
                new Brand()
                {
                    BrandID = 4,
                    BrandName = "Art of Tea",
                    Origin = "Egypt"
                }
                );
        }
    }
}
