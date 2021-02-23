using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class EditExit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_Exits_ExitId",
                table: "Saves");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Saves_ExitId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "ExitId",
                table: "Saves");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exits_Saves_SaveId",
                table: "Exits");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Exits_SaveId",
                table: "Exits");

            migrationBuilder.DropColumn(
                name: "SaveId",
                table: "Exits");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Weapons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ExitId",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_ExitId",
                table: "Saves",
                column: "ExitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Players_PlayerId",
                table: "Items",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_Exits_ExitId",
                table: "Saves",
                column: "ExitId",
                principalTable: "Exits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Players_PlayerId",
                table: "Weapons",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
