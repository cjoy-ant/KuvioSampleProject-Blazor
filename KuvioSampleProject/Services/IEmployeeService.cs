using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(Guid id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
    }
}
