using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace School_Management_System_by_AKMH.Migrations
{
    public partial class AcountMovementTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAccountMovement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsReconciled = table.Column<bool>(nullable: false),
                    ReconciledBy = table.Column<string>(nullable: true),
                    ReconciledDate = table.Column<DateTime>(nullable: true),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAccountMovement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbAccountMovement_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAccountMovement_tbStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbStudents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAccountMovement_AccountId",
                table: "tbAccountMovement",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAccountMovement_StudentId",
                table: "tbAccountMovement",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAccountMovement");
        }
    }
}
