using Gcsb.Connect.Training.Application.UseCases;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.Repositories.Database
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomersById(Guid? Id);
        Customer GetCustomersByCpf(string Cpf);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer, Customer verify);
        void DeleteCustomer(Customer customer);
    }
}
