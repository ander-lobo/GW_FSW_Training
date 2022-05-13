using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.Training.Application.Boundaries
{
    public interface IOutputPort<T>
    {
        void Standard(T result);
        void Error(string message);
        void NotFound(string message);
    }
}
