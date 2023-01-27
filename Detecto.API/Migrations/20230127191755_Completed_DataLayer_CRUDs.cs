using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Completed_DataLayer_CRUDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deklaratat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KohaEMarrjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Permbajtja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deklaratat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GjurmetBiologjike",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emertimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lloji = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GjurmetBiologjike", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KohaENxjerrjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vendndodhja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeknikaENxjerrjes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPerdorurNeKrim = table.Column<bool>(type: "bit", nullable: true),
                    Rrezikshmeria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Klasifikimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuhetEkzaminim = table.Column<bool>(type: "bit", nullable: true),
                    KaGjurmeBiologjike = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provat", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deklaratat");

            migrationBuilder.DropTable(
                name: "GjurmetBiologjike");

            migrationBuilder.DropTable(
                name: "Provat");
        }
    }
}
