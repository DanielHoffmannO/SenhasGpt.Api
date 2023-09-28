using Microsoft.Extensions.DependencyInjection;
using SenhasGpt.Domain.Entidade;
using SenhasGpt.Domain.IApplication;
using SenhasGpt.Domain.IRepository;

namespace SenhasGpt.Application;
public class ConfiguracaoProvider : IConfiguracaoProvider
{
    private readonly IServiceProvider _serviceProvider;
    private SenhaGptConfiguracao SenhaGptConfiguracao { get; set; }
    public ConfiguracaoProvider(IServiceProvider repository)
    {
        _serviceProvider = repository;
        SenhaGptConfiguracao = ObterConfiguracaoRepository();
    }

    private SenhaGptConfiguracao ObterConfiguracaoRepository()
    {
        var ruleService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ISenhaGptConfiguracaoRepository>();
        return ruleService?.ObterConfiguracaoVigente() ?? new SenhaGptConfiguracao();
    }

    public SenhaGptConfiguracao ObterConfiguracao() => SenhaGptConfiguracao;

    public void RecarregarConfiguracao() => SenhaGptConfiguracao = ObterConfiguracaoRepository();
}
