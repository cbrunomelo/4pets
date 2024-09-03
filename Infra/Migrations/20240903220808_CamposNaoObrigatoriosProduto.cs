using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CamposNaoObrigatoriosProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_TB_STOCK_StockId",
                table: "TB_PRODUCT");

            migrationBuilder.DropIndex(
                name: "IX_TB_PRODUCT_StockId",
                table: "TB_PRODUCT");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "TB_PRODUCT");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "TB_STOCK",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_STOCK_ProductId",
                table: "TB_STOCK",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_STOCK_TB_PRODUCT_ProductId",
                table: "TB_STOCK",
                column: "ProductId",
                principalTable: "TB_PRODUCT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_STOCK_TB_PRODUCT_ProductId",
                table: "TB_STOCK");

            migrationBuilder.DropIndex(
                name: "IX_TB_STOCK_ProductId",
                table: "TB_STOCK");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "TB_STOCK");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "TB_PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_StockId",
                table: "TB_PRODUCT",
                column: "StockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_TB_STOCK_StockId",
                table: "TB_PRODUCT",
                column: "StockId",
                principalTable: "TB_STOCK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
