using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class updateSave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaveId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaveId",
                table: "Monsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_SaveId",
                table: "Player",
                column: "SaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_SaveId",
                table: "Monsters",
                column: "SaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Saves_SaveId",
                table: "Monsters",
                column: "SaveId",
                principalTable: "Saves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Saves_SaveId",
                table: "Player",
                column: "SaveId",
                principalTable: "Saves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Saves_SaveId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Saves_SaveId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_SaveId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_SaveId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Monsters");
        }
    }
}
