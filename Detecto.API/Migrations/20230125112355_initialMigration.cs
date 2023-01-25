using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Palet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Files = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
