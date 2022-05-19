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
        Customer GetCustomersById(Guid id);
        Customer GetCustomersByCpf(string cpf);
        Guid AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
