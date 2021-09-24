using KuvioSampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KuvioSampleProject.Api.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(Guid id);
        Task<Customer> AddCustomer(Customer project);
        Task<Customer> UpdateCustomer(Customer customer);
        void DeleteCustomer(Guid id);

    }
}
