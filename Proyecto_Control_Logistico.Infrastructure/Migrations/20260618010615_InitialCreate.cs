using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Control_Logistico.Infrastructure.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Proyecto_Control_Logistico.Infrastructure/Migrations/20260618010615_InitialCreate.cs
    public partial class InitialCreate : Migration
========
    public partial class Addfirstmigratge : Migration
>>>>>>>> 6c3c5c58eb8089af8634ed5d2c4686062a0fc995:Proyecto_Control_Logistico.Infrastructure/Migrations/20260625024853_Addfirstmigratge.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PriceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceSell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitMeasure = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberSale = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOrder = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    StockAvailable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventaries_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventaries_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementInventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MovementType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockAvailable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Motive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetails_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bicycles and related equipment", "Bikes", null },
                    { 2, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike components and parts", "Components", null },
                    { 3, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apparel and accessories", "Clothing", null },
                    { 4, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike accessories and gear", "Accessories", null },
                    { 5, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational and reference materials", "Books", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CategoryId", "Code", "CreatedAt", "Description", "Name", "PriceCost", "PriceSell", "Stock", "UnitMeasure", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, 2, "FR-R92B-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Black, 58", "HL Road Frame - Black, 58", 1059.31m, 1431.5m, 375m, "U", null },
                    { 2, true, 2, "FR-R92R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 58", "HL Road Frame - Red, 58", 1059.31m, 1431.5m, 375m, "U", null },
                    { 3, true, 4, "HL-U509-R", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport-100 Helmet, Red", "Sport-100 Helmet, Red", 13.0863m, 34.99m, 3m, "U", null },
                    { 4, true, 4, "HL-U509", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport-100 Helmet, Black", "Sport-100 Helmet, Black", 13.0863m, 34.99m, 3m, "U", null },
                    { 5, true, 3, "SO-B909-M", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Bike Socks, M", "Mountain Bike Socks, M", 3.3963m, 9.5m, 3m, "U", null },
                    { 6, true, 3, "SO-B909-L", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Bike Socks, L", "Mountain Bike Socks, L", 3.3963m, 9.5m, 3m, "U", null },
                    { 7, true, 4, "HL-U509-B", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport-100 Helmet, Blue", "Sport-100 Helmet, Blue", 13.0863m, 34.99m, 3m, "U", null },
                    { 8, true, 3, "CA-1098", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "AWC Logo Cap", "AWC Logo Cap", 6.9223m, 8.99m, 3m, "U", null },
                    { 9, true, 3, "LJ-0192-S", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long-Sleeve Logo Jersey, S", "Long-Sleeve Logo Jersey, S", 38.4923m, 49.99m, 3m, "U", null },
                    { 10, true, 3, "LJ-0192-M", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long-Sleeve Logo Jersey, M", "Long-Sleeve Logo Jersey, M", 38.4923m, 49.99m, 3m, "U", null },
                    { 11, true, 3, "LJ-0192-L", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long-Sleeve Logo Jersey, L", "Long-Sleeve Logo Jersey, L", 38.4923m, 49.99m, 3m, "U", null },
                    { 12, true, 3, "LJ-0192-X", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Long-Sleeve Logo Jersey, XL", "Long-Sleeve Logo Jersey, XL", 38.4923m, 49.99m, 3m, "U", null },
                    { 13, true, 2, "FR-R92R-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 62", "HL Road Frame - Red, 62", 868.6342m, 1431.5m, 375m, "U", null },
                    { 14, true, 2, "FR-R92R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 44", "HL Road Frame - Red, 44", 868.6342m, 1431.5m, 375m, "U", null },
                    { 15, true, 2, "FR-R92R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 48", "HL Road Frame - Red, 48", 868.6342m, 1431.5m, 375m, "U", null },
                    { 16, true, 2, "FR-R92R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 52", "HL Road Frame - Red, 52", 868.6342m, 1431.5m, 375m, "U", null },
                    { 17, true, 2, "FR-R92R-56", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Road Frame - Red, 56", "HL Road Frame - Red, 56", 868.6342m, 1431.5m, 375m, "U", null },
                    { 18, true, 2, "FR-R38B-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 58", "LL Road Frame - Black, 58", 204.6251m, 337.22m, 375m, "U", null },
                    { 19, true, 2, "FR-R38B-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 60", "LL Road Frame - Black, 60", 204.6251m, 337.22m, 375m, "U", null },
                    { 20, true, 2, "FR-R38B-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 62", "LL Road Frame - Black, 62", 204.6251m, 337.22m, 375m, "U", null },
                    { 21, true, 2, "FR-R38R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 44", "LL Road Frame - Red, 44", 187.1571m, 337.22m, 375m, "U", null },
                    { 22, true, 2, "FR-R38R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 48", "LL Road Frame - Red, 48", 187.1571m, 337.22m, 375m, "U", null },
                    { 23, true, 2, "FR-R38R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 52", "LL Road Frame - Red, 52", 187.1571m, 337.22m, 375m, "U", null },
                    { 24, true, 2, "FR-R38R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 58", "LL Road Frame - Red, 58", 187.1571m, 337.22m, 375m, "U", null },
                    { 25, true, 2, "FR-R38R-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 60", "LL Road Frame - Red, 60", 187.1571m, 337.22m, 375m, "U", null },
                    { 26, true, 2, "FR-R38R-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Red, 62", "LL Road Frame - Red, 62", 187.1571m, 337.22m, 375m, "U", null },
                    { 27, true, 2, "FR-R72R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Road Frame - Red, 44", "ML Road Frame - Red, 44", 352.1394m, 594.83m, 375m, "U", null },
                    { 28, true, 2, "FR-R72R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Road Frame - Red, 48", "ML Road Frame - Red, 48", 352.1394m, 594.83m, 375m, "U", null },
                    { 29, true, 2, "FR-R72R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Road Frame - Red, 52", "ML Road Frame - Red, 52", 352.1394m, 594.83m, 375m, "U", null },
                    { 30, true, 2, "FR-R72R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Road Frame - Red, 58", "ML Road Frame - Red, 58", 352.1394m, 594.83m, 375m, "U", null },
                    { 31, true, 2, "FR-R72R-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Road Frame - Red, 60", "ML Road Frame - Red, 60", 352.1394m, 594.83m, 375m, "U", null },
                    { 32, true, 2, "FR-R38B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 44", "LL Road Frame - Black, 44", 204.6251m, 337.22m, 375m, "U", null },
                    { 33, true, 2, "FR-R38B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 48", "LL Road Frame - Black, 48", 204.6251m, 337.22m, 375m, "U", null },
                    { 34, true, 2, "FR-R38B-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Road Frame - Black, 52", "LL Road Frame - Black, 52", 204.6251m, 337.22m, 375m, "U", null },
                    { 35, true, 2, "FR-M94S-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Silver, 42", "HL Mountain Frame - Silver, 42", 747.2002m, 1364.5m, 375m, "U", null },
                    { 36, true, 2, "FR-M94S-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Silver, 44", "HL Mountain Frame - Silver, 44", 706.811m, 1364.5m, 375m, "U", null },
                    { 37, true, 2, "FR-M94S-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Silver, 48", "HL Mountain Frame - Silver, 48", 706.811m, 1364.5m, 375m, "U", null },
                    { 38, true, 2, "FR-M94S-46", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Silver, 46", "HL Mountain Frame - Silver, 46", 747.2002m, 1364.5m, 375m, "U", null },
                    { 39, true, 2, "FR-M94B-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Black, 42", "HL Mountain Frame - Black, 42", 739.041m, 1349.6m, 375m, "U", null },
                    { 40, true, 2, "FR-M94B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Black, 44", "HL Mountain Frame - Black, 44", 699.0928m, 1349.6m, 375m, "U", null },
                    { 41, true, 2, "FR-M94B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Black, 48", "HL Mountain Frame - Black, 48", 699.0928m, 1349.6m, 375m, "U", null },
                    { 42, true, 2, "FR-M94B-46", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Black, 46", "HL Mountain Frame - Black, 46", 739.041m, 1349.6m, 375m, "U", null },
                    { 43, true, 2, "FR-M94B-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Black, 38", "HL Mountain Frame - Black, 38", 739.041m, 1349.6m, 375m, "U", null },
                    { 44, true, 2, "FR-M94S-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Mountain Frame - Silver, 38", "HL Mountain Frame - Silver, 38", 747.2002m, 1364.5m, 375m, "U", null },
                    { 45, true, 1, "BK-R93R-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-150 Red, 62", "Road-150 Red, 62", 2171.2942m, 3578.27m, 75m, "U", null },
                    { 46, true, 1, "BK-R93R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-150 Red, 44", "Road-150 Red, 44", 2171.2942m, 3578.27m, 75m, "U", null },
                    { 47, true, 1, "BK-R93R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-150 Red, 48", "Road-150 Red, 48", 2171.2942m, 3578.27m, 75m, "U", null },
                    { 48, true, 1, "BK-R93R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-150 Red, 52", "Road-150 Red, 52", 2171.2942m, 3578.27m, 75m, "U", null },
                    { 49, true, 1, "BK-R93R-56", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-150 Red, 56", "Road-150 Red, 56", 2171.2942m, 3578.27m, 75m, "U", null },
                    { 50, true, 1, "BK-R68R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-450 Red, 58", "Road-450 Red, 58", 884.7083m, 1457.99m, 75m, "U", null },
                    { 51, true, 1, "BK-R68R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-450 Red, 44", "Road-450 Red, 44", 884.7083m, 1457.99m, 75m, "U", null },
                    { 52, true, 1, "BK-R68R-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-450 Red, 60", "Road-450 Red, 60", 884.7083m, 1457.99m, 75m, "U", null },
                    { 53, true, 1, "BK-R68R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-450 Red, 48", "Road-450 Red, 48", 884.7083m, 1457.99m, 75m, "U", null },
                    { 54, true, 1, "BK-R68R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-450 Red, 52", "Road-450 Red, 52", 884.7083m, 1457.99m, 75m, "U", null },
                    { 55, true, 1, "BK-R50R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 58", "Road-650 Red, 58", 486.7066m, 782.99m, 75m, "U", null },
                    { 56, true, 1, "BK-R50R-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 60", "Road-650 Red, 60", 486.7066m, 782.99m, 75m, "U", null },
                    { 57, true, 1, "BK-R50R-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 62", "Road-650 Red, 62", 486.7066m, 782.99m, 75m, "U", null },
                    { 58, true, 1, "BK-R50R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 44", "Road-650 Red, 44", 486.7066m, 782.99m, 75m, "U", null },
                    { 59, true, 1, "BK-R50R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 48", "Road-650 Red, 48", 486.7066m, 782.99m, 75m, "U", null },
                    { 60, true, 1, "BK-R50R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Red, 52", "Road-650 Red, 52", 486.7066m, 782.99m, 75m, "U", null },
                    { 61, true, 1, "BK-R50B-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 58", "Road-650 Black, 58", 486.7066m, 782.99m, 75m, "U", null },
                    { 62, true, 1, "BK-R50B-60", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 60", "Road-650 Black, 60", 486.7066m, 782.99m, 75m, "U", null },
                    { 63, true, 1, "BK-R50B-62", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 62", "Road-650 Black, 62", 486.7066m, 782.99m, 75m, "U", null },
                    { 64, true, 1, "BK-R50B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 44", "Road-650 Black, 44", 486.7066m, 782.99m, 75m, "U", null },
                    { 65, true, 1, "BK-R50B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 48", "Road-650 Black, 48", 486.7066m, 782.99m, 75m, "U", null },
                    { 66, true, 1, "BK-R50B-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-650 Black, 52", "Road-650 Black, 52", 486.7066m, 782.99m, 75m, "U", null },
                    { 67, true, 1, "BK-M82S-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Silver, 38", "Mountain-100 Silver, 38", 1912.1544m, 3399.99m, 75m, "U", null },
                    { 68, true, 1, "BK-M82S-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Silver, 42", "Mountain-100 Silver, 42", 1912.1544m, 3399.99m, 75m, "U", null },
                    { 69, true, 1, "BK-M82S-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Silver, 44", "Mountain-100 Silver, 44", 1912.1544m, 3399.99m, 75m, "U", null },
                    { 70, true, 1, "BK-M82S-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Silver, 48", "Mountain-100 Silver, 48", 1912.1544m, 3399.99m, 75m, "U", null },
                    { 71, true, 1, "BK-M82B-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Black, 38", "Mountain-100 Black, 38", 1898.0944m, 3374.99m, 75m, "U", null },
                    { 72, true, 1, "BK-M82B-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Black, 42", "Mountain-100 Black, 42", 1898.0944m, 3374.99m, 75m, "U", null },
                    { 73, true, 1, "BK-M82B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Black, 44", "Mountain-100 Black, 44", 1898.0944m, 3374.99m, 75m, "U", null },
                    { 74, true, 1, "BK-M82B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-100 Black, 48", "Mountain-100 Black, 48", 1898.0944m, 3374.99m, 75m, "U", null },
                    { 75, true, 1, "BK-M68S-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Silver, 38", "Mountain-200 Silver, 38", 1265.6195m, 2319.99m, 75m, "U", null },
                    { 76, true, 1, "BK-M68S-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Silver, 42", "Mountain-200 Silver, 42", 1265.6195m, 2319.99m, 75m, "U", null },
                    { 77, true, 1, "BK-M68S-46", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Silver, 46", "Mountain-200 Silver, 46", 1265.6195m, 2319.99m, 75m, "U", null },
                    { 78, true, 1, "BK-M68B-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Black, 38", "Mountain-200 Black, 38", 1251.9813m, 2294.99m, 75m, "U", null },
                    { 79, true, 1, "BK-M68B-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Black, 42", "Mountain-200 Black, 42", 1251.9813m, 2294.99m, 75m, "U", null },
                    { 80, true, 1, "BK-M68B-46", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-200 Black, 46", "Mountain-200 Black, 46", 1251.9813m, 2294.99m, 75m, "U", null },
                    { 81, true, 1, "BK-M47B-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-300 Black, 38", "Mountain-300 Black, 38", 598.4354m, 1079.99m, 75m, "U", null },
                    { 82, true, 1, "BK-M47B-40", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-300 Black, 40", "Mountain-300 Black, 40", 598.4354m, 1079.99m, 75m, "U", null },
                    { 83, true, 1, "BK-M47B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-300 Black, 44", "Mountain-300 Black, 44", 598.4354m, 1079.99m, 75m, "U", null },
                    { 84, true, 1, "BK-M47B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain-300 Black, 48", "Mountain-300 Black, 48", 598.4354m, 1079.99m, 75m, "U", null },
                    { 85, true, 1, "BK-R89R-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Red, 44", "Road-250 Red, 44", 1518.7864m, 2443.35m, 75m, "U", null },
                    { 86, true, 1, "BK-R89R-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Red, 48", "Road-250 Red, 48", 1518.7864m, 2443.35m, 75m, "U", null },
                    { 87, true, 1, "BK-R89R-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Red, 52", "Road-250 Red, 52", 1518.7864m, 2443.35m, 75m, "U", null },
                    { 88, true, 1, "BK-R89R-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Red, 58", "Road-250 Red, 58", 1554.9479m, 2443.35m, 75m, "U", null },
                    { 89, true, 1, "BK-R89B-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Black, 44", "Road-250 Black, 44", 1554.9479m, 2443.35m, 75m, "U", null },
                    { 90, true, 1, "BK-R89B-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Black, 48", "Road-250 Black, 48", 1554.9479m, 2443.35m, 75m, "U", null },
                    { 91, true, 1, "BK-R89B-52", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Black, 52", "Road-250 Black, 52", 1554.9479m, 2443.35m, 75m, "U", null },
                    { 92, true, 1, "BK-R89B-58", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-250 Black, 58", "Road-250 Black, 58", 1554.9479m, 2443.35m, 75m, "U", null },
                    { 93, true, 1, "BK-R64Y-38", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-550-W Yellow, 38", "Road-550-W Yellow, 38", 713.0798m, 1120.49m, 75m, "U", null },
                    { 94, true, 1, "BK-R64Y-40", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-550-W Yellow, 40", "Road-550-W Yellow, 40", 713.0798m, 1120.49m, 75m, "U", null },
                    { 95, true, 1, "BK-R64Y-42", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-550-W Yellow, 42", "Road-550-W Yellow, 42", 713.0798m, 1120.49m, 75m, "U", null },
                    { 96, true, 1, "BK-R64Y-44", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-550-W Yellow, 44", "Road-550-W Yellow, 44", 713.0798m, 1120.49m, 75m, "U", null },
                    { 97, true, 1, "BK-R64Y-48", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road-550-W Yellow, 48", "Road-550-W Yellow, 48", 713.0798m, 1120.49m, 75m, "U", null },
                    { 98, true, 2, "FK-1639", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "LL Fork", "LL Fork", 65.8097m, 148.22m, 375m, "U", null },
                    { 99, true, 2, "FK-5136", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ML Fork", "ML Fork", 77.9176m, 175.49m, 375m, "U", null },
                    { 100, true, 2, "FK-9939", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "HL Fork", "HL Fork", 101.8936m, 229.49m, 375m, "U", null }
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
                name: "IX_Inventaries_ProductId",
                table: "Inventaries",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventaries_WarehouseId",
                table: "Inventaries",
                column: "WarehouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovementInventories_ProductId",
                table: "MovementInventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NumberOrder",
                table: "Orders",
                column: "NumberOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierId",
                table: "Orders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_ProductId",
                table: "SaleDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_SaleId",
                table: "SaleDetails",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientId",
                table: "Sales",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_NumberSale",
                table: "Sales",
                column: "NumberSale",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_RUC",
                table: "Suppliers",
                column: "RUC",
                unique: true);
        }

        /// <inheritdoc />
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
                name: "Inventaries");

            migrationBuilder.DropTable(
                name: "MovementInventories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "SaleDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
