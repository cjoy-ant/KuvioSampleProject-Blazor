using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace KuvioSampleProject.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        //public DbSet<SqlDbContext> SQLDbContext { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed employee table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Sam",
                LastName = "Antonio",
                Country = "United States of America",
                Birthday = new DateTime(1992, 01, 31),
                DateModified = new DateTime(2021, 09, 20)
            }); ;

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Marcelina",
                LastName = "Santiago",
                Country = "Brazil",
                Birthday = new DateTime(1985, 07, 07),
                DateModified = new DateTime(2021, 09, 20)
            });

            // seed project table
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = Guid.NewGuid(),
                Title = "Project 1",
                Description = "Description of Project 1",
                Customer = Guid.NewGuid(),
                Deadline = new DateTime(2021, 10, 31),
                Complete = false,
                DateModified = new DateTime(2021, 09, 21)
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = Guid.NewGuid(),
                Title = "Project 2",
                Description = "Description of Project 2",
                Customer = Guid.NewGuid(),
                Deadline = new DateTime(2021, 11, 30),
                Complete = false,
                DateModified = new DateTime(2021, 09, 21)
            });

        }
    }
}
