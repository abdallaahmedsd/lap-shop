using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LapShop.Migrations
{
    /// <inheritdoc />
    public partial class update_ProcessorCol_From_Stringint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processor",
                table: "TbItems");

            migrationBuilder.AddColumn<int>(
                name: "ProcessorId",
                table: "TbItems",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TbProcessors",
                columns: table => new
                {
                    ProcessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorName = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProcessors", x => x.ProcessorId);
                });

            migrationBuilder.InsertData(
                table: "TbProcessors",
                columns: new[] { "ProcessorId", "ProcessorName" },
                values: new object[,]
                {
                    { 1, "Intel Core i9-13900K" },
                    { 2, "AMD Ryzen 9 7950X" },
                    { 3, "Intel Core i7-13700K" },
                    { 4, "AMD Ryzen 7 7800X" },
                    { 5, "Intel Core i5-13600K" },
                    { 6, "AMD Ryzen 5 7600X" },
                    { 7, "Intel Core i3-13100" },
                    { 8, "AMD Ryzen 3 7300X" },
                    { 9, "Intel Xeon W-3375" },
                    { 10, "AMD Threadripper 3990X" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItems_ProcessorId",
                table: "TbItems",
                column: "ProcessorId");

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
                name: "FK_TbItems_TbProcessors",
                table: "TbItems");

            migrationBuilder.DropTable(
                name: "TbProcessors");

            migrationBuilder.DropIndex(
                name: "IX_TbItems_ProcessorId",
                table: "TbItems");

            migrationBuilder.DropColumn(
                name: "ProcessorId",
                table: "TbItems");

            migrationBuilder.AddColumn<string>(
                name: "Processor",
                table: "TbItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
