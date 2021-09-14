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
                    FlavorID = 10,
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
                    CategoryID = 4,
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
                    TypeID = 26,
                    TypeName = "Loose Leaf Teas",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 1,
                    TypeName = "Art of Tea Blends",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 2,
                    TypeName = "Organic Tea Blends",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 3,
                    TypeName = "Caffeine Free",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 4,
                    TypeName = "Green Tea",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 5,
                    TypeName = "Black Tea",
                    CategoryID = 4
                },
                new ProductType()
                {
                    TypeID = 6,
                    TypeName = "Tea Gifts",
                    CategoryID = 4
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
                    BrandID = 5,
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


            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductID = 7,
                    TypeID = 3,
                    ProductName = "Throat Therapy",
                    Price = 27,
                    SalePrice = 27,
                    BrandID = 5,
                    Quantity = 50,
                    Description = "Searching for sore throat tea or tea for throat you are on right place. Our Throat Therapy Tea designed to coat your throat and get you back on stage. Order it today!"
                },
                new Product()
                {
                    ProductID = 1,
                    TypeID = 9,
                    ProductName = "Blue Pineapple Tea",
                    Price = 11,
                    SalePrice = 11,
                    BrandID = 5,
                    Quantity = 50,
                    Description = "We've taken the guesswork out of measuring out the perfect pitcher of iced tea with convenient biodegradable iced tea pouches. Drop one bag into your 2 quart iced tea pitcher, fill with the appropriate amount of water and you're good to go! \n Blue Pineapple Tea \n Unique and delightful, our Blue Pineapple iced tea is the perfect summer sip. This tea brings together notes of lychee and citrus with organic lemongrass and sweet pineapple for a truly unforgettable cup of tea. For added fun, this breathtaking blend brews a deep blue color that undergoes a magical transformation with a squeeze of fresh citrus! \n Comes in packs of 4 pouches. \n Please note that the brewed color will range in various hues of blue/teal depending on your chosen steep time and temperature."
                },
                new Product()
                {
                    ProductID = 2,
                    TypeID = 4,
                    ProductName = "Art of Tea Ceremonial Grade Matcha Tin",
                    Price = 50,
                    SalePrice = 45,
                    BrandID = 5,
                    Quantity = 50,
                    Description = "The same great Matcha blend in our Matchasticks is now available in a 40-gram Matcha tin! Perfect for at-home use. We are so excited to finally be offering this best selling Matcha blend in a new package just for you. \n New to our Ceremonial Grade Matcha blend? Our organic ceremonial grade matcha has been ground and packed at origin in Japan to lock in the ultimate freshness. A blend of 3 different green tea varietals, our Ceremonial Grade Matcha is delicious hot or cold brewed. \n This Matcha is 100% pure and it is delicious even when prepared with just filtered water! With light, refreshing, and smooth tasting notes, this Matcha blend is certain to delight all of your senses."
                },
                new Product()
                {
                    ProductID = 3,
                    TypeID = 14,
                    ProductName = "Tetsubin Cast Iron Tea Pot",
                    Price = 150,
                    SalePrice = 125,
                    BrandID = 5,
                    Quantity = 50,
                    Description = "This hand-carved original cast iron teapot in the Northern Japan-style combines timeless craftsmanship with modern technology to ensure a long-lasting quality teapot. A beautiful insignia on the lower part of the teapot distinguishes the teapot's authenticity and superior quality."
                },
                new Product()
                {
                    ProductID = 4,
                    TypeID = 14,
                    ProductName = "Ceramic Mug",
                    Price = 32,
                    SalePrice = 32,
                    BrandID = 5,
                    Quantity = 50,
                    Description = "Made by W/R/F Lab in Southern California, this handmade Ceramic Mug holds about 12oz of your tea of choice. The mug is handcrafted and hand-glazed with a modern color block design. Please note that every single mug is hand-produced in the W/R/F studio and is one-of-a-kind."
                },
                new Product()
                {
                    ProductID = 5,
                    TypeID = 10,
                    ProductName = "Rose Black Tea",
                    Price = 21,
                    SalePrice = 21,
                    BrandID = 3,
                    Quantity = 50,
                    Description = "A delectable medley with an enticing floral aroma. Rose Black combines loose leaf black tea with smooth notes of rose and a bright finish. Rose Black is delicious hot or cold brewed and poured over ice. The perfect sip for any time of day."
                },
                new Product()
                {
                    ProductID = 6,
                    TypeID = 10,
                    ProductName = "Endurance Tea (Pu-erh, Ashwaganda, + Oatstraw Tea)",
                    Price = 28,
                    SalePrice = 28,
                    BrandID = 3,
                    Quantity = 50,
                    Description = "Endurance blend is comprised of adaptogenic herbs that are traditionally used for increasing stamina. This organic energy tea was developed to condition the body by neutralizing the harmful effects of free radicals, oxygenating the blood, promoting circulation, and increasing the body's overall resilience for a quicker recovery."
                }
                );
            modelBuilder.Entity<ProductTea>().HasData(
                new ProductTea()
                {
                    ProductTeaID = 5,
                    ProductID = 7,
                    WaterTemperature = "206",
                    SteepTime = "5-7 Min",
                    ServingSize = "1 Tbsp/8 Oz",
                    Ingredients = "Organic Ginger, Organic Peppermint, Organic Licorice, Organic Orange Peel, Organic Fennel, Organic Marshmallow Leaf, Organic Clove, Organic Echinacea"
                },
                new ProductTea()
                {
                    ProductTeaID = 1,
                    ProductID = 1,
                    WaterTemperature = "185-206",
                    SteepTime = "4-5 Min",
                    ServingSize = "1 Pouch/2 QT",
                    Ingredients = "Organic Lemongrass, Ginger, Oolong Tea, Pineapple Bits, Blue Butterfly Pea, Stevia Leaf, Natural flavors"
                },
                new ProductTea()
                {
                    ProductTeaID = 2,
                    ProductID = 2,
                    WaterTemperature = "180",
                    SteepTime = "20 Second Shake Or Whisk",
                    ServingSize = "1 Tsp",
                    Ingredients = "Organic Japanese Ceremonial Grade Matcha"
                },
                new ProductTea()
                {
                    ProductTeaID = 3,
                    ProductID = 5,
                    WaterTemperature = "206",
                    SteepTime = "3-5 Min",
                    ServingSize = "1 Tsp/8oz",
                    Ingredients = "Black Tea, Rose petals, Natural Flavors"
                },
                new ProductTea()
                {
                    ProductTeaID = 4,
                    ProductID = 6,
                    WaterTemperature = "195",
                    SteepTime = "3-5 Min",
                    ServingSize = "1 Tsp/8oz",
                    Ingredients = "Organic Cinnamon, Organic Pu-erh, Organic Eleuthro Root, Organic Goji Berries, Organic Schizandra Berries, Organic Nettle Leaf, Organic Oatstraw, Organic Ashwaganda Root, Natural Flavors"
                }
            );

            modelBuilder.Entity<ProductTeaFlavor>().HasData(
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 11,
                    FlavorID = 1,
                    ProductTeaID = 5
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 1,
                    FlavorID = 2,
                    ProductTeaID = 5
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 2,
                    FlavorID = 6,
                    ProductTeaID = 5
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 3,
                    FlavorID = 1,
                    ProductTeaID = 1
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 4,
                    FlavorID = 4,
                    ProductTeaID = 1
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 5,
                    FlavorID = 2,
                    ProductTeaID = 2
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 6,
                    FlavorID = 9,
                    ProductTeaID = 2
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 7,
                    FlavorID = 2,
                    ProductTeaID = 3
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 8,
                    FlavorID = 3,
                    ProductTeaID = 3
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 9,
                    FlavorID = 4,
                    ProductTeaID = 4
                },
                new ProductTeaFlavor()
                {
                    ProductTeaFlavorID = 10,
                    FlavorID = 7,
                    ProductTeaID = 4
                }
                );
            modelBuilder.Entity<ProductOther>().HasData(
                new ProductOther()
                {
                    ProductOtherID = 2,
                    ProductID = 3,
                    Material = "Cast Iron",
                    Color = "Black",
                    CareInstruction = "Not suitable for stove top use Hand-wash only"
                },
                new ProductOther()
                {
                    ProductOtherID = 1,
                    ProductID = 4,
                    Material = "Ceramic",
                    Color = "Cream",
                    CareInstruction = "Hand Wash"
                }
                );

            modelBuilder.Entity<Demension>().HasData(
                new Demension()
                {
                    DemensionID = 1,
                    DemensionName = "Capacity"
                }
                );

            modelBuilder.Entity<ProductOtherDemension>().HasData(
                new ProductOtherDemension()
                {
                    ProductOtherDemensionID = 2,
                    ProductOtherID = 2,
                    DemensionID = 1,
                    Value = 16,
                    Unit = "oz"
                },
                new ProductOtherDemension()
                {
                    ProductOtherDemensionID = 1,
                    ProductOtherID = 1,
                    DemensionID = 1,
                    Value = 12,
                    Unit = "oz"
                }
                );
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage()
                {
                    ImageID =19,
                    ProductID = 7,
                    ImageLink = "/Images/TP000/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 1,
                    ProductID = 1,
                    ImageLink = "/Images/TP001/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 2,
                    ProductID = 1,
                    ImageLink = "/Images/TP001/1.jpg"
                },
                new ProductImage()
                {
                    ImageID = 3,
                    ProductID = 2,
                    ImageLink = "/Images/TP002/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 4,
                    ProductID = 2,
                    ImageLink = "/Images/TP002/1.jpg"
                },
                new ProductImage()
                {
                    ImageID = 5,
                    ProductID = 2,
                    ImageLink = "/Images/TP002/2.jpg"
                },
                new ProductImage()
                {
                    ImageID = 6,
                    ProductID = 2,
                    ImageLink = "/Images/TP002/3.jpg"
                },
                new ProductImage()
                {
                    ImageID = 7,
                    ProductID = 2,
                    ImageLink = "/Images/TP002/4.jpg"
                },
                new ProductImage()
                {
                    ImageID = 8,
                    ProductID = 3,
                    ImageLink = "/Images/TP003/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 9,
                    ProductID = 3,
                    ImageLink = "/Images/TP003/1.jpg"
                },
                new ProductImage()
                {
                    ImageID = 10,
                    ProductID = 4,
                    ImageLink = "/Images/TP004/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 11,
                    ProductID = 4,
                    ImageLink = "/Images/TP004/1.jpg"
                },
                new ProductImage()
                {
                    ImageID = 12,
                    ProductID = 4,
                    ImageLink = "/Images/TP004/2.png"
                },
                new ProductImage()
                {
                    ImageID = 13,
                    ProductID = 5,
                    ImageLink = "/Images/TP005/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 14,
                    ProductID = 5,
                    ImageLink = "/Images/TP005/1.png"
                },
                new ProductImage()
                {
                    ImageID = 15,
                    ProductID = 5,
                    ImageLink = "/Images/TP005/2.jpg"
                },
                new ProductImage()
                {
                    ImageID = 16,
                    ProductID = 5,
                    ImageLink = "/Images/TP005/3.jpg"
                },
                new ProductImage()
                {
                    ImageID = 17,
                    ProductID = 6,
                    ImageLink = "/Images/TP006/0.jpg"
                },
                new ProductImage()
                {
                    ImageID = 18,
                    ProductID = 6,
                    ImageLink = "/Images/TP006/1.jpg"
                }
                );
        }
    }
}
