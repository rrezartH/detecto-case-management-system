using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class caseId_DCase_Edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Palet",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "eKaluara",
                table: "Personat",
                newName: "EKaluara");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Personat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DCaseId",
                table: "Personat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personat_DCaseId",
                table: "Personat",
                column: "DCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personat_Cases_DCaseId",
                table: "Personat",
                column: "DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personat_Cases_DCaseId",
                table: "Personat");

            migrationBuilder.DropIndex(
                name: "IX_Personat_DCaseId",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "DCaseId",
                table: "Personat");

            migrationBuilder.RenameColumn(
                name: "EKaluara",
                table: "Personat",
                newName: "eKaluara");

            migrationBuilder.AddColumn<string>(
                name: "Palet",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
