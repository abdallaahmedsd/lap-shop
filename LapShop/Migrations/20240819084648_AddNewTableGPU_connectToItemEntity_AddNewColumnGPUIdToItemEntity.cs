using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableGPU_connectToItemEntity_AddNewColumnGPUIdToItemEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gpu",
                table: "TbItems");

            migrationBuilder.AddColumn<int>(
                name: "GPUId",
                table: "TbItems",
                type: "INT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbGPUs",
                columns: table => new
                {
                    GPUId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPUName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbGPUs", x => x.GPUId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItems_GPUId",
                table: "TbItems",
                column: "GPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbGPUs");

            migrationBuilder.DropIndex(
                name: "IX_TbItems_GPUId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "GPUId",
                table: "TbItems");

            migrationBuilder.AddColumn<string>(
                name: "Gpu",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
