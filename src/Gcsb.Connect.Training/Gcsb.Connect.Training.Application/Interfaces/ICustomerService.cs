using Gcsb.Connect.Training.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.Repositories.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomersById(Guid? Id);
        Task<CustomerDTO> GetCustomersByName(string Name);
        Task<CustomerDTO> GetCustomersByCpf(string Cpf);
        void AddCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(Guid Id);
    }
}
