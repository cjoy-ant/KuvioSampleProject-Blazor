﻿using KuvioSampleProject.Models;
using KuvioSampleProject.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Pages
{
    public class EmployeeFormBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee();
        
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(Guid.Parse(Id));      
        }
    }
}