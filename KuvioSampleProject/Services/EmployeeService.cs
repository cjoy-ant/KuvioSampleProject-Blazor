using KuvioSampleProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KuvioSampleProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            var responseMessage = await httpClient.PutAsJsonAsync<Employee>($"api/employees/{updatedEmployee.Id}", updatedEmployee);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Employee>(content);
            return result;
        }
    }
}
