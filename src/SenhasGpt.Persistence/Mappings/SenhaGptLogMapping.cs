using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SenhasGpt.Domain.Entidade;

namespace SenhasGpt.Persistence.Mappings.Senha;

public class SenhaGptLogConfiguration : IEntityTypeConfiguration<SenhaGptLog>
{
    public void Configure(EntityTypeBuilder<SenhaGptLog> builder)
    {
        builder.ToTable("SenhaGptLog");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Data).HasColumnName("Data").HasColumnType("datetime");
        builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(s => s.Log).HasColumnName("Log").HasColumnType("varchar").HasMaxLength(600);
    }
}

