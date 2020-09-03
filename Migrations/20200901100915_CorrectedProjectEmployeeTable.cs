using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesCRUD.Migrations
{
    public partial class CorrectedProjectEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployeesTable_EmployeesTable_EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployeesTable_ProjectsTable_ProjectsTableProjectId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployeesTable_EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployeesTable_ProjectsTableProjectId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropColumn(
                name: "EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropColumn(
                name: "ProjectsTableProjectId",
                table: "ProjectEmployeesTable");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_EmployeeId",
                table: "ProjectEmployeesTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_ProjectId",
                table: "ProjectEmployeesTable",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployeesTable_EmployeesTable_EmployeeId",
                table: "ProjectEmployeesTable",
                column: "EmployeeId",
                principalTable: "EmployeesTable",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployeesTable_ProjectsTable_ProjectId",
                table: "ProjectEmployeesTable",
                column: "ProjectId",
                principalTable: "ProjectsTable",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployeesTable_EmployeesTable_EmployeeId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectEmployeesTable_ProjectsTable_ProjectId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployeesTable_EmployeeId",
                table: "ProjectEmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployeesTable_ProjectId",
                table: "ProjectEmployeesTable");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsTableProjectId",
                table: "ProjectEmployeesTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable",
                column: "EmployeesTableEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_ProjectsTableProjectId",
                table: "ProjectEmployeesTable",
                column: "ProjectsTableProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployeesTable_EmployeesTable_EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable",
                column: "EmployeesTableEmployeeId",
                principalTable: "EmployeesTable",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectEmployeesTable_ProjectsTable_ProjectsTableProjectId",
                table: "ProjectEmployeesTable",
                column: "ProjectsTableProjectId",
                principalTable: "ProjectsTable",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
