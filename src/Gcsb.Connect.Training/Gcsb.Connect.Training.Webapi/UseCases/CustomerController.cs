using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Webapi.UseCases.Customers.Request;
using Gcsb.Connect.Training.Webapi.UseCases.Customers.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.Training.Webapi.UseCases
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGetAllUseCase getAllUseCase;
        private readonly IGetByIdUseCase getByIdUseCase;
        private readonly IGetByCpfUseCase getByCpfUseCase;
        private readonly IAddUseCase addUseCase;
        private readonly IUpdateUseCase updateUseCase;
        private readonly IDeleteUseCase deleteUseCase;
        private readonly CustomerPresenter presenter;

        public CustomerController(IGetAllUseCase getAllUseCase, IGetByIdUseCase getByIdUseCase, IGetByCpfUseCase getByCpfUseCase, IAddUseCase addUseCase, IUpdateUseCase updateUseCase, IDeleteUseCase deleteUseCase, CustomerPresenter presenter)
        {
            this.getAllUseCase = getAllUseCase;
            this.getByIdUseCase = getByIdUseCase;
            this.getByCpfUseCase = getByCpfUseCase;
            this.addUseCase = addUseCase;
            this.updateUseCase = updateUseCase;
            this.deleteUseCase = deleteUseCase;
            this.presenter = presenter;
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<CustomerResponse>), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public IActionResult GetAll()
        {
            getAllUseCase.Execute();
            return presenter.Result;
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        [HttpGet("search/{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public IActionResult GetById(Guid Id)
        {
            getByIdUseCase.Execute(Id);
            return presenter.Result;
        }

        /// <summary>
        /// Get Customer By Cpf
        /// </summary>
        [HttpGet("{cpf}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerResponse), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public IActionResult GetByCpf(string cpf)
        {
            getByCpfUseCase.Execute(cpf);
            return presenter.Result;
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult Add([FromBody] CustomerRequest body)
        {
            Customer customer = new(body.Name, body.BirthDate, body.Rg, body.Cpf, body.Address, body.City, body.State, body.PostalCode);
            addUseCase.Execute(customer);
            return presenter.Result;
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 400)]
        public IActionResult Update([FromBody] UpdateCustomerRequest body)
        {
            Customer customer = new(body.Id, body.Name, body.BirthDate, body.Rg, body.Cpf, body.Address, body.City, body.State, body.PostalCode);
            updateUseCase.Execute(customer);
            return presenter.Result;
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        [HttpDelete("{cpf}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ProblemDetails), 404)]
        public IActionResult Delete(string cpf)
        {
            deleteUseCase.Execute(cpf);
            return presenter.Result;
        }

    }
}
