using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Gcsb.Connect.Training.Infrastructure.Database.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper mapper;

        public CustomerRepository(IMapper mapper) 
        { 
            this.mapper = mapper;
        }

        public List<Customer> GetCustomers()
        {
            using var context = new Context();
            var customers = context.Customers.ToList();
            return mapper.Map<List<Customer>>(customers);
        }

        public Customer GetCustomersById(Guid? Id)
        {
            using var context = new Context();
            var customer = context.Customers.Find(Id);
            return mapper.Map<Customer>(customer);
        }

        public Customer GetCustomersByCpf(string? Cpf)
        {
            using var context = new Context();
            var customer = context.Customers.FirstOrDefault(c => c.Cpf.Equals(Cpf));
            return mapper.Map<Customer>(customer);
        }

        public Guid AddCustomer(Customer customer)
        {
            using var context = new Context();
            context.Add(mapper.Map<Entities.Customer>(customer));
            context.SaveChanges();
            return customer.Id;
        }
        public void UpdateCustomer(Customer customer)
        {
            using var context = new Context();
            context.Update(mapper.Map<Entities.Customer>(customer));
            context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            using var context = new Context();
            context.Remove(mapper.Map<Entities.Customer>(customer));
            context.SaveChanges();
        }

    }
}
