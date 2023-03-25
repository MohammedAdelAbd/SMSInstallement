using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class editClassesClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "classNmae",
                table: "tbClasses",
                newName: "className");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "className",
                table: "tbClasses",
                newName: "classNmae");
        }
    }
}
