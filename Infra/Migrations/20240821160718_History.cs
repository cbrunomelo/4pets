using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class History : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_STOCK",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_STOCK",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_ORDER_ITEM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_ORDER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_ORDER",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_CLIENT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_CLIENT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "TB_CATEGORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TB_CATEGORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HISTORY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_CATEGORY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_CLIENT_ClientId",
                        column: x => x.ClientId,
                        principalTable: "TB_CLIENT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_ORDER_ITEM_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "TB_ORDER_ITEM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TB_ORDER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_TB_STOCK_StockId",
                        column: x => x.StockId,
                        principalTable: "TB_STOCK",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_HISTORY_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_HISTORYFIELD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<int>(type: "int", nullable: false),
                    FieldName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    CurrentValue = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HISTORYFIELD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_HISTORYFIELD_TB_HISTORY_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "TB_HISTORY",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_CategoryId",
                table: "TB_HISTORY",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_ClientId",
                table: "TB_HISTORY",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_OrderId",
                table: "TB_HISTORY",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_OrderItemId",
                table: "TB_HISTORY",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_ProductId",
                table: "TB_HISTORY",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_StockId",
                table: "TB_HISTORY",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_UserId",
                table: "TB_HISTORY",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORYFIELD_HistoryId",
                table: "TB_HISTORYFIELD",
                column: "HistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_HISTORYFIELD");

            migrationBuilder.DropTable(
                name: "TB_HISTORY");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_STOCK");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_STOCK");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_PRODUCT");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_PRODUCT");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_ORDER_ITEM");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_ORDER");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_ORDER");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_CLIENT");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_CLIENT");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "TB_CATEGORY");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TB_CATEGORY");
        }
    }
}
