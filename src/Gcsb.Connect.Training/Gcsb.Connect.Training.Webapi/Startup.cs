using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Gcsb.Connect.Pkg.Startup.Webapi.DependencyInjection;
using Gcsb.Connect.Pkg.Startup.Webapi.Resources;
using Gcsb.Connect.Training.Webapi.DependencyInjection;
using Gcsb.Connect.Training.Webapi.Pipeline;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace Gcsb.Connect.Training.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
            builder.AddAutofacRegistration();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => 
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Treinamento", Version = "v1" });
                });
            services.AddLocalization();
            services.AddVersioning();
            services.AddProblemDetails();
            services.AddCustomFilters();
            services.Cors();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.MapControllers();
            IServiceProvider serviceProvider = app.Services.GetRequiredService<IServiceProvider>();
            var resources = serviceProvider.GetService<IStringLocalizer<ReturnMessages>>();
            this.AutofacContainer = serviceProvider.GetAutofacRoot();

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ErrorHandlerMiddleware(environment, resources).Invoke
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.AddLocalization();
            app.UseCors();
            app.UseProblemDetails();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(e => e.MapControllers());
            app.AddOptions();
        }
    }
}
