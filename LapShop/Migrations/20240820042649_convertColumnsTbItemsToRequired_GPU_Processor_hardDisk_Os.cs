using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class convertColumnsTbItemsToRequired_GPU_Processor_hardDisk_Os : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbHardDisks",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbItemTypes",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbOs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenResolutionId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "OsId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "TbItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HardDiskId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems",
                column: "ScreenResolutionId",
                principalTable: "TbScreenResolutions",
                principalColumn: "ScreenResolutionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems",
                column: "GPUId",
                principalTable: "TbGPUs",
                principalColumn: "GPUId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbHardDisks",
                table: "TbItems",
                column: "HardDiskId",
                principalTable: "TbHardDisks",
                principalColumn: "HardDiskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbItemTypes",
                table: "TbItems",
                column: "ItemTypeId",
                principalTable: "TbItemTypes",
                principalColumn: "ItemTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbOs",
                table: "TbItems",
                column: "OsId",
                principalTable: "TbOs",
                principalColumn: "OsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems",
                column: "ProcessorId",
                principalTable: "TbProcessors",
                principalColumn: "ProcessorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbGPUs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbHardDisks",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbItemTypes",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbOs",
                table: "TbItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems");

            migrationBuilder.AlterColumn<int>(
                name: "ScreenResolutionId",
                table: "TbItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessorId",
                table: "TbItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OsId",
                table: "TbItems",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "TbItems",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HardDiskId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems",
                column: "ScreenResolutionId",
                principalTable: "TbScreenResolutions",
                principalColumn: "ScreenResolutionId");

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
                name: "FK_TbItems_TbItemTypes",
                table: "TbItems",
                column: "ItemTypeId",
                principalTable: "TbItemTypes",
                principalColumn: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbOs",
                table: "TbItems",
                column: "OsId",
                principalTable: "TbOs",
                principalColumn: "OsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_TbProcessors",
                table: "TbItems",
                column: "ProcessorId",
                principalTable: "TbProcessors",
                principalColumn: "ProcessorId");
        }
    }
}
