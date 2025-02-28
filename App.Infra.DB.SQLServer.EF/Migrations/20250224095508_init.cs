using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infra.DB.SQLServer.EF.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Experts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpertService",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertService", x => new { x.ExpertsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ExpertService_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Offers_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Customer", "CUSTOMER" },
                    { 3, null, "Expert", "EXPERT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "49533cdb-aeb8-452f-b2ac-64043551b8b3", "Reza@gmail.com", false, "Reza Ahmadi", false, null, "REZA@GMAIL.COM", "REZA@GMAIL.COM", "AQAAAAIAAYagAAAAEPTvt7crCAFK/Q8+kIs/BDz8NS4sXLVTXvDH6qqrVr8YoTfdezBEWgyK9fVQMwNFvA==", "09909169328", false, "025231bf-ced2-4d43-9b8b-54d97e9473ea", false, "Reza@gmail.com" },
                    { 2, 0, "49533cdb-aeb8-452f-b2ac-64043551b8b3", "Shahram@gmail.com", false, "Shahram Moradi", false, null, "SHAHRAM@GMAIL.COM", "SHAHRAM@GMAIL.COM", "AQAAAAIAAYagAAAAEPTvt7crCAFK/Q8+kIs/BDz8NS4sXLVTXvDH6qqrVr8YoTfdezBEWgyK9fVQMwNFvA==", "09909169329", false, "025231bf-ced2-4d43-9b8b-54d97e9473ea", false, "Shahram@gmail.com" },
                    { 3, 0, "49533cdb-aeb8-452f-b2ac-64043551b8b3", "Morad@gmail.com", false, "Morad Shahram", false, null, "MORAD@GMAIL.COM", "MORAD@GMAIL.COM", "AQAAAAIAAYagAAAAEPTvt7crCAFK/Q8+kIs/BDz8NS4sXLVTXvDH6qqrVr8YoTfdezBEWgyK9fVQMwNFvA==", "09909169327", false, "025231bf-ced2-4d43-9b8b-54d97e9473ea", false, "Morad@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImagePath", "IsDeleted", "Name", "TimeCreated" },
                values: new object[,]
                {
                    { 1, "\\Images\\Category\\cleaning.jpg", false, "تمیز کاری", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "\\Images\\Category\\building.jpg", false, "ساختمان", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "\\Images\\Category\\repair.jpg", false, "تعمیرات اشیا", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "\\Images\\Category\\Moving.jpg", false, "اسباب و حمل بار", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "\\Images\\Category\\Car.jpg", false, "خودرو", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "\\Images\\Category\\Beauty.jpg", false, "سلامت و زیبایی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "\\Images\\Category\\organiser.jpg", false, "سازمان ها مجتمع ها", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "\\Images\\Category\\Other.jpg", false, "سایر خدمات", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Titel" },
                values: new object[,]
                {
                    { 1, "آذربایجان شرقی" },
                    { 2, "آذربایجان غربی" },
                    { 3, "اردبیل" },
                    { 4, "اصفهان" },
                    { 5, "البرز" },
                    { 6, "ایلام" },
                    { 7, "بوشهر" },
                    { 8, "تهران" },
                    { 9, "چهارمحال و بختیاری" },
                    { 10, "خراسان جنوبی" },
                    { 11, "خراسان رضوی" },
                    { 12, "خراسان شمالی" },
                    { 13, "خوزستان" },
                    { 14, "زنجان" },
                    { 15, "سمنان" },
                    { 16, "سیستان و بلوچستان" },
                    { 17, "فارس" },
                    { 18, "قزوین" },
                    { 19, "قم" },
                    { 20, "کردستان" },
                    { 21, "کرمان" },
                    { 22, "کرمانشاه" },
                    { 23, "کهگیلویه و بویراحمد" },
                    { 24, "گلستان" },
                    { 25, "گیلان" },
                    { 26, "لرستان" },
                    { 27, "مازندران" },
                    { 28, "مرکزی" },
                    { 29, "هرمزگان" },
                    { 30, "همدان" },
                    { 31, "یزد" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Balance", "FirstName", "IsDeleted", "LastName", "TimeCreated", "UserId" },
                values: new object[] { 1, 0m, "reza", false, "ahmadi", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Balance", "FirstName", "Gender", "ImagePath", "IsDeleted", "LastName", "TimeCreated", "UserId" },
                values: new object[] { 1, 0m, "Shahram", 1, "/Images/Users/matin.jpg", false, "Moradi", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Balance", "CityId", "FirstName", "Gender", "ImagePath", "IsDeleted", "LastName", "Rating", "TimeCreated", "UserId" },
                values: new object[] { 1, 0m, null, "Morad", 1, "/Images/Users/matin.jpg", false, "Shahram", null, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "ImagePath", "IsDeleted", "Name", "TimeCreated" },
                values: new object[,]
                {
                    { 1, 1, "\\Images\\SubCategory\\1.jpg", false, "نظافت و پذیرایی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "\\Images\\SubCategory\\2.jpg", false, "شستشو", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "\\Images\\SubCategory\\3.jpg", false, "کارواش و دیتیلینگ", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "\\Images\\SubCategory\\4.jpg", false, "سرمایش و گرمایش", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "\\Images\\SubCategory\\5.jpg", false, "تعمیرات ساختمان", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, "\\Images\\SubCategory\\6.jpg", false, "لوله کشی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, "\\Images\\SubCategory\\7.jpg", false, "سرمایش و گرمایش", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, "\\Images\\SubCategory\\8.jpg", false, "نصب و تعمیر لوازم خانگی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 3, "\\Images\\SubCategory\\9.jpg", false, "خدمات کامپیوتریی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 4, "\\Images\\SubCategory\\10.jpg", false, "سباب‌کشی و حمل‌", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 5, "\\Images\\SubCategory\\11.jpg", false, "خدمات و تعمیرات خودرو", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, "\\Images\\SubCategory\\12.jpg", false, "زیبایی بانوان", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 6, "\\Images\\SubCategory\\13.jpg", false, "پزشکی و پرستاری", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 7, "\\Images\\SubCategory\\14.jpg", false, "خدمات شرکتی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 7, "\\Images\\SubCategory\\15.jpg", false, "تامین نیروی انسانی", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 8, "\\Images\\SubCategory\\16.jpg", false, "خیاطی و تعمیرات لباس", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 8, "\\   Images\\SubCategory\\17.jpg", false, "مجالس و رویدادها", new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "BasePrice", "ImagePath", "IsDeleted", "Name", "SubCategoryId", "TimeCreated" },
                values: new object[,]
                {
                    { 1, 500m, "\\Images\\Services\\1.jpg", false, "سرویس عادی نظافت", 1, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 500m, "\\Images\\Services\\2.jpg", false, "سرویس ویژه نظافت", 1, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 500m, "\\Images\\Services\\3.jpg", false, "قالیشویی", 2, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 500m, "\\Images\\Services\\4.jpg", false, "خشکشویی", 2, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 500m, "\\Images\\Services\\5.jpg", false, "سرامیک خودرو", 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 500m, "\\Images\\Services\\6.jpg", false, "صفرشویی خودرو", 3, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 500m, "\\Images\\Services\\7.jpg", false, "تعمیر و سرویس پکیج", 4, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 500m, "\\Images\\Services\\8.jpg", false, "تعمیر و سرویس آبگرمکن<", 4, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 500m, "\\Images\\Services\\9.jpg", false, "سنگ کاری", 5, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 500m, "\\Images\\Services\\10.jpg", false, "نقاشی ساختمان", 5, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 500m, "\\Images\\Services\\11.jpg", false, "نصب و تعمیر شیرآلات", 6, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 500m, "\\Images\\Services\\12.jpg", false, "تخلیه چاه و لوله بازکنی", 6, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 500m, "\\Images\\Services\\13.jpg", false, "تعمیر و سرویس پکیج", 7, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 500m, "\\Images\\Services\\14.jpg", false, "تعمیر و سرویس آبگرمکن", 7, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 500m, "\\Images\\Services\\15.jpg", false, "تعمیر کامپیوتر و لپ تاپ", 9, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 500m, "\\Images\\Services\\16.jpg", false, "مودم و اینترنت", 9, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 500m, "\\Images\\Services\\17.jpg", false, "نصب و تعمیر یخچال و فریزر", 8, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 500m, "\\Images\\Services\\18.jpg", false, "نصب و تعمیر ماشین لباسشویی", 8, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 500m, "\\Images\\Services\\19.jpg", false, "اسباب کشی با خاور و کامیون", 10, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 500m, "\\Images\\Services\\20.jpg", false, "اسباب کشی با وانت و نیسان", 10, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 500m, "\\Images\\Services\\21.jpg", false, "تعویض باتری خودرو", 11, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 500m, "\\Images\\Services\\22.jpg", false, "باتری به باتری", 11, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 500m, "\\Images\\Services\\23.jpg", false, "خدمات ناخن", 12, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 500m, "\\Images\\Services\\24.jpg", false, "رنگ مو بانوان", 12, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 500m, "\\Images\\Services\\25.jpg", false, "مراقبت و نگهداری", 10, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 500m, "\\Images\\Services\\26.jpg", false, "پرستاری و تزریقات", 10, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 500m, "\\Images\\Services\\27.jpg", false, "خدمات شرکتی (ویژه شرکت های کوچک و متوسط)", 14, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 500m, "\\Images\\Services\\28.jpg", false, "پیشنهاد فروش خدمات آچاره به شرکت ها", 14, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 500m, "\\Images\\Services\\29.jpg", false, "استخدام خدمتکار", 15, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 500m, "\\Images\\Services\\30.jpg", false, "تعمیرات لباس", 16, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 500m, "\\Images\\Services\\31.jpg", false, "دوخت لباس زنانه", 16, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 500m, "\\Images\\Services\\32.jpg", false, "کیک و شیرینی", 17, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 500m, "\\Images\\Services\\33.jpg", false, "ارسال هدیه", 17, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CityId", "CustomerId", "DateFor", "Description", "ExpertId", "IsDeleted", "ServiceId", "Status", "TimeCreated" },
                values: new object[] { 1, 1, 1, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "کاغذ دیواری خانه رو عوض کنید", null, false, 1, 1, new DateTime(2025, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

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
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_OfferId",
                table: "Comments",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_CityId",
                table: "Experts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_UserId",
                table: "Experts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpertService_ServicesId",
                table: "ExpertService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_OrderId",
                table: "Images",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ExpertId",
                table: "Offers",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OrderId",
                table: "Offers",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CityId",
                table: "Orders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExpertId",
                table: "Orders",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubCategoryId",
                table: "Services",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertService");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
