using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTwo.Migrations
{
    /// <inheritdoc />
    public partial class Emp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentId);
                    table.UniqueConstraint("AK_departments_DepartmentName", x => x.DepartmentName);
                });

            migrationBuilder.CreateTable(
                name: "designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designations", x => x.DesignationId);
                    table.UniqueConstraint("AK_designations_DesignationName", x => x.DesignationName);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillId);
                    table.UniqueConstraint("AK_skills_SkillName", x => x.SkillName);
                });

            migrationBuilder.CreateTable(
                name: "employeePersons",
                columns: table => new
                {
                    EmployeePersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeePersons", x => x.EmployeePersonId);
                    table.ForeignKey(
                        name: "FK_employeePersons_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeePersons_designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeSkills",
                columns: table => new
                {
                    EmployeePersonId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeSkills", x => new { x.EmployeePersonId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_employeeSkills_employeePersons_EmployeePersonId",
                        column: x => x.EmployeePersonId,
                        principalTable: "employeePersons",
                        principalColumn: "EmployeePersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeSkills_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeePersons_DepartmentId",
                table: "employeePersons",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employeePersons_DesignationId",
                table: "employeePersons",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_employeeSkills_SkillId",
                table: "employeeSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeSkills");

            migrationBuilder.DropTable(
                name: "employeePersons");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "designations");
        }
    }
}
