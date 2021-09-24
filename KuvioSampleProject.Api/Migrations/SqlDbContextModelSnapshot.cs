﻿// <auto-generated />
using System;
using KuvioSampleProject.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KuvioSampleProject.Api.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KuvioSampleProject.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("592b899e-1fc9-411b-8324-8c09ebf64a3d"),
                            Birthday = new DateTime(1992, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "United States of America",
                            DateModified = new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sam",
                            LastName = "Antonio"
                        },
                        new
                        {
                            Id = new Guid("d71c511e-f367-42fe-ac64-018626790563"),
                            Birthday = new DateTime(1985, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Brazil",
                            DateModified = new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marcelina",
                            LastName = "Santiago"
                        });
                });

            modelBuilder.Entity("KuvioSampleProject.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<Guid>("Customer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5960690c-cce8-4e68-a4f1-0d769be764e9"),
                            Complete = false,
                            Customer = new Guid("e910cc8c-ebca-4ce4-aa96-8d65a2efca88"),
                            DateModified = new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description of Project 1",
                            Title = "Project 1"
                        },
                        new
                        {
                            Id = new Guid("2c496acb-abe6-42ca-be7c-4b2c290f639d"),
                            Complete = false,
                            Customer = new Guid("1d1601f2-e9bd-4e5b-b00e-bfac342ea14e"),
                            DateModified = new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description of Project 2",
                            Title = "Project 2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
