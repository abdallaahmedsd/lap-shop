using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class ContractSoftDeleteItem_ScreenResoultionCol_FromString_ToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenReslution",
                table: "TbItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "TbItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TbItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ScreenResolutionId",
                table: "TbItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbScreenResolutions",
                columns: table => new
                {
                    ScreenResolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenResolutionName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbScreenResolutions", x => x.ScreenResolutionId);
                });

            migrationBuilder.InsertData(
                table: "TbScreenResolutions",
                columns: new[] { "ScreenResolutionId", "ScreenResolutionName" },
                values: new object[,]
                {
                    { 1, "Full HD (1920x1080)" },
                    { 2, "Quad HD (2560x1440)" },
                    { 3, "4K Ultra HD (3840x2160)" },
                    { 4, "HD (1366x768)" },
                    { 5, "HD+ (1600x900)" },
                    { 6, "HD Ready (1280x720)" },
                    { 7, "WUXGA (1920x1200)" },
                    { 8, "WQXGA (2560x1600)" },
                    { 9, "Ultrawide Quad HD (3440x1440)" },
                    { 10, "Super UltraWide (5120x1440)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItems_ScreenResolutionId",
                table: "TbItems",
                column: "ScreenResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems",
                column: "ScreenResolutionId",
                principalTable: "TbScreenResolutions",
                principalColumn: "ScreenResolutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbItems_ScreenResolutions",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbScreenResolutions");

            migrationBuilder.DropIndex(
                name: "IX_TbItems_ScreenResolutionId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "ScreenResolutionId",
                table: "TbItems");

            migrationBuilder.AddColumn<string>(
                name: "ScreenResolution",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
