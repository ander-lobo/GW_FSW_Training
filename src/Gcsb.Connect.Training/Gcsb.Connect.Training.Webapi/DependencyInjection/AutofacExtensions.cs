using Autofac;
using Gcsb.Connect.Training.Infrastructure.Modules;
using Gcsb.Connect.Training.Webapi.Module;

namespace Gcsb.Connect.Training.Webapi.DependencyInjection
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder AddAutofacRegistration(this ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<WebapiModule>();

            return builder;
        }
    }
}
