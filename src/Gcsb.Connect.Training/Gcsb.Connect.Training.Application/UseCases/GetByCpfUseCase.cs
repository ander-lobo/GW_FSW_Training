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
    public class GetByCpfUseCase : IGetByCpfUseCase
    {
        private readonly ICustomerRepository repository;
        private readonly IOutputPort<Customer> outputPort;
        public GetByCpfUseCase(ICustomerRepository repository, IOutputPort<Customer> outputPort)
        {
            this.repository = repository;
            this.outputPort = outputPort;
        }

        public void Execute(string Cpf)
        {
            var result = repository.GetCustomersByCpf(Cpf);
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
