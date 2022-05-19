using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Webapi.UseCases;
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
        private static Guid Id;

        public UpdateUseCaseTest(IUpdateUseCase updateUseCase, CustomerPresenter presenter, ICustomerRepository customerRepository)
        {
            this.updateUseCase = updateUseCase;
            this.presenter = presenter;
            this.customerRepository = customerRepository;
        }


    }
}
