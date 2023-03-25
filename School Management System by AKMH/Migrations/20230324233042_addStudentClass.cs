using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class addStudentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbStudents",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dateBirth = table.Column<DateTime>(nullable: false),
                    dateRegistration = table.Column<DateTime>(nullable: false),
                    lastSchool = table.Column<string>(nullable: true),
                    stAddress = table.Column<string>(nullable: true),
                    stClass = table.Column<string>(nullable: true),
                    stDivision = table.Column<string>(nullable: true),
                    stGender = table.Column<string>(nullable: true),
                    stName = table.Column<string>(nullable: true),
                    stPhone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbStudents", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbStudents");
        }
    }
}
