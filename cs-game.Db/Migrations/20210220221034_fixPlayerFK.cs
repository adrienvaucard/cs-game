using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class fixPlayerFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves",
                column: "PlayerId",
                unique: true);
        }
    }
}
