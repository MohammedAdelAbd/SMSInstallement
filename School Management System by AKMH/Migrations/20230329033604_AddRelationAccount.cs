using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class AddRelationAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsActive",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
