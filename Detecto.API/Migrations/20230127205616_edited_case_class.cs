using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class edited_case_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Viktima_DCaseId",
                table: "Personat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iDyshuari_DCaseId",
                table: "Personat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personat_iDyshuari_DCaseId",
                table: "Personat",
                column: "iDyshuari_DCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Personat_Viktima_DCaseId",
                table: "Personat",
                column: "Viktima_DCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personat_Cases_iDyshuari_DCaseId",
                table: "Personat",
                column: "iDyshuari_DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personat_Cases_Viktima_DCaseId",
                table: "Personat",
                column: "Viktima_DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personat_Cases_iDyshuari_DCaseId",
                table: "Personat");

            migrationBuilder.DropForeignKey(
                name: "FK_Personat_Cases_Viktima_DCaseId",
                table: "Personat");

            migrationBuilder.DropIndex(
                name: "IX_Personat_iDyshuari_DCaseId",
                table: "Personat");

            migrationBuilder.DropIndex(
                name: "IX_Personat_Viktima_DCaseId",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "Viktima_DCaseId",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "iDyshuari_DCaseId",
                table: "Personat");
        }
    }
}
