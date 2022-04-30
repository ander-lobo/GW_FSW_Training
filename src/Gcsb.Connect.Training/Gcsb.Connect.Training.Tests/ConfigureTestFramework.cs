using Autofac;
using Gcsb.Connect.Training.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Frameworks.Autofac;

[assembly: TestCollectionOrderer("Gcsb.Connect.Training.Tests.TestCaseOrdering", "Gcsb.Connect.Training.Tests")]
[assembly: CollectionBehavior(DisableTestParallelization = true)]
[assembly: TestFramework("Gcsb.Connect.Training.Tests.ConfigureTestFramework", "Gcsb.Connect.Training.Tests")]

namespace Gcsb.Connect.Training.Tests
{
    public class ConfigureTestFramework : AutofacTestFramework
    {
        public ConfigureTestFramework(IMessageSink diagnosticMessageSink) : base(diagnosticMessageSink)
        {

        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
            //builder.RegisterModule<WebapiModule>();

            SetMockedDependencies(builder);
        }

        private static void SetMockedDependencies(ContainerBuilder builder)
        {
            //builder.RegisterInstance(new GetInvoicesMock().GetInvoices().Object).As<IGetInvoices>();
        }
    }
}
