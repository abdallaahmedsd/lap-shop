using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class update_HardDiskCol_From_Stringint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "HardDisk",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorId",
                table: "TbItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "TbItems",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AddColumn<int>(
                name: "HardDiskId",
                table: "TbItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbHardDisks",
                columns: table => new
                {
                    HardDiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardDiskName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbHardDisks", x => x.HardDiskId);
                });

            migrationBuilder.InsertData(
                table: "TbHardDisks",
                columns: new[] { "HardDiskId", "HardDiskName" },
                values: new object[,]
                {
                    { 1, "Samsung 970 EVO Plus 1TB NVMe M.2" },
                    { 2, "Western Digital Blue 1TB 7200 RPM SATA" },
                    { 3, "Seagate Barracuda 2TB 7200 RPM SATA" },
                    { 4, "Crucial MX500 500GB 3D NAND SATA 2.5 Inch" },
                    { 5, "Samsung 860 EVO 500GB 2.5 Inch SATA" },
                    { 6, "WD Black SN750 1TB NVMe M.2" },
                    { 7, "Toshiba X300 4TB 7200 RPM SATA" },
                    { 8, "Kingston A2000 1TB NVMe M.2" },
                    { 9, "Seagate FireCuda 2TB SSHD SATA" },
                    { 10, "WD Blue 2TB SATA 2.5 Inch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItems_HardDiskId",
                table: "TbItems",
                column: "HardDiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbHardDisks",
                table: "TbItems",
                column: "HardDiskId",
                principalTable: "TbHardDisks",
                principalColumn: "HardDiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems",
                column: "ProcessorId",
                principalTable: "TbProcessors",
                principalColumn: "ProcessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbHardDisks",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbHardDisks");

            migrationBuilder.DropIndex(
                name: "IX_TbItems_HardDiskId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "HardDiskId",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GPUId",
                table: "TbItems",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HardDisk",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems",
                column: "ProcessorId",
                principalTable: "TbProcessors",
                principalColumn: "ProcessorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
