using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("Forge.Core.Logger.Tests")]

namespace Forge.Core.Logger;

public static class AssemblyInfo
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}