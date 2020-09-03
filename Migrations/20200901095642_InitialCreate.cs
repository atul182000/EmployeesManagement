using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesCRUD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesTable",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    HourlyWage = table.Column<double>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTable", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsTable",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsTable", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "JobOrdersTable",
                columns: table => new
                {
                    JobOrdersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OrderDateTime = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrdersTable", x => x.JobOrdersId);
                    table.ForeignKey(
                        name: "FK_JobOrdersTable_EmployeesTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeesTable",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOrdersTable_ProjectsTable_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectsTable",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployeesTable",
                columns: table => new
                {
                    ProjectEmployeesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
                    EmployeesTableEmployeeId = table.Column<int>(nullable: true),
                    ProjectsTableProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployeesTable", x => x.ProjectEmployeesId);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeesTable_EmployeesTable_EmployeesTableEmployeeId",
                        column: x => x.EmployeesTableEmployeeId,
                        principalTable: "EmployeesTable",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeesTable_ProjectsTable_ProjectsTableProjectId",
                        column: x => x.ProjectsTableProjectId,
                        principalTable: "ProjectsTable",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOrdersTable_EmployeeId",
                table: "JobOrdersTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrdersTable_ProjectId",
                table: "JobOrdersTable",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_EmployeesTableEmployeeId",
                table: "ProjectEmployeesTable",
                column: "EmployeesTableEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeesTable_ProjectsTableProjectId",
                table: "ProjectEmployeesTable",
                column: "ProjectsTableProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOrdersTable");

            migrationBuilder.DropTable(
                name: "ProjectEmployeesTable");

            migrationBuilder.DropTable(
                name: "EmployeesTable");

            migrationBuilder.DropTable(
                name: "ProjectsTable");
        }
    }
}
