using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class filetableadded : Migration
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Files",
                newName: "FileName");

            migrationBuilder.RenameIndex(
                name: "IX_DFile_DCaseId",
                table: "Files",
                newName: "IX_Files_DCaseId");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                table: "Files",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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
                name: "CaseId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileData",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "DFile");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "DFile",
                newName: "Name");

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
