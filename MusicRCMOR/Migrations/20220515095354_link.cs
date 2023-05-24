using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRCM.Migrations
{
    public partial class link : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "spotify_id",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Playlist",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_user_id",
                table: "Playlist",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_AspNetUsers_user_id",
                table: "Playlist",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_AspNetUsers_user_id",
                table: "Playlist");

            migrationBuilder.DropIndex(
                name: "IX_Playlist_user_id",
                table: "Playlist");

            migrationBuilder.AlterColumn<int>(
                name: "spotify_id",
                table: "Song",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
