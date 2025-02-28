using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPIApp.Migrations
{
    public partial class AddTblLoai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaLoai",
                table: "HangHoas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.MaLoai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoas_Loais_MaLoai",
                table: "HangHoas",
                column: "MaLoai",
                principalTable: "Loais",
                principalColumn: "MaLoai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoas_Loais_MaLoai",
                table: "HangHoas");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas");

            migrationBuilder.DropColumn(
                name: "MaLoai",
                table: "HangHoas");
        }
    }
}
