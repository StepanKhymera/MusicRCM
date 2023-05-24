using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRCM.Migrations
{
    public partial class duration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "Song");
        }
    }
}
