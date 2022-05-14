using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRCM.Migrations
{
    public partial class typofix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "County",
                table: "AspNetUsers",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AspNetUsers",
                newName: "County");
        }
    }
}
