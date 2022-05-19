using FluentAssertions;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Tests.Builders;
using Gcsb.Connect.Training.Tests.TestCaseOrdering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.Training.Tests.Cases.Infrastructure
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.Connect.Training.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.Training.Tests")]
    public class CustomerRepositoryTest
    {
        private readonly ICustomerRepository customerRepository;
        private static Guid idCustomer;
        private static string cpf;
        public CustomerRepositoryTest(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Create New Customer")]
        [TestPriority(1)]
        public void ShouldCreateNewCustomer()
        {
            idCustomer = Guid.NewGuid();
            var customer = CustomerBuilder.New().WithId(idCustomer).Build();
            customerRepository.AddCustomer(customer);
            var result = customerRepository.GetCustomersById(customer.Id);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should Create Customer With Cpf")]
        [TestPriority(1)]
        public void ShouldCreateCustomerWithCpf()
        {
            cpf = "12345654321";
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();
            customerRepository.AddCustomer(customer);
            var result = customerRepository.GetCustomersByCpf(cpf);
            result.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should Update Customer")]
        [TestPriority(2)]
        public void ShouldUpdateCustomer()
        {
            var customer = CustomerBuilder.New().WithId(idCustomer).WithName("Updated Customer").Build();
            customerRepository.UpdateCustomer(customer);
            var result = customerRepository.GetCustomersById(customer.Id);
            result.Name.Should().Match("Updated Customer");
        }

        [Fact(DisplayName = "Should Get All Customers")]
        [TestPriority(3)]
        public void ShouldGetAllCustomers()
        {
            var customers = customerRepository.GetCustomers();
            customers.Should().HaveCountGreaterThan(1);
        }

        [Fact(DisplayName = "Should Get Customer By Id")]
        [TestPriority(3)]
        public void ShouldGetCustomerById()
        {
            var customer = customerRepository.GetCustomersById(idCustomer);
            customer.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should Get Customer By Cpf")]
        [TestPriority(3)]
        public void ShouldGetCustomerByCpf()
        {
            var customer = customerRepository.GetCustomersByCpf(cpf);
            customer.Should().NotBeNull();
        }

        [Fact(DisplayName = "Should Delete Customer")]
        [TestPriority(4)]
        public void ShouldDeleteCustomer()
        {
            var customer = customerRepository.GetCustomersByCpf(cpf);
            customerRepository.DeleteCustomer(customer);
            var result = customerRepository.GetCustomersById(customer.Id);
            result.Should().BeNull();
        }
    }
}
