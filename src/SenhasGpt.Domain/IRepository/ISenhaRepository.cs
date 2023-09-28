using Microsoft.EntityFrameworkCore;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Domain.IRepository;
public interface ISenhaRepository : IRepository<SenhaGpt, short>
{
    bool Salvar(SenhaGpt senhaGpt);
}
