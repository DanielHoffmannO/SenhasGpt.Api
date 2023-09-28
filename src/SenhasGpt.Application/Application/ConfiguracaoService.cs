using SenhasGpt.Domain.IApplication;
using SenhasGpt.Domain.IRepository;
using SenhasGpt.Domain.Exceptions;
using SenhasGpt.Domain.Entidade;
using Mapster;
using SenhasGpt.Domain.Model;

namespace SenhasGpt.Application;
public class ConfiguracaoService : IConfiguracaoService
{
    public readonly ISenhaGptConfiguracaoRepository _senhaGptConfiguracaoRepository;
    public readonly IConfiguracaoProvider _configuracaoProvider;
    public ConfiguracaoService(ISenhaGptConfiguracaoRepository senhaGptConfiguracaoRepository, IConfiguracaoProvider configuracaoProvider)
    {
        _senhaGptConfiguracaoRepository = senhaGptConfiguracaoRepository;
        _configuracaoProvider = configuracaoProvider;
    }

    public SenhaGptConfiguracao ObterConfiguracao() =>
        _configuracaoProvider.ObterConfiguracao();

    public short AdicionarConfiguracao(SenhaGptConfiguracaoModel model)
    {
        var Configuracao = model.Adapt<SenhaGptConfiguracao>();
        Configuracao.DataCadastro = DateTime.Now;

        FinalizarConfiguracaoAnterior();
        if (_senhaGptConfiguracaoRepository.Salvar(Configuracao))
        { 

            _configuracaoProvider.RecarregarConfiguracao();
            return _senhaGptConfiguracaoRepository.ObterUltimaConfiguracao()?.Id ?? 0;
        }
        throw new SqlException("Erro ao salvar informação no banco.");
    }

    public void AtualizarConfiguracao(short id, SenhaGptConfiguracaoModel model)
    {
        var Configuracao = _senhaGptConfiguracaoRepository.GetById(id) ?? throw new SqlException("Filme nao encontrado.");

        Configuracao.Atualizar(model.EmailCadastro, model.ChaveAcesso, model.UrlBase);
        _senhaGptConfiguracaoRepository.Atualizar(Configuracao);
        _configuracaoProvider.RecarregarConfiguracao();
    }

    private void FinalizarConfiguracaoAnterior()
    {
        var Configuracao = _senhaGptConfiguracaoRepository.ObterUltimaConfiguracao();
        if (Configuracao is not null)
        {
            Configuracao.DataVigencia = DateTime.Now;
            _senhaGptConfiguracaoRepository.Atualizar(Configuracao);
        }
    }
}
