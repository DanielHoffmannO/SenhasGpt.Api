using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Domain.IApplication;
public interface ISenhaGptRepository
{
    Task<SenhaGpt> CriarNovaSenha(string PalavraChave);
}
