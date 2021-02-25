using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class playerSaveFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Saves_SaveId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_SaveId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Saves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Players_PlayerId",
                table: "Saves",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Players_PlayerId",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_PlayerId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Saves");

            migrationBuilder.AddColumn<int>(
                name: "SaveId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_SaveId",
                table: "Players",
                column: "SaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Saves_SaveId",
                table: "Players",
                column: "SaveId",
                principalTable: "Saves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
