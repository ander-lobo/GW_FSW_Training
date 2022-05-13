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
            builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CustomerPresenter>()
                .As<IOutputPort<List<Customer>>>()
                .As<IOutputPort<Customer>>()
                .As<IOutputPort<string>>()
                .AsImplementedInterfaces().InstancePerLifetimeScope().AsSelf();
        }
    }
}
