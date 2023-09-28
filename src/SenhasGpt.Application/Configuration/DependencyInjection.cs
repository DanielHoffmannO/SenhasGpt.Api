using Microsoft.Extensions.DependencyInjection;
using SenhasGpt.Domain.IApplication;

namespace SenhasGpt.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
        => services.AddScoped<ISenhaGptRepository, SenhaService>()
                   .AddScoped<IConfiguracaoService, ConfiguracaoService>()
                   .AddSingleton<IConfiguracaoProvider, ConfiguracaoProvider>();
}
