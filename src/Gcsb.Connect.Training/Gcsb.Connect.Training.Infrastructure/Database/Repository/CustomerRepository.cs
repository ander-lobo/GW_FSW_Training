using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gcsb.Connect.Training.Application.UseCases;

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

        public void AddCustomer(Customer customer)
        {
            using var context = new Context();
            context.Add(mapper.Map<Entities.Customer>(customer));
            context.SaveChanges();
        }
        public void UpdateCustomer(Customer customer, Customer verify)
        {
            using var context = new Context();
            var cep = verify.PostalCode;
            if(customer.PostalCode != verify.PostalCode) { cep = customer.PostalCode; };
            Entities.Customer edit = new()
            {
                Id = customer.Id,
                Name = string.IsNullOrEmpty(customer.Name) ? verify.Name : customer.Name,
                BirthDate = string.IsNullOrEmpty(customer.BirthDate) ? verify.BirthDate : customer.BirthDate,
                Rg = string.IsNullOrEmpty(customer.Rg) ? verify.Rg : customer.Rg,
                Cpf = verify.Cpf,
                Address = string.IsNullOrEmpty(customer.Address) ? verify.Address : customer.Address,
                City = string.IsNullOrEmpty(customer.City) ? verify.City : customer.City,
                State = string.IsNullOrEmpty(customer.State) ? verify.State : customer.State,
                PostalCode = cep,
                RegistrationDate = verify.RegistrationDate,
                IsActive = verify.IsActive
            };
            var mapped = mapper.Map<Entities.Customer>(edit);
            context.Update(mapped);
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
