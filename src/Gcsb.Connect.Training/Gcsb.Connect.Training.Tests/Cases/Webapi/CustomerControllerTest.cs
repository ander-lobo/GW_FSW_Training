using FluentAssertions;
using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Tests.Builders;
using Gcsb.Connect.Training.Tests.TestCaseOrdering;
using Gcsb.Connect.Training.Webapi.UseCases;
using Gcsb.Connect.Training.Webapi.UseCases.Customers.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Gcsb.Connect.Training.Tests.Cases.Webapi
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Gcsb.Connect.Training.Tests.TestCaseOrdering.PriorityOrderer", "Gcsb.Connect.Training.Tests")]
    public class CustomerControllerTest
    {
        private readonly IAddUseCase addUseCase;
        private readonly IGetAllUseCase getAllUseCase;
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly IGetByCpfUseCase getByCpfUseCase;
        private readonly IUpdateUseCase updateUseCase;
        private readonly IDeleteUseCase deleteUseCase;
        private readonly CustomerPresenter presenter;
        private readonly ICustomerRepository repository;
        private static Guid customerId;
        private static string cpf;

        public CustomerControllerTest(IAddUseCase addUseCase, IGetAllUseCase getAllUseCase, IGetByIdUseCase getByIdUseCase, 
            IGetByCpfUseCase getByCpfUseCase, IUpdateUseCase updateUseCase, IDeleteUseCase deleteUseCase, 
            CustomerPresenter presenter, ICustomerRepository repository)
        {
            this.addUseCase = addUseCase;
            this.getAllUseCase = getAllUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.getByCpfUseCase = getByCpfUseCase;
            this.updateUseCase = updateUseCase;
            this.deleteUseCase = deleteUseCase;
            this.presenter = presenter;
            this.repository = repository;
        }

        [Fact(DisplayName = "Should Add Customers And Get All")]
        [TestPriority(1)]
        public void ShouldAddManyCustomersAndGetAll()
        {
            customerId = Guid.NewGuid();
            cpf = "98765432100";
            var customer1 = CustomerBuilder.New().WithId(customerId).Build();
            var customer2 = CustomerBuilder.New().WithCpf(cpf).Build();
            repository.AddCustomer(customer1);
            repository.AddCustomer(customer2);
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.GetAll();
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact(DisplayName = "Should Create A New Customer")]
        [TestPriority(1)]
        public void ShouldAddCustomer()
        {
            var customer = new CustomerRequest()
            {
                Name = "José Severino",
                BirthDate = "03/03/1993",
                Rg = "14725836",
                Cpf = "67890123456",
                Address = "Avenida dos Carros, 73",
                City = "Cuiabá",
                State = "MT",
                PostalCode = 78005005
            };
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.Add(customer);
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact(DisplayName = "Should Get Customer By Id")]
        [TestPriority(2)]
        public void ShouldGetCustomerById()
        {
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.GetById(customerId);
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact(DisplayName = "Should Get Customer By Cpf")]
        [TestPriority(2)]
        public void ShouldGetCustomerByCpf()
        {
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.GetByCpf(cpf);
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact(DisplayName = "Should Update Customer")]
        [TestPriority(3)]
        public void ShouldUpdateCustomer()
        {
            var customer = new UpdateCustomerRequest()
            {
                Id = customerId,
                Name = "João Severino",
                BirthDate = "03/03/1993",
                Rg = "14725836",
                Cpf = "12345678901",
                Address = "Avenida das Motos, 73",
                City = "Rondonópolis",
                State = "MT",
                PostalCode = 78700005
            };
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.Update(customer);
            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact(DisplayName = "Should Delete Customer")]
        [TestPriority(4)]
        public void ShouldDeleteCustomer()
        {
            var controller = new CustomerController(getAllUseCase, getByIdUseCase, getByCpfUseCase, addUseCase, 
                updateUseCase, deleteUseCase, presenter);
            controller.ControllerContext.HttpContext = HttpContextBuilder.New().Build();
            var response = controller.Delete(cpf);
            response.Should().BeOfType<OkObjectResult>();
        }
    }
}
