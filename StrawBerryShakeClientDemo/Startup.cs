using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StrawBerryShakeClientDemo;
using StrawBerryShakeClientDemo.Models;
using StrawBerryShakeClientDemo.Services;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace StrawBerryShakeClientDemo;
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var executioncontextoptions = builder.Services.BuildServiceProvider()
                                   .GetService<IOptions<ExecutionContextOptions>>().Value;
        var currentDirectory = executioncontextoptions.AppDirectory;

        var configuration = new ConfigurationBuilder()
                       .SetBasePath(currentDirectory)
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .Build();

        builder.Services.Configure<GraphQLOptions>(options =>
        {
            options.Host = configuration.GetSection("ContentstackOptions")["Host"];
            options.ApiKey = configuration.GetSection("ContentstackOptions")["ApiKey"];
            options.DeliveryToken = configuration.GetSection("ContentstackOptions")["DeliveryToken"];
            options.Environment = configuration.GetSection("ContentstackOptions")["Environment"];
            options.Branch = configuration.GetSection("ContentstackOptions")["Branch"];
        });

        builder.Services.AddSingleton<HotChocolateClientFactory>();
    }
}
