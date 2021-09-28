using Microsoft.AspNetCore.Components;
using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KuvioSampleProject.Services;
using System.Linq;

namespace KuvioSampleProject.Pages
{
    public class EmployeesBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }
}
