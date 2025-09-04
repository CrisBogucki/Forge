using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Forge.Core.Mediator.Tests")]

namespace Forge.Core.Mediator;

public static class AssemblyInfo
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}