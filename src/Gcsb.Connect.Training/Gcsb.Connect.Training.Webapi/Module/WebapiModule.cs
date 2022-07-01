using Autofac;
using Gcsb.Connect.Training.Application.Boundaries;
using Gcsb.Connect.Training.Domain.Entities;
using Gcsb.Connect.Training.Webapi.UseCases;

namespace Gcsb.Connect.Training.Webapi.Module
{
    public class WebapiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerPresenter>().AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
        }
    }
}
