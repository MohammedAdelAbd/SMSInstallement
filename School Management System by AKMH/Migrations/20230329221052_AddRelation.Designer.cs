using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using School_Management_System_by_AKMH;

namespace School_Management_System_by_AKMH.Migrations
{
    [DbContext(typeof(DbSchool))]
    [Migration("20230329221052_AddRelation")]
    partial class AddRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School_Management_System_by_AKMH.tbAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountTypeId");

                    b.Property<decimal>("Balance");

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActived");

                    b.Property<DateTime>("LastModifiedDate");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("School_Management_System_by_AKMH.tbAccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");
                });

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

            modelBuilder.Entity("School_Management_System_by_AKMH.tbAccount", b =>
                {
                    b.HasOne("School_Management_System_by_AKMH.tbAccountType", "AccountType")
                        .WithMany("Accounts")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
