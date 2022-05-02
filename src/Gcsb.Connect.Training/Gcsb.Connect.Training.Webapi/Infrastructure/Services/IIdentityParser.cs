using System.Security.Principal;

namespace Gcsb.Connect.Training.Webapi.Infrastructure.Services
{
    public interface IIdentityParser<T>
    {
        T Parse(IPrincipal principal);
    }
}
