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

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        //private static Guid ToGuid(int value)
        //{
        //    byte[] bytes = new byte[16];
        //    BitConverter.GetBytes(value).CopyTo(bytes, 0);
        //    return new Guid(bytes);
        //}
        protected async Task HandleDelete(Guid id)
        {
            var employeeToDelete = await EmployeeService.GetEmployee(id);
            var idToDelete = employeeToDelete.Id;
            await EmployeeService.DeleteEmployee(idToDelete);
            NavigationManager.NavigateTo("/employees", true);
        }
    }
}
