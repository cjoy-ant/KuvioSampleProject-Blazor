using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Data
{
    interface IEmployeeService
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        void UpdateEmployee(Employee employee);

        void AddEmployee(Employee employee);

        void DeleteEmployee(Guid id);
    }
}
