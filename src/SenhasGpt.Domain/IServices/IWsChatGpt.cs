using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Domain.IServices;

public interface IWsChatGpt
{
    Task<string> ObterPalavrasSimilares(string palavraChave);
    void InjetarComfiguracao(SenhaGptConfiguracao config);
}
