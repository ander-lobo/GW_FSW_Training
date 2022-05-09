using Gcsb.Connect.Training.Application.UseCases;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.Repositories.Services
{
    public interface ICustomerService
    {
        List<CustomerResponse> GetCustomers();
        CustomerResponse GetCustomersById(Guid? Id);
        CustomerResponse GetCustomersByCpf(string Cpf);
        void AddCustomer(CustomerDTO customer);
        void UpdateCustomer(EditCustomerDTO customer, CustomerResponse verify);
        void DeleteCustomer(CustomerResponse customer);
    }
}
