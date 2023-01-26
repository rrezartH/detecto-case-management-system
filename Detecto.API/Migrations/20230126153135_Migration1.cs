using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Detecto.API.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseTask_Cases_DCaseId",
                table: "CaseTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseTask",
                table: "CaseTask");

            migrationBuilder.RenameTable(
                name: "CaseTask",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_CaseTask_DCaseId",
                table: "Tasks",
                newName: "IX_Tasks_DCaseId");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Detectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detectives", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Cases_DCaseId",
                table: "Tasks",
                column: "DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Cases_DCaseId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Detectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "CaseTask");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_DCaseId",
                table: "CaseTask",
                newName: "IX_CaseTask_DCaseId");

            migrationBuilder.AlterColumn<int>(
                name: "CaseId",
                table: "CaseTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseTask",
                table: "CaseTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseTask_Cases_DCaseId",
                table: "CaseTask",
                column: "DCaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }
    }
}
