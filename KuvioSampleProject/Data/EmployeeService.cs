using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Data
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Sam",
                LastName = "Antonio",
                Country = "United States of America",
                Birthday = new DateTime(1992, 01, 31),
                DateModified = new DateTime(2021, 09, 20)
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                FirstName="Marcelina",
                LastName="Santiago",
                Country = "Brazil",
                Birthday = new DateTime(1985, 07, 07),
                DateModified = new DateTime(2021, 09, 20)
            },
        };

        public void AddEmployee(Employee employee)
        {
            var id = Guid.NewGuid();
            employee.Id = id;
            employees.Add(employee);
        }

        public void DeleteEmployee(Guid id)
        {
            var employee = GetEmployee(id);
            employees.Remove(employee);
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = GetEmployee(employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Country = employee.Country;
            employeeToUpdate.Birthday = employee.Birthday;
            employeeToUpdate.DateModified = DateTime.Now;
        }
    }
}
