using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Proyecto_Control_Logistico.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    { 5, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Educational and reference materials", "Books", null },
                    { 6, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Any substance that can be consumed", "Foods", null },
                    { 7, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beverages and liquids", "Drinks", null },
                    { 8, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Decorative items and accessories", "Jewelry", null },
                    { 9, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronic devices and gadgets", "Technology", null },
                    { 10, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical drugs and treatments", "Medicaments", null },
                    { 11, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal care and beauty products", "Cosmetics", null },
                    { 12, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plants and gardening supplies", "Garden", null },
                    { 13, true, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Furniture and home decor", "Furniture", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CategoryId", "Code", "CreatedAt", "Description", "Name", "PriceCost", "PriceSell", "Stock", "UnitMeasure", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, 1, "BIK-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Bike", "Mountain Bike", 37.00m, 49.95m, 17m, "U", null },
                    { 2, true, 1, "BIK-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Road Bike", "Road Bike", 44.00m, 59.40m, 24m, "U", null },
                    { 3, true, 1, "BIK-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hybrid Bike", "Hybrid Bike", 51.00m, 68.85m, 31m, "U", null },
                    { 4, true, 1, "BIK-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "BMX Bike", "BMX Bike", 58.00m, 78.30m, 38m, "U", null },
                    { 5, true, 1, "BIK-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electric Bike", "Electric Bike", 65.00m, 87.75m, 45m, "U", null },
                    { 6, true, 1, "BIK-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kids Bike", "Kids Bike", 72.00m, 97.20m, 52m, "U", null },
                    { 7, true, 1, "BIK-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Touring Bike", "Touring Bike", 79.00m, 106.65m, 59m, "U", null },
                    { 8, true, 1, "BIK-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "City Bike", "City Bike", 86.00m, 116.10m, 66m, "U", null },
                    { 9, true, 1, "BIK-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fat Bike", "Fat Bike", 93.00m, 125.55m, 73m, "U", null },
                    { 10, true, 1, "BIK-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trail Bike", "Trail Bike", 100.00m, 135.00m, 80m, "U", null },
                    { 11, true, 2, "CMP-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Chain", "Bike Chain", 47.00m, 63.45m, 87m, "U", null },
                    { 12, true, 2, "CMP-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disc Brake", "Disc Brake", 54.00m, 72.90m, 94m, "U", null },
                    { 13, true, 2, "CMP-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedal Set", "Pedal Set", 61.00m, 82.35m, 11m, "U", null },
                    { 14, true, 2, "CMP-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Tire", "Bike Tire", 68.00m, 91.80m, 18m, "U", null },
                    { 15, true, 2, "CMP-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Rim", "Bike Rim", 75.00m, 101.25m, 25m, "U", null },
                    { 16, true, 2, "CMP-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handlebar", "Handlebar", 82.00m, 110.70m, 32m, "U", null },
                    { 17, true, 2, "CMP-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Saddle", "Bike Saddle", 89.00m, 120.15m, 39m, "U", null },
                    { 18, true, 2, "CMP-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crankset", "Crankset", 96.00m, 129.60m, 46m, "U", null },
                    { 19, true, 2, "CMP-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cassette", "Cassette", 103.00m, 139.05m, 53m, "U", null },
                    { 20, true, 2, "CMP-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspension Fork", "Suspension Fork", 110.00m, 148.50m, 60m, "U", null },
                    { 21, true, 3, "CLT-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Jersey", "Cycling Jersey", 57.00m, 76.95m, 67m, "U", null },
                    { 22, true, 3, "CLT-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Shorts", "Cycling Shorts", 64.00m, 86.40m, 74m, "U", null },
                    { 23, true, 3, "CLT-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Gloves", "Cycling Gloves", 71.00m, 95.85m, 81m, "U", null },
                    { 24, true, 3, "CLT-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Jacket", "Cycling Jacket", 78.00m, 105.30m, 88m, "U", null },
                    { 25, true, 3, "CLT-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Socks", "Cycling Socks", 85.00m, 114.75m, 95m, "U", null },
                    { 26, true, 3, "CLT-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rain Poncho", "Rain Poncho", 92.00m, 124.20m, 12m, "U", null },
                    { 27, true, 3, "CLT-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports Cap", "Sports Cap", 99.00m, 133.65m, 19m, "U", null },
                    { 28, true, 3, "CLT-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thermal Shirt", "Thermal Shirt", 106.00m, 143.10m, 26m, "U", null },
                    { 29, true, 3, "CLT-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wind Vest", "Wind Vest", 113.00m, 152.55m, 33m, "U", null },
                    { 30, true, 3, "CLT-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arm Sleeves", "Arm Sleeves", 120.00m, 162.00m, 40m, "U", null },
                    { 31, true, 4, "ACC-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Light", "Bike Light", 67.00m, 90.45m, 47m, "U", null },
                    { 32, true, 4, "ACC-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Water Bottle", "Water Bottle", 74.00m, 99.90m, 54m, "U", null },
                    { 33, true, 4, "ACC-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Pump", "Bike Pump", 81.00m, 109.35m, 61m, "U", null },
                    { 34, true, 4, "ACC-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phone Holder", "Phone Holder", 88.00m, 118.80m, 68m, "U", null },
                    { 35, true, 4, "ACC-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bike Lock", "Bike Lock", 95.00m, 128.25m, 75m, "U", null },
                    { 36, true, 4, "ACC-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rear Rack", "Rear Rack", 102.00m, 137.70m, 82m, "U", null },
                    { 37, true, 4, "ACC-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tool Kit", "Tool Kit", 109.00m, 147.15m, 89m, "U", null },
                    { 38, true, 4, "ACC-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bottle Cage", "Bottle Cage", 116.00m, 156.60m, 96m, "U", null },
                    { 39, true, 4, "ACC-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bell", "Bell", 123.00m, 166.05m, 13m, "U", null },
                    { 40, true, 4, "ACC-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mirror", "Mirror", 130.00m, 175.50m, 20m, "U", null },
                    { 41, true, 5, "BOK-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming Book", "Programming Book", 77.00m, 103.95m, 27m, "U", null },
                    { 42, true, 5, "BOK-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "History Book", "History Book", 84.00m, 113.40m, 34m, "U", null },
                    { 43, true, 5, "BOK-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Science Book", "Science Book", 91.00m, 122.85m, 41m, "U", null },
                    { 44, true, 5, "BOK-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cooking Book", "Cooking Book", 98.00m, 132.30m, 48m, "U", null },
                    { 45, true, 5, "BOK-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novel", "Novel", 105.00m, 141.75m, 55m, "U", null },
                    { 46, true, 5, "BOK-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dictionary", "Dictionary", 112.00m, 151.20m, 62m, "U", null },
                    { 47, true, 5, "BOK-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Atlas", "Atlas", 119.00m, 160.65m, 69m, "U", null },
                    { 48, true, 5, "BOK-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Math Book", "Math Book", 126.00m, 170.10m, 76m, "U", null },
                    { 49, true, 5, "BOK-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art Book", "Art Book", 133.00m, 179.55m, 83m, "U", null },
                    { 50, true, 5, "BOK-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travel Guide", "Travel Guide", 140.00m, 189.00m, 90m, "U", null },
                    { 51, true, 6, "FOD-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rice", "Rice", 87.00m, 117.45m, 97m, "KG", null },
                    { 52, true, 6, "FOD-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sugar", "Sugar", 94.00m, 126.90m, 14m, "KG", null },
                    { 53, true, 6, "FOD-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pasta", "Pasta", 101.00m, 136.35m, 21m, "KG", null },
                    { 54, true, 6, "FOD-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olive Oil", "Olive Oil", 108.00m, 145.80m, 28m, "KG", null },
                    { 55, true, 6, "FOD-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beans", "Beans", 115.00m, 155.25m, 35m, "KG", null },
                    { 56, true, 6, "FOD-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flour", "Flour", 122.00m, 164.70m, 42m, "KG", null },
                    { 57, true, 6, "FOD-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salt", "Salt", 129.00m, 174.15m, 49m, "KG", null },
                    { 58, true, 6, "FOD-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffee", "Coffee", 136.00m, 183.60m, 56m, "KG", null },
                    { 59, true, 6, "FOD-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oats", "Oats", 143.00m, 193.05m, 63m, "KG", null },
                    { 60, true, 6, "FOD-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cereal", "Cereal", 150.00m, 202.50m, 70m, "KG", null },
                    { 61, true, 7, "DRK-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mineral Water", "Mineral Water", 97.00m, 130.95m, 77m, "L", null },
                    { 62, true, 7, "DRK-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange Juice", "Orange Juice", 104.00m, 140.40m, 84m, "L", null },
                    { 63, true, 7, "DRK-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Juice", "Apple Juice", 111.00m, 149.85m, 91m, "L", null },
                    { 64, true, 7, "DRK-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cola Soda", "Cola Soda", 118.00m, 159.30m, 98m, "L", null },
                    { 65, true, 7, "DRK-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Energy Drink", "Energy Drink", 125.00m, 168.75m, 15m, "L", null },
                    { 66, true, 7, "DRK-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green Tea", "Green Tea", 132.00m, 178.20m, 22m, "L", null },
                    { 67, true, 7, "DRK-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffee Drink", "Coffee Drink", 139.00m, 187.65m, 29m, "L", null },
                    { 68, true, 7, "DRK-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milk", "Milk", 146.00m, 197.10m, 36m, "L", null },
                    { 69, true, 7, "DRK-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chocolate Drink", "Chocolate Drink", 153.00m, 206.55m, 43m, "L", null },
                    { 70, true, 7, "DRK-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports Drink", "Sports Drink", 160.00m, 216.00m, 50m, "L", null },
                    { 71, true, 8, "JWL-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold Ring", "Gold Ring", 107.00m, 144.45m, 57m, "U", null },
                    { 72, true, 8, "JWL-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silver Ring", "Silver Ring", 114.00m, 153.90m, 64m, "U", null },
                    { 73, true, 8, "JWL-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Necklace", "Necklace", 121.00m, 163.35m, 71m, "U", null },
                    { 74, true, 8, "JWL-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bracelet", "Bracelet", 128.00m, 172.80m, 78m, "U", null },
                    { 75, true, 8, "JWL-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earrings", "Earrings", 135.00m, 182.25m, 85m, "U", null },
                    { 76, true, 8, "JWL-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pendant", "Pendant", 142.00m, 191.70m, 92m, "U", null },
                    { 77, true, 8, "JWL-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anklet", "Anklet", 149.00m, 201.15m, 99m, "U", null },
                    { 78, true, 8, "JWL-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watch", "Watch", 156.00m, 210.60m, 16m, "U", null },
                    { 79, true, 8, "JWL-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brooch", "Brooch", 163.00m, 220.05m, 23m, "U", null },
                    { 80, true, 8, "JWL-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charm", "Charm", 170.00m, 229.50m, 30m, "U", null },
                    { 81, true, 9, "TEC-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop", "Laptop", 117.00m, 157.95m, 37m, "U", null },
                    { 82, true, 9, "TEC-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wireless Mouse", "Wireless Mouse", 124.00m, 167.40m, 44m, "U", null },
                    { 83, true, 9, "TEC-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mechanical Keyboard", "Mechanical Keyboard", 131.00m, 176.85m, 51m, "U", null },
                    { 84, true, 9, "TEC-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monitor", "Monitor", 138.00m, 186.30m, 58m, "U", null },
                    { 85, true, 9, "TEC-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "USB Drive", "USB Drive", 145.00m, 195.75m, 65m, "U", null },
                    { 86, true, 9, "TEC-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Webcam", "Webcam", 152.00m, 205.20m, 72m, "U", null },
                    { 87, true, 9, "TEC-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Headset", "Headset", 159.00m, 214.65m, 79m, "U", null },
                    { 88, true, 9, "TEC-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tablet", "Tablet", 166.00m, 224.10m, 86m, "U", null },
                    { 89, true, 9, "TEC-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smartphone", "Smartphone", 173.00m, 233.55m, 93m, "U", null },
                    { 90, true, 9, "TEC-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Printer", "Printer", 180.00m, 243.00m, 10m, "U", null },
                    { 91, true, 10, "MED-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paracetamol", "Paracetamol", 127.00m, 171.45m, 17m, "U", null },
                    { 92, true, 10, "MED-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ibuprofen", "Ibuprofen", 134.00m, 180.90m, 24m, "U", null },
                    { 93, true, 10, "MED-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitamin C", "Vitamin C", 141.00m, 190.35m, 31m, "U", null },
                    { 94, true, 10, "MED-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antacid", "Antacid", 148.00m, 199.80m, 38m, "U", null },
                    { 95, true, 10, "MED-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cough Syrup", "Cough Syrup", 155.00m, 209.25m, 45m, "U", null },
                    { 96, true, 10, "MED-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antibiotic Cream", "Antibiotic Cream", 162.00m, 218.70m, 52m, "U", null },
                    { 97, true, 10, "MED-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bandages", "Bandages", 169.00m, 228.15m, 59m, "U", null },
                    { 98, true, 10, "MED-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thermometer", "Thermometer", 176.00m, 237.60m, 66m, "U", null },
                    { 99, true, 10, "MED-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allergy Tablets", "Allergy Tablets", 183.00m, 247.05m, 73m, "U", null },
                    { 100, true, 10, "MED-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pain Relief Gel", "Pain Relief Gel", 190.00m, 256.50m, 80m, "U", null },
                    { 101, true, 11, "COS-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shampoo", "Shampoo", 137.00m, 184.95m, 87m, "U", null },
                    { 102, true, 11, "COS-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Conditioner", "Conditioner", 144.00m, 194.40m, 94m, "U", null },
                    { 103, true, 11, "COS-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Face Cream", "Face Cream", 151.00m, 203.85m, 11m, "U", null },
                    { 104, true, 11, "COS-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Body Lotion", "Body Lotion", 158.00m, 213.30m, 18m, "U", null },
                    { 105, true, 11, "COS-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perfume", "Perfume", 165.00m, 222.75m, 25m, "U", null },
                    { 106, true, 11, "COS-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lipstick", "Lipstick", 172.00m, 232.20m, 32m, "U", null },
                    { 107, true, 11, "COS-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mascara", "Mascara", 179.00m, 241.65m, 39m, "U", null },
                    { 108, true, 11, "COS-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunscreen", "Sunscreen", 186.00m, 251.10m, 46m, "U", null },
                    { 109, true, 11, "COS-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soap", "Soap", 193.00m, 260.55m, 53m, "U", null },
                    { 110, true, 11, "COS-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deodorant", "Deodorant", 200.00m, 270.00m, 60m, "U", null },
                    { 111, true, 12, "GRD-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flower Pot", "Flower Pot", 147.00m, 198.45m, 67m, "U", null },
                    { 112, true, 12, "GRD-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden Shovel", "Garden Shovel", 154.00m, 207.90m, 74m, "U", null },
                    { 113, true, 12, "GRD-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fertilizer", "Fertilizer", 161.00m, 217.35m, 81m, "U", null },
                    { 114, true, 12, "GRD-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rose Seeds", "Rose Seeds", 168.00m, 226.80m, 88m, "U", null },
                    { 115, true, 12, "GRD-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watering Can", "Watering Can", 175.00m, 236.25m, 95m, "U", null },
                    { 116, true, 12, "GRD-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Garden Hose", "Garden Hose", 182.00m, 245.70m, 12m, "U", null },
                    { 117, true, 12, "GRD-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pruning Shears", "Pruning Shears", 189.00m, 255.15m, 19m, "U", null },
                    { 118, true, 12, "GRD-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Soil Mix", "Soil Mix", 196.00m, 264.60m, 26m, "U", null },
                    { 119, true, 12, "GRD-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plant Tray", "Plant Tray", 203.00m, 274.05m, 33m, "U", null },
                    { 120, true, 12, "GRD-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rake", "Rake", 210.00m, 283.50m, 40m, "U", null },
                    { 121, true, 13, "FUR-001", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office Chair", "Office Chair", 157.00m, 211.95m, 47m, "U", null },
                    { 122, true, 13, "FUR-002", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wood Desk", "Wood Desk", 164.00m, 221.40m, 54m, "U", null },
                    { 123, true, 13, "FUR-003", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dining Table", "Dining Table", 171.00m, 230.85m, 61m, "U", null },
                    { 124, true, 13, "FUR-004", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bookshelf", "Bookshelf", 178.00m, 240.30m, 68m, "U", null },
                    { 125, true, 13, "FUR-005", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wardrobe", "Wardrobe", 185.00m, 249.75m, 75m, "U", null },
                    { 126, true, 13, "FUR-006", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nightstand", "Nightstand", 192.00m, 259.20m, 82m, "U", null },
                    { 127, true, 13, "FUR-007", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofa", "Sofa", 199.00m, 268.65m, 89m, "U", null },
                    { 128, true, 13, "FUR-008", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coffee Table", "Coffee Table", 206.00m, 278.10m, 96m, "U", null },
                    { 129, true, 13, "FUR-009", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "TV Stand", "TV Stand", 213.00m, 287.55m, 13m, "U", null },
                    { 130, true, 13, "FUR-010", new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cabinet", "Cabinet", 220.00m, 297.00m, 20m, "U", null }
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
