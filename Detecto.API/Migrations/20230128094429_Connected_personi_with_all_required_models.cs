using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Connected_personi_with_all_required_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersoniId",
                table: "Provat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersoniId",
                table: "GjurmetBiologjike",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Provat_PersoniId",
                table: "Provat",
                column: "PersoniId");

            migrationBuilder.CreateIndex(
                name: "IX_GjurmetBiologjike_PersoniId",
                table: "GjurmetBiologjike",
                column: "PersoniId");

            migrationBuilder.AddForeignKey(
                name: "FK_GjurmetBiologjike_Personat_PersoniId",
                table: "GjurmetBiologjike",
                column: "PersoniId",
                principalTable: "Personat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provat_Personat_PersoniId",
                table: "Provat",
                column: "PersoniId",
                principalTable: "Personat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GjurmetBiologjike_Personat_PersoniId",
                table: "GjurmetBiologjike");

            migrationBuilder.DropForeignKey(
                name: "FK_Provat_Personat_PersoniId",
                table: "Provat");

            migrationBuilder.DropIndex(
                name: "IX_Provat_PersoniId",
                table: "Provat");

            migrationBuilder.DropIndex(
                name: "IX_GjurmetBiologjike_PersoniId",
                table: "GjurmetBiologjike");

            migrationBuilder.DropColumn(
                name: "PersoniId",
                table: "Provat");

            migrationBuilder.DropColumn(
                name: "PersoniId",
                table: "GjurmetBiologjike");
        }
    }
}
