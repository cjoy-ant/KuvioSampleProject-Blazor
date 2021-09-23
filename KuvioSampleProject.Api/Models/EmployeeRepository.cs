using KuvioSampleProject.Data;
using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlDbContext sqlDbContext;

        public EmployeeRepository(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await sqlDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await sqlDbContext.Employees.AddAsync(employee);
            await sqlDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            return await sqlDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = await sqlDbContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Country = employee.Country;
                employeeToUpdate.Birthday = employee.Birthday;
                employeeToUpdate.DateModified = DateTime.Now;

                await sqlDbContext.SaveChangesAsync();

                return employeeToUpdate;
            }
            return null;
        }

        public async void DeleteEmployee(Guid id)
        {
            var employeeToDelete = await sqlDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employeeToDelete != null)
            {
                sqlDbContext.Employees.Remove(employeeToDelete);
                await sqlDbContext.SaveChangesAsync();
            }
        }
    }
}
