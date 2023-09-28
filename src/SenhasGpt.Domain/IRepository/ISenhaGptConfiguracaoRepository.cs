using Microsoft.EntityFrameworkCore;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Domain.IRepository;
public interface ISenhaGptConfiguracaoRepository : IRepository<SenhaGptConfiguracao, short>
{
    SenhaGptConfiguracao ObterConfiguracaoVigente();
    SenhaGptConfiguracao ObterUltimaConfiguracao();
    bool Salvar(SenhaGptConfiguracao config);
    bool Atualizar(SenhaGptConfiguracao config);
}
