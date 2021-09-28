using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KuvioSampleProject.Api.Models;
using KuvioSampleProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KuvioSampleProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees()); // Ok derived from ControllerBase
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        [HttpGet("{id:Guid}")] // adds id parameter onto the route /api/employees/{id}
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                var createdEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.Id}, createdEmployee); // saves location of createdEmployee in header
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                var employeeToUpdate = await employeeRepository.GetEmployee(employee.Id);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {employee.Id} not found");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(Guid id)
        {
            try
            {
                var employeeToDelete = await employeeRepository.DeleteEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }
                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error removing data in the database");
            }
        }
    }
}
