using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using School_Management_System_by_AKMH;

namespace School_Management_System_by_AKMH.Migrations
{
    [DbContext(typeof(DbSchool))]
    partial class DbSchoolModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School_Management_System_by_AKMH.tbClasses", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("className");

                    b.Property<int>("price");

                    b.HasKey("id");

                    b.ToTable("tbClasses");
                });

            modelBuilder.Entity("School_Management_System_by_AKMH.tbDivision", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("divisionName");

                    b.HasKey("id");

                    b.ToTable("tbDivisions");
                });

            modelBuilder.Entity("School_Management_System_by_AKMH.tbStudents", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateBirth");

                    b.Property<DateTime>("dateRegistration");

                    b.Property<string>("lastSchool");

                    b.Property<string>("stAddress");

                    b.Property<string>("stClass");

                    b.Property<string>("stDivision");

                    b.Property<string>("stGender");

                    b.Property<string>("stName");

                    b.Property<int>("stPhone");

                    b.HasKey("id");

                    b.ToTable("tbStudents");
                });
        }
    }
}
