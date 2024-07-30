using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_STOCK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvaragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STOCK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLIENT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CLIENT_TB_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "TB_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_TB_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "TB_STOCK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_TB_CLIENT_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TB_CLIENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORDER_ITEM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORDER_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ORDER_ITEM_TB_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TB_ORDER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_ORDER_ITEM_TB_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENT_StockId",
                table: "TB_CLIENT",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_ClientId",
                table: "TB_ORDER",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_ITEM_OrderId",
                table: "TB_ORDER_ITEM",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ORDER_ITEM_ProductId",
                table: "TB_ORDER_ITEM",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_CategoryId",
                table: "TB_PRODUCT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_StockId",
                table: "TB_PRODUCT",
                column: "StockId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "TB_ORDER");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_CLIENT");

            migrationBuilder.DropTable(
                name: "TB_CATEGORY");

            migrationBuilder.DropTable(
                name: "TB_STOCK");
        }
    }
}
