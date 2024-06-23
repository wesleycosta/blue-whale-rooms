using Orangotango.Rooms.Application;
using Orangotango.Rooms.Domain;
using Orangotango.Rooms.Infra;
using System.Collections.Generic;
using System.Reflection;

namespace Orangotango.Rooms.Api;

public static class AssemblyRegistry
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(ApplicationModule).Assembly;
        yield return typeof(DomainModule).Assembly;
        yield return typeof(InfraModule).Assembly;
    }
}
