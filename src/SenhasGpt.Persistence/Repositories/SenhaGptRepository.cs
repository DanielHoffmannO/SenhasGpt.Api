using Microsoft.EntityFrameworkCore;
using SenhasGpt.Persistence.Context;
using SenhasGpt.Domain.IRepository;
using SenhasGpt.Domain.Entidade;

namespace Senha.Persistence.Repositories;

public class SenhaRepository : Repository<SenhaGpt, short>, ISenhaRepository
{
    public SenhaRepository(SenhaContext context) : base(context)
    {
    }

    public bool Salvar(SenhaGpt senhaGpt)
    {
        Db.Add(senhaGpt);
        return Db.Commit();
    }
}
