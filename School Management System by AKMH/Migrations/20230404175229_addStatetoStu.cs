using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class addStatetoStu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Statee",
                table: "tbStudents",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statee",
                table: "tbStudents");
        }
    }
}
