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
                Country = "USA",
                Birthday = "1992/01/31",
                Age="29",
                DateModified = "2021/09/20"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                FirstName="Marcelina",
                LastName="Santiago",
                Country = "PHL",
                Birthday ="1985/07/07",
                Age="36",
                DateModified="2021/09/20"
            },
        };

        public List<Employee> GetEmployees()
        {
            return employees;
        }

    }
}
