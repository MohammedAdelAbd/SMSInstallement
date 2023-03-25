using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using School_Management_System_by_AKMH;

namespace School_Management_System_by_AKMH.Migrations
{
    [DbContext(typeof(DbSchool))]
    [Migration("20230324130501_addClassesClass")]
    partial class addClassesClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School_Management_System_by_AKMH.tbClasses", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("classNmae");

                    b.Property<int>("price");

                    b.HasKey("id");

                    b.ToTable("tbClasses");
                });
        }
    }
}
