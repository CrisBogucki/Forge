using Forge.Core.Logger.Abstractions;
using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Features.Sinks.ConsoleSink;

public class ConsoleSink(ConsoleSinkOptions? options = null) : ILogSink
{
    private readonly ConsoleSinkOptions _options = options ?? new ConsoleSinkOptions();

    public void Write(LogLevel level, string message, Exception? exception = null)
    {
        var timestamp = DateTime.Now.ToString(_options.TimestampFormat);
        
        var levelStr = _options.ShortenLevel
            ? level.ToString().ToUpperInvariant().Substring(0, 3)
            : level.ToString();
        
        var formatted = _options.Template
            .Replace("{Timestamp}", timestamp)
            .Replace("{Level}", levelStr)
            .Replace("{Message}", message);

        if (_options.UseColors)
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = GetColor(level);
            Console.WriteLine(formatted);
            
            if (exception != null) 
                Console.WriteLine(exception);
            
            Console.ForegroundColor = original;
        }
        else
        {
            Console.WriteLine(formatted);
            
            if (exception != null) 
                Console.WriteLine(exception);
        }
    }

    private static ConsoleColor GetColor(LogLevel level) => level switch
    {
        LogLevel.Trace => ConsoleColor.White,
        LogLevel.Debug => ConsoleColor.White,
        LogLevel.Information => ConsoleColor.Black,
        LogLevel.Warning => ConsoleColor.Yellow,
        LogLevel.Error => ConsoleColor.DarkRed,
        LogLevel.Critical => ConsoleColor.DarkRed,
        _ => Console.ForegroundColor
    };

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
