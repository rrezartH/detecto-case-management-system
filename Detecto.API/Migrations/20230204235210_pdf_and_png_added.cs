using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class pdf_and_png_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DFile_Cases_DCaseId",
                table: "DFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DFile",
                table: "DFile");

            migrationBuilder.RenameTable(
                name: "DFile",
                newName: "Files");

            migrationBuilder.RenameIndex(
                name: "IX_DFile_DCaseId",
                table: "Files",
                newName: "IX_Files_DCaseId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Cases_DCaseId",
                table: "Files",
                column: "DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Cases_DCaseId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

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

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "DFile");

            migrationBuilder.RenameIndex(
                name: "IX_Files_DCaseId",
                table: "DFile",
                newName: "IX_DFile_DCaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DFile",
                table: "DFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DFile_Cases_DCaseId",
                table: "DFile",
                column: "DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }
    }
}
