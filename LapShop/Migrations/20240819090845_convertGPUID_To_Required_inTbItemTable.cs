using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class convertGPUID_To_Required_inTbItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "TbItems",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "TbItems",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId");
        }
    }
}
