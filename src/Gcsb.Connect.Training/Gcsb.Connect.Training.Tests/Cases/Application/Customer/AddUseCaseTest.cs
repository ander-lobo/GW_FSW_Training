﻿using FluentAssertions;
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
    public class AddUseCaseTest
    {
        private readonly IAddUseCase addUseCase;
        private readonly CustomerPresenter presenter;

        public AddUseCaseTest(IAddUseCase addUseCase, CustomerPresenter presenter)
        {
            this.addUseCase = addUseCase;
            this.presenter = presenter;
        }

        [Fact(DisplayName = "Should Create Customer")]
        public void ShouldExecute()
        {
            var customer = CustomerBuilder.New().WithCpf("34567890123").Build();
            addUseCase.Execute(customer);
            presenter.Result.Should().BeOfType<OkObjectResult>();
        }
    }
}
