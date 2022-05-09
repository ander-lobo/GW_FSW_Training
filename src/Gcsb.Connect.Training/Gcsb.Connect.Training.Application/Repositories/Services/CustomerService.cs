using AutoMapper;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Application.UseCases;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.Repositories.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private readonly IMapper mapper;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            _customerRepository = customerRepository;
        }

        public List<CustomerResponse> GetCustomers()
        {
            var result = _customerRepository.GetCustomers();
            return mapper.Map<List<CustomerResponse>>(result);
        }

        public CustomerResponse GetCustomersById(Guid? Id)
        {
            var result = _customerRepository.GetCustomersById(Id);
            return mapper.Map<CustomerResponse>(result);
        }

        public CustomerResponse GetCustomersByCpf(string Cpf)
        {
            var result = _customerRepository.GetCustomersByCpf(Cpf);
            return mapper.Map<CustomerResponse>(result);
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var mapCustomer = mapper.Map<Customer>(customer);
            _customerRepository.AddCustomer(mapCustomer);
        }

        public void UpdateCustomer(EditCustomerDTO customer, CustomerResponse verify)
        {
            var mapCustomer = mapper.Map<Customer>(customer);
            var mapVerify = mapper.Map<Customer>(verify);
            _customerRepository.UpdateCustomer(mapCustomer, mapVerify);
        }

        public void DeleteCustomer(CustomerResponse customer)
        {
            var mapCustomer = mapper.Map<Customer>(customer);
            _customerRepository.DeleteCustomer(mapCustomer);
        }
    }
}
