using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class dyshimilayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "DyshimiId",
                table: "Provat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DyshimiId",
                table: "Personat",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DCaseId",
                table: "Tasks",
                column: "DCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Provat_DyshimiId",
                table: "Provat",
                column: "DyshimiId");

            migrationBuilder.CreateIndex(
                name: "IX_Personat_DyshimiId",
                table: "Personat",
                column: "DyshimiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personat_Dyshimet_DyshimiId",
                table: "Personat",
                column: "DyshimiId",
                principalTable: "Dyshimet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provat_Dyshimet_DyshimiId",
                table: "Provat",
                column: "DyshimiId",
                principalTable: "Dyshimet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personat_Dyshimet_DyshimiId",
                table: "Personat");

            migrationBuilder.DropForeignKey(
                name: "FK_Provat_Dyshimet_DyshimiId",
                table: "Provat");

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

            migrationBuilder.DropColumn(
                name: "DyshimiId",
                table: "Provat");

            migrationBuilder.DropColumn(
                name: "DyshimiId",
                table: "Personat");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "Files",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Files",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Width",
                table: "Files",
                type: "float",
                nullable: true);
        }
    }
}
