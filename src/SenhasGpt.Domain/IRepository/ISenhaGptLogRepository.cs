using Microsoft.EntityFrameworkCore;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Domain.IRepository;
public interface ISenhaGptLogRepository : IRepository<SenhaGptLog, short>
{
    void SalvarLista(List<SenhaGptLog> senhaGptLog);
}
