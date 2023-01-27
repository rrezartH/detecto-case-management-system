using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class added_TeDyshuarit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dyshimi",
                table: "Personat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dyshimi",
                table: "Personat");
        }
    }
}
