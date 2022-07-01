using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gcsb.Connect.Pkg.Serilog.Implementation;
using Gcsb.Connect.Pkg.Startup.Webapi.DependencyInjection;
using Gcsb.Connect.Pkg.Startup.Webapi.Resources;
using Gcsb.Connect.Training.Webapi.DependencyInjection;
using Gcsb.Connect.Training.Webapi.Pipeline;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.UseSerilog();
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.AddAutofacRegistration());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Training",
        Version = "v1"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddJwtToken();
builder.Services.AddLocalization();
builder.Services.AddVersioning();
builder.Services.AddProblemDetails();
builder.Services.AddCustomFilters();
builder.Services.Cors();

var app = builder.Build();
var resources = ((IApplicationBuilder)app).ApplicationServices.GetService<IStringLocalizer<ReturnMessages>>();
var env = app.Services.GetRequiredService<IWebHostEnvironment>();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (env.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new ErrorHandlerMiddleware(env, resources).Invoke
});
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseMiddleware<LogRequestMiddleware>();
app.AddLocalization();
app.UseCors();
app.UseProblemDetails();
app.UseVersionedSwagger(provider);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(e => e.MapControllers());
app.AddOptions();

app.Run();