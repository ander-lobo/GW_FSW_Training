using Gcsb.Connect.Training.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.UseCases.GetById
{
    public interface IGetByIdUseCase
    {
        void Execute(Guid Id);
    }
}
