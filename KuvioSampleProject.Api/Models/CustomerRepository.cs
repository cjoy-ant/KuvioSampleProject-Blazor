﻿using KuvioSampleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlDbContext sqlDbContext;

        public CustomerRepository(SqlDbContext sqlDbContext)
        {
            this.sqlDbContext = sqlDbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await sqlDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> AddCustomer(Customer project)
        {
            var result = await sqlDbContext.Customers.AddAsync(project);
            await sqlDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await sqlDbContext.Customers.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Customer> UpdateCustomer(Customer project)
        {
            var customerToUpdate = await sqlDbContext.Customers.FirstOrDefaultAsync(e => e.Id == project.Id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = project.Name;
                customerToUpdate.Phone = project.Phone;
                customerToUpdate.Email = project.Email;
                customerToUpdate.DateModified = DateTime.Now;

                await sqlDbContext.SaveChangesAsync();

                return customerToUpdate;
            }
            return null;
        }

        public async void DeleteCustomer(Guid id)
        {
            var customerToDelete = await sqlDbContext.Customers.FirstOrDefaultAsync(e => e.Id == id);
            if (customerToDelete != null)
            {
                sqlDbContext.Customers.Remove(customerToDelete);
                await sqlDbContext.SaveChangesAsync();
            }
        }

    }
}
