using Autofac.Extensions.DependencyInjection;
using Gcsb.Connect.Training.Webapi;
using Serilog;


namespace Gcsb.Connect.Training.Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}


//var builder = WebApplication.CreateBuilder(args);
//var startup = new Startup(builder.Configuration);

//startup.ConfigureServices(builder.Services);
//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.UseSerilog();

//var app = builder.Build();

//startup.Configure(app, app.Environment);

//app.Run();