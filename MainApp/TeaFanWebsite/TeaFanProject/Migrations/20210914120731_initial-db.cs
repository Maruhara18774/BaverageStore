using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeaFanProject.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsTypeOfTea = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Demensions",
                columns: table => new
                {
                    DemensionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemensionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demensions", x => x.DemensionID);
                });

            migrationBuilder.CreateTable(
                name: "Flavors",
                columns: table => new
                {
                    FlavorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flavors", x => x.FlavorID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 14, 19, 7, 30, 994, DateTimeKind.Local).AddTicks(3927)),
                    ShippingPrice = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.TypeID);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    SalePrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDisable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "ProductTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    CartDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SoldPrice = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.CartDetailID);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOthers",
                columns: table => new
                {
                    ProductOtherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOthers", x => x.ProductOtherID);
                    table.ForeignKey(
                        name: "FK_ProductOthers_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTeas",
                columns: table => new
                {
                    ProductTeaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    WaterTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SteepTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTeas", x => x.ProductTeaID);
                    table.ForeignKey(
                        name: "FK_ProductTeas_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOtherDemensions",
                columns: table => new
                {
                    ProductOtherDemensionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOtherID = table.Column<int>(type: "int", nullable: false),
                    DemensionID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOtherDemensions", x => x.ProductOtherDemensionID);
                    table.ForeignKey(
                        name: "FK_ProductOtherDemensions_Demensions_DemensionID",
                        column: x => x.DemensionID,
                        principalTable: "Demensions",
                        principalColumn: "DemensionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOtherDemensions_ProductOthers_ProductOtherID",
                        column: x => x.ProductOtherID,
                        principalTable: "ProductOthers",
                        principalColumn: "ProductOtherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTeaFlavors",
                columns: table => new
                {
                    ProductTeaFlavorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlavorID = table.Column<int>(type: "int", nullable: false),
                    ProductTeaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTeaFlavors", x => x.ProductTeaFlavorID);
                    table.ForeignKey(
                        name: "FK_ProductTeaFlavors_Flavors_FlavorID",
                        column: x => x.FlavorID,
                        principalTable: "Flavors",
                        principalColumn: "FlavorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTeaFlavors_ProductTeas_ProductTeaID",
                        column: x => x.ProductTeaID,
                        principalTable: "ProductTeas",
                        principalColumn: "ProductTeaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "b4918041-4e12-4254-bd7e-3c29438c9772", "Admin", "ADMIN" },
                    { new Guid("54ba416f-6b89-4c53-873d-4fbd48506e6d"), "a854854e-c99e-43c0-84a4-d445fb88665b", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("170ca4bc-ef9f-4de7-ae96-08d962dad25f"), 0, "22 St. Wall Street, Brooklyn, American", "a76637cc-fb86-4457-829a-f5975998cd62", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "chungha@teafan.com", false, "Chung", "Ha", false, null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "chungha@teafan.com", "AQAAAAEAACcQAAAAEBpHiIM4leySeSwV5rSWCuRQyg3VTwUlYyHw+nnB2mYnfD5velQh38NVoZxs7bJPqw==", "012545454541", false, "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP", false, "chungha@teafan.com" },
                    { new Guid("61ae2038-97f2-45e5-91ae-08d961fa9be8"), 0, "22 St. Wall Street, Brooklyn, American", "1c6ef8b4-8a2c-48af-84d6-ba0b02df3260", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "annalee@teafan.com", false, "Anna", "Lee", false, null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "annalee@teafan.com", "AQAAAAEAACcQAAAAEMBztXMi6kpmZTII05aDAgFfJoobKGOnHOKYA5dbpxUikjew1q/8ogHWL/WgjuGu1A==", "012545454541", false, "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP", false, "annalee@teafan.com" },
                    { new Guid("0dd37c3c-4694-429e-623b-08d962dbded7"), 0, "22 St. Wall Street, Brooklyn, American", "56dd63a8-76a9-42e6-8fe2-a0eeb8bb1d59", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "quangdai@teafan.com", false, "Dai", "Quang", false, null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "quangdai@teafan.com", "AQAAAAEAACcQAAAAEFJHYZq/jKXsdqH4VGGg+XTEcmdfMKWynRaj44cWLK5agBNgyU+bif/0ZxKBb/MaMw==", "012545454541", false, "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP", false, "quangdai@teafan.com" },
                    { new Guid("50892ac9-ebe0-4c8d-f28e-08d9638e12dc"), 0, "22 St. Wall Street, Brooklyn, American", "b73ab2ef-db8e-45a3-9420-2b654eac9cd2", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "suongnhi@teafan.com", false, "Suong", "Nhi", false, null, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "suongnhi@teafan.com", "AQAAAAEAACcQAAAAELTyCCKzmWGQwWSd8PWmDTtnBU7fiuZB2F0GHlUJiVayvnhRmaVxP5OfdWC2Si3aBQ==", "012545454541", false, "NQLC7NG4A7DTOJ5DETPA35OHKTOZMMYP", false, "suongnhi@teafan.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "BrandName", "Origin" },
                values: new object[,]
                {
                    { 4, "Art of Tea", "Egypt" },
                    { 2, "Art of Tea", "India" },
                    { 5, "Art of Tea", "Japan" },
                    { 1, "Art of Tea", "China" },
                    { 3, "Art of Tea", "Taiwan" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "IsTypeOfTea" },
                values: new object[,]
                {
                    { 4, "Tea", false },
                    { 1, "Packaged", false },
                    { 2, "Teaware", false },
                    { 3, "Gift", false }
                });

            migrationBuilder.InsertData(
                table: "Demensions",
                columns: new[] { "DemensionID", "DemensionName" },
                values: new object[] { 1, "Capacity" });

            migrationBuilder.InsertData(
                table: "Flavors",
                columns: new[] { "FlavorID", "FlavorName" },
                values: new object[,]
                {
                    { 9, "Fresh" },
                    { 8, "Grassy" },
                    { 7, "Round" },
                    { 3, "Floral" },
                    { 5, "Spice" },
                    { 4, "Fruity" },
                    { 2, "Smooth" },
                    { 1, "Citrus" },
                    { 6, "Minty" },
                    { 10, "Sweet" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("50892ac9-ebe0-4c8d-f28e-08d9638e12dc") },
                    { new Guid("54ba416f-6b89-4c53-873d-4fbd48506e6d"), new Guid("170ca4bc-ef9f-4de7-ae96-08d962dad25f") },
                    { new Guid("54ba416f-6b89-4c53-873d-4fbd48506e6d"), new Guid("61ae2038-97f2-45e5-91ae-08d961fa9be8") },
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("0dd37c3c-4694-429e-623b-08d962dbded7") }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "TypeID", "CategoryID", "MyProperty", "TypeName" },
                values: new object[,]
                {
                    { 25, 3, 0, "Loose Leaf Teas" },
                    { 24, 3, 0, "Teaware" },
                    { 23, 3, 0, "Sampler Packs" },
                    { 22, 3, 0, "Ritual Collection" },
                    { 21, 3, 0, "Tea of the Month" },
                    { 20, 3, 0, "Tea Gifts" },
                    { 19, 2, 0, "Filter Bags" },
                    { 18, 2, 0, "Matcha" },
                    { 17, 2, 0, "Tea Gifts" },
                    { 16, 2, 0, "Iced Tea" },
                    { 15, 2, 0, "Ritual Collection" },
                    { 14, 2, 0, "Teaware" },
                    { 12, 1, 0, "Green Tea" },
                    { 11, 1, 0, "Caffeine Free" },
                    { 10, 1, 0, "Art of Tea Blends" },
                    { 9, 1, 0, "Organic Tea Blends" },
                    { 8, 1, 0, "Pyramid Sachets" },
                    { 7, 1, 0, "Packaged Tea Collection" },
                    { 6, 4, 0, "Tea Gifts" },
                    { 5, 4, 0, "Black Tea" },
                    { 4, 4, 0, "Green Tea" },
                    { 3, 4, 0, "Caffeine Free" },
                    { 2, 4, 0, "Organic Tea Blends" },
                    { 1, 4, 0, "Art of Tea Blends" },
                    { 13, 1, 0, "Black Tea" },
                    { 26, 4, 0, "Loose Leaf Teas" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "BrandID", "Description", "IsDisable", "Price", "ProductName", "Quantity", "SalePrice", "TypeID" },
                values: new object[,]
                {
                    { 7, 5, "Searching for sore throat tea or tea for throat you are on right place. Our Throat Therapy Tea designed to coat your throat and get you back on stage. Order it today!", false, 27.0, "Throat Therapy", 50, 27.0, 3 },
                    { 2, 5, "The same great Matcha blend in our Matchasticks is now available in a 40-gram Matcha tin! Perfect for at-home use. We are so excited to finally be offering this best selling Matcha blend in a new package just for you. \n New to our Ceremonial Grade Matcha blend? Our organic ceremonial grade matcha has been ground and packed at origin in Japan to lock in the ultimate freshness. A blend of 3 different green tea varietals, our Ceremonial Grade Matcha is delicious hot or cold brewed. \n This Matcha is 100% pure and it is delicious even when prepared with just filtered water! With light, refreshing, and smooth tasting notes, this Matcha blend is certain to delight all of your senses.", false, 50.0, "Art of Tea Ceremonial Grade Matcha Tin", 50, 45.0, 4 },
                    { 1, 5, "We've taken the guesswork out of measuring out the perfect pitcher of iced tea with convenient biodegradable iced tea pouches. Drop one bag into your 2 quart iced tea pitcher, fill with the appropriate amount of water and you're good to go! \n Blue Pineapple Tea \n Unique and delightful, our Blue Pineapple iced tea is the perfect summer sip. This tea brings together notes of lychee and citrus with organic lemongrass and sweet pineapple for a truly unforgettable cup of tea. For added fun, this breathtaking blend brews a deep blue color that undergoes a magical transformation with a squeeze of fresh citrus! \n Comes in packs of 4 pouches. \n Please note that the brewed color will range in various hues of blue/teal depending on your chosen steep time and temperature.", false, 11.0, "Blue Pineapple Tea", 50, 11.0, 9 },
                    { 5, 3, "A delectable medley with an enticing floral aroma. Rose Black combines loose leaf black tea with smooth notes of rose and a bright finish. Rose Black is delicious hot or cold brewed and poured over ice. The perfect sip for any time of day.", false, 21.0, "Rose Black Tea", 50, 21.0, 10 },
                    { 6, 3, "Endurance blend is comprised of adaptogenic herbs that are traditionally used for increasing stamina. This organic energy tea was developed to condition the body by neutralizing the harmful effects of free radicals, oxygenating the blood, promoting circulation, and increasing the body's overall resilience for a quicker recovery.", false, 28.0, "Endurance Tea (Pu-erh, Ashwaganda, + Oatstraw Tea)", 50, 28.0, 10 },
                    { 3, 5, "This hand-carved original cast iron teapot in the Northern Japan-style combines timeless craftsmanship with modern technology to ensure a long-lasting quality teapot. A beautiful insignia on the lower part of the teapot distinguishes the teapot's authenticity and superior quality.", false, 150.0, "Tetsubin Cast Iron Tea Pot", 50, 125.0, 14 },
                    { 4, 5, "Made by W/R/F Lab in Southern California, this handmade Ceramic Mug holds about 12oz of your tea of choice. The mug is handcrafted and hand-glazed with a modern color block design. Please note that every single mug is hand-produced in the W/R/F studio and is one-of-a-kind.", false, 32.0, "Ceramic Mug", 50, 32.0, 14 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageID", "ImageLink", "ProductID" },
                values: new object[,]
                {
                    { 19, "/Images/TP000/0.jpg", 7 },
                    { 11, "/Images/TP004/1.jpg", 4 },
                    { 10, "/Images/TP004/0.jpg", 4 },
                    { 9, "/Images/TP003/1.jpg", 3 },
                    { 8, "/Images/TP003/0.jpg", 3 },
                    { 18, "/Images/TP006/1.jpg", 6 },
                    { 17, "/Images/TP006/0.jpg", 6 },
                    { 16, "/Images/TP005/3.jpg", 5 },
                    { 15, "/Images/TP005/2.jpg", 5 },
                    { 12, "/Images/TP004/2.png", 4 },
                    { 13, "/Images/TP005/0.jpg", 5 },
                    { 14, "/Images/TP005/1.png", 5 },
                    { 2, "/Images/TP001/1.jpg", 1 },
                    { 1, "/Images/TP001/0.jpg", 1 },
                    { 7, "/Images/TP002/4.jpg", 2 },
                    { 6, "/Images/TP002/3.jpg", 2 },
                    { 5, "/Images/TP002/2.jpg", 2 },
                    { 4, "/Images/TP002/1.jpg", 2 },
                    { 3, "/Images/TP002/0.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductOthers",
                columns: new[] { "ProductOtherID", "CareInstruction", "Color", "Material", "ProductID" },
                values: new object[,]
                {
                    { 2, "Not suitable for stove top use Hand-wash only", "Black", "Cast Iron", 3 },
                    { 1, "Hand Wash", "Cream", "Ceramic", 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductTeas",
                columns: new[] { "ProductTeaID", "Ingredients", "ProductID", "ServingSize", "SteepTime", "WaterTemperature" },
                values: new object[,]
                {
                    { 2, "Organic Japanese Ceremonial Grade Matcha", 2, "1 Tsp", "20 Second Shake Or Whisk", "180" },
                    { 3, "Black Tea, Rose petals, Natural Flavors", 5, "1 Tsp/8oz", "3-5 Min", "206" },
                    { 4, "Organic Cinnamon, Organic Pu-erh, Organic Eleuthro Root, Organic Goji Berries, Organic Schizandra Berries, Organic Nettle Leaf, Organic Oatstraw, Organic Ashwaganda Root, Natural Flavors", 6, "1 Tsp/8oz", "3-5 Min", "195" },
                    { 5, "Organic Ginger, Organic Peppermint, Organic Licorice, Organic Orange Peel, Organic Fennel, Organic Marshmallow Leaf, Organic Clove, Organic Echinacea", 7, "1 Tbsp/8 Oz", "5-7 Min", "206" },
                    { 1, "Organic Lemongrass, Ginger, Oolong Tea, Pineapple Bits, Blue Butterfly Pea, Stevia Leaf, Natural flavors", 1, "1 Pouch/2 QT", "4-5 Min", "185-206" }
                });

            migrationBuilder.InsertData(
                table: "ProductOtherDemensions",
                columns: new[] { "ProductOtherDemensionID", "DemensionID", "ProductOtherID", "Unit", "Value" },
                values: new object[,]
                {
                    { 2, 1, 2, "oz", 16.0 },
                    { 1, 1, 1, "oz", 12.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductTeaFlavors",
                columns: new[] { "ProductTeaFlavorID", "FlavorID", "ProductTeaID" },
                values: new object[,]
                {
                    { 11, 1, 5 },
                    { 1, 2, 5 },
                    { 2, 6, 5 },
                    { 5, 2, 2 },
                    { 6, 9, 2 },
                    { 3, 1, 1 },
                    { 4, 4, 1 },
                    { 7, 2, 3 },
                    { 8, 3, 3 },
                    { 9, 4, 4 },
                    { 10, 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_CartID",
                table: "CartDetails",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserID",
                table: "Carts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOtherDemensions_DemensionID",
                table: "ProductOtherDemensions",
                column: "DemensionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOtherDemensions_ProductOtherID",
                table: "ProductOtherDemensions",
                column: "ProductOtherID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOthers_ProductID",
                table: "ProductOthers",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandID",
                table: "Products",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeID",
                table: "Products",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTeaFlavors_FlavorID",
                table: "ProductTeaFlavors",
                column: "FlavorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTeaFlavors_ProductTeaID",
                table: "ProductTeaFlavors",
                column: "ProductTeaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTeas_ProductID",
                table: "ProductTeas",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_CategoryID",
                table: "ProductTypes",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductID",
                table: "Ratings",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserID",
                table: "Ratings",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductOtherDemensions");

            migrationBuilder.DropTable(
                name: "ProductTeaFlavors");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Demensions");

            migrationBuilder.DropTable(
                name: "ProductOthers");

            migrationBuilder.DropTable(
                name: "Flavors");

            migrationBuilder.DropTable(
                name: "ProductTeas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
