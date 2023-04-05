using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class addTbVactation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbVacations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<string>(nullable: true),
                    Division = table.Column<string>(nullable: true),
                    Expiry = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    sid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbVacations_tbStudents_sid",
                        column: x => x.sid,
                        principalTable: "tbStudents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbVacations_sid",
                table: "tbVacations",
                column: "sid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbVacations");
        }
    }
}
