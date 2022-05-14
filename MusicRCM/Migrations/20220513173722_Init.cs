using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRCM.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    playlist_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.playlist_id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    song_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    playlist_id = table.Column<int>(type: "int", nullable: false),
                    spotify_id = table.Column<int>(type: "int", nullable: false),
                    song_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artist_id = table.Column<int>(type: "int", nullable: false),
                    artist_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.song_id);
                    table.ForeignKey(
                        name: "FK_Song_Playlist_playlist_id",
                        column: x => x.playlist_id,
                        principalTable: "Playlist",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_playlist_id",
                table: "Song",
                column: "playlist_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Playlist");
        }
    }
}
