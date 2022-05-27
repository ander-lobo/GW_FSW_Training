using FluentAssertions;
using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Application.Repositories.Database;
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
    public class GetByIdUseCaseTest
    {
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository customerRepository;

        public GetByIdUseCaseTest(IGetByIdUseCase getByIdUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.getByIdUseCase = getByIdUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Get Customer By Id")]
        public void ShouldExecute()
        {
            var idCustomer = Guid.NewGuid();
            var customer = CustomerBuilder.New().WithId(idCustomer).Build();
            customerRepository.AddCustomer(customer);
            getByIdUseCase.Execute(idCustomer);
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
