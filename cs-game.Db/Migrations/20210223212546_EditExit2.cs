using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class EditExit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exits_Saves_SaveId",
                table: "Exits");

            migrationBuilder.DropIndex(
                name: "IX_Exits_SaveId",
                table: "Exits");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Exits");

            migrationBuilder.AddColumn<int>(
                name: "SaveId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExitId",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saves_ExitId",
                table: "Saves",
                column: "ExitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Exits_ExitId",
                table: "Saves",
                column: "ExitId",
                principalTable: "Exits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Exits_ExitId",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_ExitId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ExitId",
                table: "Saves");

            migrationBuilder.AddColumn<int>(
                name: "SaveId",
                table: "Exits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exits_SaveId",
                table: "Exits",
                column: "SaveId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exits_Saves_SaveId",
                table: "Exits",
                column: "SaveId",
                principalTable: "Saves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
