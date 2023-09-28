using Microsoft.EntityFrameworkCore;
using SenhasGpt.Persistence.Context;
using SenhasGpt.Domain.IRepository;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Persistence.Repositories;

public class SenhaGptLogRepository : Repository<SenhaGptLog, short>, ISenhaGptLogRepository
{
    public SenhaGptLogRepository(SenhaContext context) : base(context)
    {
    }

    public void SalvarLista(List<SenhaGptLog> senhaGptLog)
    {
        Db.AddRange(senhaGptLog);
        Db.Commit();
    }
}