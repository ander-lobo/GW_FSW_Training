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
    public class UpdateUseCaseTest
    {
        private readonly IUpdateUseCase updateUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository customerRepository;

        public UpdateUseCaseTest(IUpdateUseCase updateUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.updateUseCase = updateUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Update Customer")]
        public void ShouldExecute()
        {
            var id = Guid.NewGuid();
            var cpf = "45678901234";
            var customer = CustomerBuilder.New().WithId(id).WithCpf(cpf).Build();
            customerRepository.AddCustomer(customer);
            var updatedCustomer = CustomerBuilder.New().WithId(id).WithName("José das Nuvens").WithBirthDate("02/02/1992")
                .WithRg("23456789").WithCpf(cpf).WithAddress("Rua de Trás, 11").WithCity("Rio de Janeiro").WithState("RJ")
                .WithPostalCode(20000005).Build();
            updateUseCase.Execute(updatedCustomer);
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
