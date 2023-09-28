using SenhasGpt.Domain.Entidade;
using SenhasGpt.Domain.Model;

namespace SenhasGpt.Domain.IApplication;
public interface IConfiguracaoService
{
    SenhaGptConfiguracao ObterConfiguracao();
    short AdicionarConfiguracao(SenhaGptConfiguracaoModel model);
    void AtualizarConfiguracao(short id, SenhaGptConfiguracaoModel model);
}
