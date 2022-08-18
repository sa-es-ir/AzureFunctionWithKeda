using System;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimerTriggerFunction;

[assembly: FunctionsStartup(typeof(Startup))]
namespace TimerTriggerFunction;

public class Startup : FunctionsStartup
{
    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        base.ConfigureAppConfiguration(builder);

        FunctionsHostBuilderContext context = builder.GetContext();

        builder.ConfigurationBuilder
            .AddJsonFile(Path.Combine(context.ApplicationRootPath, "appsettings.json"), optional: true, reloadOnChange: false)
            .AddJsonFile(Path.Combine(context.ApplicationRootPath, $"appsettings.{context.EnvironmentName}.json"), optional: true, reloadOnChange: false)
            .AddEnvironmentVariables();

        var configuration = builder.ConfigurationBuilder.Build();

        Console.WriteLine($"This is from app setting: {configuration["FunctionOption:Name"]}");
    }

    public override void Configure(IFunctionsHostBuilder builder)
    {
        //bind function option
        builder.Services.AddOptions<FunctionOption>()
            .Configure<IConfiguration>((settings, config) =>
            {
                config.GetSection("FunctionOption").Bind(settings);
            });
    }
}
