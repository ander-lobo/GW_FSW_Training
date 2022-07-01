using FluentAssertions;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Application.UseCases.Delete;
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
    public class DeleteUseCaseTest
    {
        private readonly IDeleteUseCase deleteUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository customerRepository;

        public DeleteUseCaseTest(IDeleteUseCase deleteUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.deleteUseCase = deleteUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact(DisplayName = "Should Delete Customer")]
        public void ShouldExecute()
        {
            var cpf = "56789012345";
            var customer = CustomerBuilder.New().WithCpf(cpf).Build();
            customerRepository.AddCustomer(customer);
            deleteUseCase.Execute(cpf);
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
