using Gcsb.Connect.Training.Application.Boundaries;
using Gcsb.Connect.Training.Application.Interfaces;
using Gcsb.Connect.Training.Application.Repositories.Database;
using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases
{
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly ICustomerRepository repository;
        private readonly IOutputPort<List<Customer>> outputPort;
        public GetAllUseCase(ICustomerRepository repository, IOutputPort<List<Customer>> outputPort)
        {
            this.repository = repository;
            this.outputPort = outputPort;
        }

        public void Execute()
        {
            var result = repository.GetCustomers();
            if (result != null)
            {
                outputPort.Standard(result);
            } else
            {
                outputPort.NotFound("Nenhum cliente encontrado!");
            }
        }
    }
}
