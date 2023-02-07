using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class removed_files_for_testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Cases_DCaseId",
                table: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
