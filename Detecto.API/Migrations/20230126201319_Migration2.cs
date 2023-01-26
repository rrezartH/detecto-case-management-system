using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Dyshohet",
                table: "Personat",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaportiMeViktimen",
                table: "Personat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Vezhgohet",
                table: "Personat",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dyshohet",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "RaportiMeViktimen",
                table: "Personat");

            migrationBuilder.DropColumn(
                name: "Vezhgohet",
                table: "Personat");
        }
    }
}
