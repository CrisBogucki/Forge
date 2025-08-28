using Forge.Core.Logger.Features.Sinks;

namespace Forge.Core.Logger.Options;

public class ForgeLoggerOptions
{
    public ForgeLoggerSinksOptions Sinks { get; set; } = new();
}