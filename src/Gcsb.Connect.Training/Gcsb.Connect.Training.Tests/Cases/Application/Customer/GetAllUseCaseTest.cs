using FluentAssertions;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Application.UseCases.GetAll;
using Gcsb.Connect.Training.Tests.Builders;
using Gcsb.Connect.Training.Webapi.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.Training.Tests.Cases.Application.Customer
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.Connect.Training.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.Training.Tests")]
    public class GetAllUseCaseTest
    {
        private readonly IGetAllUseCase getAllUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository customerRepository;

        public GetAllUseCaseTest(IGetAllUseCase getAllUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.getAllUseCase = getAllUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Get All Customers")]
        public void ShouldExecute()
        {
            var idCustomer1 = Guid.NewGuid();
            var idCustomer2 = Guid.NewGuid();
            var idCustomer3 = Guid.NewGuid();
            var customer1 = CustomerBuilder.New().WithId(idCustomer1).WithCpf("12345678909").Build();
            var customer2 = CustomerBuilder.New().WithId(idCustomer2).WithCpf("12345678908").Build();
            var customer3 = CustomerBuilder.New().WithId(idCustomer3).WithCpf("12345678907").Build();
            customerRepository.AddCustomer(customer1);
            customerRepository.AddCustomer(customer2);
            customerRepository.AddCustomer(customer3);
            getAllUseCase.Execute();
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
