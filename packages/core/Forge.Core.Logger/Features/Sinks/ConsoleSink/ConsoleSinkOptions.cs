namespace Forge.Core.Logger.Features.Sinks.ConsoleSink;

public class ConsoleSinkOptions
{
    public bool UseColors { get; init; } = true;
    public string TimestampFormat { get; init; } = "HH:mm:ss";
    public string Template { get; init; } = "{Timestamp} [{Level}] {Message}";
    public bool ShortenLevel { get; init; } = false;
}