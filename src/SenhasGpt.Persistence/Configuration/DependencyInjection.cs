using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SenhasGpt.Persistence.Repositories;
using Senha.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using SenhasGpt.Persistence.Context;
using SenhasGpt.Domain.IRepository;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SenhasGpt.Persistence.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<SenhaContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SenhaConnection"));
#if DEBUG
            var loggerFactory = new LoggerFactory().AddSerilog(Log.Logger);
            options.UseLoggerFactory(loggerFactory);
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
#endif
        }).RegisterRepositories();

    public static IServiceCollection RegisterRepositories(this IServiceCollection services) =>
        services.AddScoped<ISenhaGptConfiguracaoRepository, SenhaGptConfiguracaoRepository>()
                .AddScoped<ISenhaRepository, SenhaRepository>()
                .AddScoped<ISenhaGptLogRepository, SenhaGptLogRepository>();
}
