using Gcsb.Connect.Training.Application.Boundaries;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases.Add
{
    public class AddUseCase : IAddUseCase
    {
        private readonly ICustomerRepository repository;
        private readonly IOutputPort<string> outputPort;
        public AddUseCase(ICustomerRepository repository, IOutputPort<string> outputPort)
        {
            this.repository = repository;
            this.outputPort = outputPort;
        }

        public void Execute(Customer customer)
        {
            var verify = repository.GetCustomersByCpf(customer.Cpf);
            if (verify == null)
            {
                var response = repository.AddCustomer(customer);
                outputPort.Standard("Cliente registrado com sucesso com o Id: " + response);
            }
            else
            {
                outputPort.Error("Cliente já existente com o Id: " + verify.Id);
            }
        }
    }
}
