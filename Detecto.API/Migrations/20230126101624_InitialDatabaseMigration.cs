using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class InitialDatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseTasks",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "Cases");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateClosed",
                table: "Cases",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CaseTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    DCaseId = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTask_Cases_DCaseId",
                        column: x => x.DCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Cases_DCaseId",
                        column: x => x.DCaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Personat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gjinia = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Profesioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statusi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendbanimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GjendjaMendore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eKaluara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vendi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Menyra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gjendja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personat", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseTask_DCaseId",
                table: "CaseTask",
                column: "DCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_File_DCaseId",
                table: "File",
                column: "DCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseTask");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Personat");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateClosed",
                table: "Cases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseTasks",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Files",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
