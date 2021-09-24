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
                    { new Guid("592b899e-1fc9-411b-8324-8c09ebf64a3d"), new DateTime(1992, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States of America", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", "Antonio" },
                    { new Guid("d71c511e-f367-42fe-ac64-018626790563"), new DateTime(1985, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", new DateTime(2021, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcelina", "Santiago" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Complete", "Customer", "DateModified", "Deadline", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("5960690c-cce8-4e68-a4f1-0d769be764e9"), false, new Guid("e910cc8c-ebca-4ce4-aa96-8d65a2efca88"), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project 1", "Project 1" },
                    { new Guid("2c496acb-abe6-42ca-be7c-4b2c290f639d"), false, new Guid("1d1601f2-e9bd-4e5b-b00e-bfac342ea14e"), new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of Project 2", "Project 2" }
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
