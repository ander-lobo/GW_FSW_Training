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
    public class DeleteUseCase : IDeleteUseCase
    {
        private readonly ICustomerRepository repository;
        private readonly IOutputPort<string> outputPort;
        public DeleteUseCase(ICustomerRepository repository, IOutputPort<string> outputPort)
        {
            this.repository = repository;
            this.outputPort = outputPort;
        }

        public void Execute(string cpf)
        {
            var verify = repository.GetCustomersByCpf(cpf);
            if (verify != null)
            {
                repository.DeleteCustomer(verify);
                outputPort.Standard("Cliente apagado com sucesso!");
            }
            else
            {
                outputPort.NotFound("Nenhum cliente encontrado!");
            }
        }
    }
}
