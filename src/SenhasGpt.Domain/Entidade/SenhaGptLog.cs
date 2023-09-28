using Microsoft.EntityFrameworkCore;

namespace SenhasGpt.Domain.Entidade;
public class SenhaGptLog : Entity<SenhaGptLog, short>
{
    public SenhaGptLog() { }
    public SenhaGptLog(string descricao, string log)
    {
        Log = log.Length <= 600 ? log : log[..600];
        Descricao = descricao.Length <= 50 ? descricao : descricao[..600];
        Data = DateTime.Now;
    }

    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public string Log { get; set; }
}