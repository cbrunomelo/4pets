using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class HistoryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_HISTORY_User_UserId",
                table: "TB_HISTORY");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_CategoryId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_ClientId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_OrderId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_OrderItemId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_ProductId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_StockId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_UserId",
                table: "TB_HISTORY");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TB_HISTORY");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TB_HISTORY",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_CategoryId",
                table: "TB_HISTORY",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_ClientId",
                table: "TB_HISTORY",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_OrderId",
                table: "TB_HISTORY",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_OrderItemId",
                table: "TB_HISTORY",
                column: "OrderItemId",
                unique: true,
                filter: "[OrderItemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_ProductId",
                table: "TB_HISTORY",
                column: "ProductId",
                unique: true,
                filter: "[ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_HISTORY_StockId",
                table: "TB_HISTORY",
                column: "StockId",
                unique: true,
                filter: "[StockId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_CategoryId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_ClientId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_OrderId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_OrderItemId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_ProductId",
                table: "TB_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_TB_HISTORY_StockId",
                table: "TB_HISTORY");

            migrationBuilder.AlterColumn<int>(
                name: "StockId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderItemId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TB_HISTORY",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_TB_HISTORY_User_UserId",
                table: "TB_HISTORY",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
