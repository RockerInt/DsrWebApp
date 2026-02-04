using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SaleId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Enable = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleItem_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "CreateDate", "Email", "Enable", "Name", "Phone" },
                values: new object[,]
                {
                    { new Guid("1a8a7e4a-72db-4c51-8a6a-3a3a3a3a3a3a"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", true, "John Doe", "+57 3123456789" },
                    { new Guid("2b8b8f5b-83ec-5d62-9b7b-4b4b4b4b4b4b"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", true, "Jane Smith", "+57 3212345678" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CreateDate", "Description", "Enable", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("3c9c9c6c-94fd-4e73-ac8c-5c5c5c5c5c5c"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal computer macbook", true, "Laptop", 1200m },
                    { new Guid("4d0d0d7d-05de-4f84-bd9d-6d6d6d6d6d6d"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computer mouse", true, "Mouse", 25m }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "Id", "CreateDate", "Enable", "ProductId", "StockQuantity" },
                values: new object[,]
                {
                    { new Guid("3352e4c0-f5c7-4f9e-9b5c-d73716c64e42"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("4d0d0d7d-05de-4f84-bd9d-6d6d6d6d6d6d"), 50 },
                    { new Guid("ca2f98e5-fd16-472e-8384-e28f615a9769"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("3c9c9c6c-94fd-4e73-ac8c-5c5c5c5c5c5c"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "Id", "ClientId", "CreateDate", "Enable", "SaleDate" },
                values: new object[] { new Guid("5e1e1e8e-16df-4a95-ce0e-7e7e7e7e7e7e"), new Guid("1a8a7e4a-72db-4c51-8a6a-3a3a3a3a3a3a"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SaleItem",
                columns: new[] { "Id", "CreateDate", "Enable", "ProductId", "Quantity", "SaleId", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("6f2f2f9f-27fa-4c06-df1f-8f8f8f8f8f8f"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("3c9c9c6c-94fd-4e73-ac8c-5c5c5c5c5c5c"), 1, new Guid("5e1e1e8e-16df-4a95-ce0e-7e7e7e7e7e7e"), 1200m },
                    { new Guid("7a3a3c0a-38ab-4e17-ea2a-9a9a9a9a9a9a"), new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new Guid("4d0d0d7d-05de-4f84-bd9d-6d6d6d6d6d6d"), 1, new Guid("5e1e1e8e-16df-4a95-ce0e-7e7e7e7e7e7e"), 25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ClientId",
                table: "Sale",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_ProductId",
                table: "SaleItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleItem_SaleId",
                table: "SaleItem",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "SaleItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
