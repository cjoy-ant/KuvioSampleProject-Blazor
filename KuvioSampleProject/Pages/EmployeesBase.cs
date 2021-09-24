﻿using Microsoft.AspNetCore.Components;
using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KuvioSampleProject.Pages
{
    public class EmployeesBase : ComponentBase
    {
        public IEnumerable<KuvioSampleProject.Models.Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
            //LoadEmployees();
            //return base.OnInitializedAsync();
        }
        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(3000);
            KuvioSampleProject.Models.Employee e1 = new KuvioSampleProject.Models.Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Sam",
                LastName = "Antonio",
                Country = "United States of America",
                Birthday = new DateTime(1992, 01, 31),
                DateModified = new DateTime(2021, 09, 20)
            };
            KuvioSampleProject.Models.Employee e2 = new KuvioSampleProject.Models.Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Marcelina",
                LastName = "Santiago",
                Country = "Brazil",
                Birthday = new DateTime(1985, 07, 07),
                DateModified = new DateTime(2021, 09, 20)
            };

            Employees = new List<KuvioSampleProject.Models.Employee> { e1, e2 };
        }
    }
}