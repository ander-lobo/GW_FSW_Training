using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases.Add
{
    public interface IAddUseCase
    {
        void Execute(Customer customer);
    }
}
