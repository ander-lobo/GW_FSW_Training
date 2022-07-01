using Gcsb.Connect.Training.Application.Boundaries;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases.Update
{
    public class UpdateUseCase : IUpdateUseCase
    {
        private readonly ICustomerRepository repository;
        private readonly IOutputPort<string> outputPort;
        public UpdateUseCase(ICustomerRepository repository, IOutputPort<string> outputPort)
        {
            this.repository = repository;
            this.outputPort = outputPort;
        }

        public void Execute(Customer customer)
        {
            var verify = repository.GetCustomersById(customer.Id);
            if (verify != null)
            {
                repository.UpdateCustomer(customer);
                outputPort.Standard("Cliente atualizado com sucesso!");
            }
            else
            {
                outputPort.Error("Cliente com o Id: " + customer.Id + " não existente!");
            }
        }
    }
}
