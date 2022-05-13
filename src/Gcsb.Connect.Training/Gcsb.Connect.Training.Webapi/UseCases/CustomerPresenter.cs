using Gcsb.Connect.Training.Application.Boundaries;
using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Webapi.UseCases.Customers.Response;
using Microsoft.AspNetCore.Mvc;

namespace Gcsb.Connect.Training.Webapi.UseCases
{
    public class CustomerPresenter : IOutputPort<List<Customer>>, IOutputPort<Customer>, IOutputPort<string>
    {
        public IActionResult Result { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = message
            };

            Result = new BadRequestObjectResult(problemDetails);
        }

        public void NotFound(string message)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = message
            };

            Result = new NotFoundObjectResult(problemDetails);
        }

        public void Standard(List<Customer> result)
        {
            var response = new List<CustomerResponse>();

            result.ForEach(c => response.Add(new CustomerResponse(c.Id, c.Name, c.BirthDate, c.Rg, c.Cpf, c.Address, c.City, c.State, c.PostalCode, c.RegistrationDate, c.IsActive)));

            Result = new OkObjectResult(response);
        }
            

        public void Standard(Customer result)
        {
            var response = new CustomerResponse(result.Id, result.Name, result.BirthDate, result.Rg, result.Cpf, result.Address, result.City, result.State, result.PostalCode, result.RegistrationDate, result.IsActive);
            Result = new OkObjectResult(response);
        }

        public void Standard(string result) => Result = new OkObjectResult(result);
    }
}
