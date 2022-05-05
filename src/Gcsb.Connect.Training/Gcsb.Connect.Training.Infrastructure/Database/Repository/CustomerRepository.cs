using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Infrastructure.Database.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context) 
        { 
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomersById(Guid? Id)
        {
            return await _context.Customers.FindAsync(Id);
        }

        public async Task<Customer> GetCustomersByName(string? Name)
        {
            return await _context.Customers.FindAsync(Name);
        }

        public async Task<Customer> GetCustomersByCpf(string? Cpf)
        {
            return await _context.Customers.FindAsync(Cpf);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }

    }
}
