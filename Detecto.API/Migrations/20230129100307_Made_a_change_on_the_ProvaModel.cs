using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Made_a_change_on_the_ProvaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lloji",
                table: "Provat",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lloji",
                table: "Provat");
        }
    }
}
