using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class modiStudeSt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statee",
                table: "tbStudents",
                newName: "State");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "tbStudents",
                newName: "Statee");
        }
    }
}
