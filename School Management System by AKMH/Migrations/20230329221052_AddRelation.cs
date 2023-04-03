using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class AddRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                table: "Accounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActived",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
