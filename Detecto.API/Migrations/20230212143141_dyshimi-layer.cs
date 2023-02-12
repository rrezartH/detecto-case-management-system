using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class dyshimilayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Detektivet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hulumtimi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detektivet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dyshimet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEqeshtjes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dyshimet", x => x.Id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Detektivet");

            migrationBuilder.DropTable(
                name: "Dyshimet");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DCaseId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Provat_DyshimiId",
                table: "Provat");

            migrationBuilder.DropIndex(
                name: "IX_Personat_DyshimiId",
                table: "Personat");

           
        }
    }
}
