using FluentAssertions;
using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Application.Repositories.Database;
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
        private static Guid Id;

        public GetAllUseCaseTest(IGetAllUseCase getAllUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.getAllUseCase = getAllUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }

        [Fact]
        public void ShouldExecute()
        {
            getAllUseCase.Execute();
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
