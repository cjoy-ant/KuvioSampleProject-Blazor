using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KuvioSampleProject.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Birthday", "Country", "DateModified", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("23c3ce94-eb63-4fc8-ab27-c3a1f5c6acd1"), new DateTime(1992, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States of America", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", "Antonio" },
                    { new Guid("a1035ae7-c837-4869-8d5d-90871560389f"), new DateTime(1985, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelina", "Santiago" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Complete", "Customer", "DateModified", "Deadline", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("2fab4c45-b71e-4e35-b754-a0b463c71505"), false, new Guid("a618c751-20f4-4b15-b619-68651c43c2b2"), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project 1", "Project 1" },
                    { new Guid("84f880b5-a565-4a0f-846a-f038c94aac48"), false, new Guid("da4a62c7-00a7-42d1-bbff-1ef0abcea02e"), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project 2", "Project 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
