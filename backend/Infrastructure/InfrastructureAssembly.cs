using System.Reflection;

namespace Infrastructure;

public static class InfrastructureAssembly
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
