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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            try
            {
                return Ok(await customerRepository.GetCustomers()); // Ok derived from ControllerBase
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriveing data from the database");
            }
        }

        [HttpGet("{id:Guid}")] // adds id parameter onto the route /api/customers/{id}
        public async Task<ActionResult<Customer>> GetCustomer(Guid id)
        {
            try
            {
                var result = await customerRepository.GetCustomer(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error posting data to the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest();
                }

                var createdCustomer = await customerRepository.AddCustomer(customer);

                return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Guid id, Customer customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    return BadRequest("Customer ID mismatch");
                }
                var customerToUpdate = await customerRepository.GetCustomer(id);

                if (customerToUpdate == null)
                {
                    return NotFound($"Customer with Id = {id} not found");
                }
                return await customerRepository.UpdateCustomer(customer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }
    }
}
