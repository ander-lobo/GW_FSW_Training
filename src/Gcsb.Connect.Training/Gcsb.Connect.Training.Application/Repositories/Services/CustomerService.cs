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
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
            var result = await _customerRepository.GetCustomers();
            return _mapper.Map<List<CustomerDTO>>(result);
        }

        public async Task<CustomerDTO> GetCustomersById(Guid? Id)
        {
            var result = await _customerRepository.GetCustomersById(Id);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<CustomerDTO> GetCustomersByName(string Name)
        {
            var result = await _customerRepository.GetCustomersByName(Name);
            return _mapper.Map<CustomerDTO>(result);
        }

        public async Task<CustomerDTO> GetCustomersByCpf(string Cpf)
        {
            var result = await _customerRepository.GetCustomersByCpf(Cpf);
            return _mapper.Map<CustomerDTO>(result);
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var mapCustomer = _mapper.Map<Customer>(customer);
            _customerRepository.AddCustomer(mapCustomer);
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            var mapCustomer = _mapper.Map<Customer>(customer);
            _customerRepository.UpdateCustomer(mapCustomer);
        }

        public void DeleteCustomer(string Cpf)
        {
            var customer = _customerRepository.GetCustomersByCpf(Cpf).Result;
            _customerRepository.DeleteCustomer(customer);
        }
    }
}
