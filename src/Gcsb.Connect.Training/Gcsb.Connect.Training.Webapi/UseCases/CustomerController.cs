using Gcsb.Connect.Training.Application.Repositories.Services;
using Gcsb.Connect.Training.Application.UseCases;
using Gcsb.Connect.Training.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.Training.Webapi.UseCases
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<CustomerResponse>> Get()
        {
            var customers = _customerService.GetCustomers();
            if(customers == null)
            {
                return NotFound("Nenhum cliente encontrado.");
            }
            return Ok(customers);
        }

        /// <summary>
        /// Get Customer By Id
        /// </summary>
        [HttpGet("search/{Id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerResponse> Get(Guid Id)
        {
            var customer = _customerService.GetCustomersById(Id);
            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(customer);
        }

        /// <summary>
        /// Get Customer By Cpf
        /// </summary>
        [HttpGet("{cpf}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerResponse> Get(string cpf)
        {
            var customer = _customerService.GetCustomersByCpf(cpf);
            if (customer == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(customer);
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] CustomerDTO customer)
        {
            var verify = _customerService.GetCustomersByCpf(customer.Cpf);
            if (verify != null)
            {
                return BadRequest("Cliente já registrado.");
            }
            _customerService.AddCustomer(customer);
            return Ok(customer);
        }

        /// <summary>
        /// Update Customer
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put([FromBody] EditCustomerDTO customer)
        {
            var verify = _customerService.GetCustomersById(customer.Id);
            if (verify == null)
            {
                return BadRequest();
            }
            _customerService.UpdateCustomer(customer, verify);
            return Ok(customer);
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        [HttpDelete("cpf")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string cpf)
        {
            var verify = _customerService.GetCustomersByCpf(cpf);
            if (verify == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            _customerService.DeleteCustomer(verify);
            return NoContent();
        }

    }
}
