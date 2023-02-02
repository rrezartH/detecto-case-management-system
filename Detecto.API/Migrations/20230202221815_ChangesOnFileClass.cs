using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class ChangesOnFileClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUploaded",
                table: "Files",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUploaded",
                table: "Files");
        }
    }
}
