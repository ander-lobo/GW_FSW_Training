using FluentAssertions;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Application.UseCases.GetByCpf;
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
    public class GetByCpfUseCaseTest
    {
        private readonly IGetByCpfUseCase getByCpfUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository customerRepository;

        public GetByCpfUseCaseTest(IGetByCpfUseCase getByCpfUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.getByCpfUseCase = getByCpfUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Get Customer By Cpf")]
        public void ShouldExecute()
        {
            var cpf = "23456789012";
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();
            customerRepository.AddCustomer(customer);
            getByCpfUseCase.Execute(cpf);
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
