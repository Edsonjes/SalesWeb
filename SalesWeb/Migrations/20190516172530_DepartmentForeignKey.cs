using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWeb.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saller_Departament_Deparmentid",
                table: "Saller");

            migrationBuilder.DropIndex(
                name: "IX_Saller_Deparmentid",
                table: "Saller");

            migrationBuilder.DropColumn(
                name: "Deparmentid",
                table: "Saller");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Saller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saller_DepartamentId",
                table: "Saller",
                column: "DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller",
                column: "DepartamentId",
                principalTable: "Departament",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saller_Departament_DepartamentId",
                table: "Saller");

            migrationBuilder.DropIndex(
                name: "IX_Saller_DepartamentId",
                table: "Saller");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Saller");

            migrationBuilder.AddColumn<int>(
                name: "Deparmentid",
                table: "Saller",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saller_Deparmentid",
                table: "Saller",
                column: "Deparmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Saller_Departament_Deparmentid",
                table: "Saller",
                column: "Deparmentid",
                principalTable: "Departament",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
