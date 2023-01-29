using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Syncronized_provaBiologjie_and_gjurmaBiologjike_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emertimi",
                table: "GjurmetBiologjike",
                newName: "Specifikimi");

            migrationBuilder.AddColumn<string>(
                name: "Specifikimi",
                table: "Provat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Emri",
                table: "GjurmetBiologjike",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specifikimi",
                table: "Provat");

            migrationBuilder.DropColumn(
                name: "Emri",
                table: "GjurmetBiologjike");

            migrationBuilder.RenameColumn(
                name: "Specifikimi",
                table: "GjurmetBiologjike",
                newName: "Emertimi");
        }
    }
}
