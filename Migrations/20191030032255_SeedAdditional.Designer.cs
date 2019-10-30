﻿// <auto-generated />
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191030032255_SeedAdditional")]
    partial class SeedAdditional
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 2,
                            Email = "jay.raj@gmail.com",
                            Name = "Jayaraj"
                        },
                        new
                        {
                            Id = 2,
                            Department = 3,
                            Email = "man.menon@gmail.com",
                            Name = "Manoj"
                        },
                        new
                        {
                            Id = 3,
                            Department = 2,
                            Email = "vip.panic@gmail.com",
                            Name = "Vipin"
                        },
                        new
                        {
                            Id = 4,
                            Department = 2,
                            Email = "anu.nair@gmail.com",
                            Name = "Anoop"
                        },
                        new
                        {
                            Id = 5,
                            Department = 1,
                            Email = "mithun.o@gmail.com",
                            Name = "Mithun"
                        },
                        new
                        {
                            Id = 6,
                            Department = 2,
                            Email = "masad.prani@gmail.com",
                            Name = "Prasad"
                        },
                        new
                        {
                            Id = 7,
                            Department = 2,
                            Email = "pri.ya@gmail.com",
                            Name = "Priya"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}