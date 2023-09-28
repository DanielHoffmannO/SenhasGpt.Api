using Microsoft.EntityFrameworkCore;
using SenhasGpt.Persistence.Context;
using SenhasGpt.Domain.IRepository;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Persistence.Repositories;

public class SenhaGptConfiguracaoRepository : Repository<SenhaGptConfiguracao, short>, ISenhaGptConfiguracaoRepository
{
    public SenhaGptConfiguracaoRepository(SenhaContext context) : base(context)
    {
    }

    public SenhaGptConfiguracao ObterConfiguracaoVigente() =>
        DbSet.FirstOrDefault(x => x.DataVigencia == null);

    public SenhaGptConfiguracao ObterUltimaConfiguracao() =>
        DbSet.OrderByDescending(x => x.Id).FirstOrDefault();

    public bool Salvar(SenhaGptConfiguracao config)
    {
        Db.Add(config);
        return Db.Commit();
    }

    public bool Atualizar(SenhaGptConfiguracao config)
    {
        Db.Update(config);
        return Db.Commit();
    }
}
