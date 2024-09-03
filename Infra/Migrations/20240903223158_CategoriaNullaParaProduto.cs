using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaNullaParaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                table: "TB_PRODUCT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TB_PRODUCT",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                table: "TB_PRODUCT",
                column: "CategoryId",
                principalTable: "TB_CATEGORY",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                table: "TB_PRODUCT");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TB_PRODUCT",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUCT_TB_CATEGORY_CategoryId",
                table: "TB_PRODUCT",
                column: "CategoryId",
                principalTable: "TB_CATEGORY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
