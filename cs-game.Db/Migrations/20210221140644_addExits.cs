using Microsoft.EntityFrameworkCore.Migrations;

namespace cs_game.Migrations
{
    public partial class addExits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExitId",
                table: "Saves",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<int>(type: "int", nullable: false),
                    Longitude = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exits", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "Exits");

            migrationBuilder.DropIndex(
                name: "IX_Saves_ExitId",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "ExitId",
                table: "Saves");
        }
    }
}
