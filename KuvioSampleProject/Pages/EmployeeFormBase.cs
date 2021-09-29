using KuvioSampleProject.Models;
using KuvioSampleProject.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace KuvioSampleProject.Pages
{
    public class EmployeeFormBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager {get; set;}

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (Guid.Parse(Id) != Guid.Empty)
            {
                Employee = await EmployeeService.GetEmployee(Guid.Parse(Id));
            }
            else
            {
                Employee = new Employee
                {
                    Id = Guid.Empty,
                    Country = "BRA",
                    Birthday = DateTime.Now,
                    DateModified = DateTime.Now
                };
            }
        }

        protected async Task HandleSubmit() 
        {
            Employee result = null;

            if(Employee.Id != Guid.Empty)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/employees");
            }
        }
    }
}
