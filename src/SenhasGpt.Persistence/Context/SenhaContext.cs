using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SenhasGpt.Persistence.Context;

public class SenhaContext : AbstractContext
{
    public SenhaContext(DbContextOptions<SenhaContext> options) : base(options) { }

    protected override Assembly GetConfigurationAssembly()
        => GetType().Assembly;

    protected override Func<Type, bool> GetConfigurationTypePredicate()
        => type => type.Namespace != null && type.Namespace.EndsWith("Mappings.Senha");
}

