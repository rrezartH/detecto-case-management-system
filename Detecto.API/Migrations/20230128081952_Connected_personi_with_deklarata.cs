using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Connected_personi_with_deklarata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersoniId",
                table: "Deklaratat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Deklaratat_PersoniId",
                table: "Deklaratat",
                column: "PersoniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deklaratat_Personat_PersoniId",
                table: "Deklaratat",
                column: "PersoniId",
                principalTable: "Personat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deklaratat_Personat_PersoniId",
                table: "Deklaratat");

            migrationBuilder.DropIndex(
                name: "IX_Deklaratat_PersoniId",
                table: "Deklaratat");

            migrationBuilder.DropColumn(
                name: "PersoniId",
                table: "Deklaratat");
        }
    }
}
