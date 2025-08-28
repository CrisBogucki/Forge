using Forge.Core.Logger.Abstractions;
using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Tests;

public class ForgeLoggerIntegrationTests
{
    [Theory]
    [MemberData(nameof(LoggerTestData))]
    public void Logger_LogsCorrectlyForMinLevel(LogLevel minLevel, bool logError, bool logWarning, bool logInfo, bool logDebug)
    {
        // Arrange
        var sink = new TestSink();
        var logger = new ForgeLogger([sink]);
        var adapter = new ForgeLoggerAdapter(logger, "TestCategory");

        // Act
        if (minLevel <= LogLevel.Error) adapter.Log(LogLevel.Error, "Error");
        if (minLevel <= LogLevel.Warning) adapter.Log(LogLevel.Warning, "Warning");
        if (minLevel <= LogLevel.Information) adapter.Log(LogLevel.Information, "Info");
        if (minLevel <= LogLevel.Debug) adapter.Log(LogLevel.Debug, "Debug");

        // Assert
        Assert.Equal(logError, sink.Logs.Any(l => l.Level == LogLevel.Error));
        Assert.Equal(logWarning, sink.Logs.Any(l => l.Level == LogLevel.Warning));
        Assert.Equal(logInfo, sink.Logs.Any(l => l.Level == LogLevel.Information));
        Assert.Equal(logDebug, sink.Logs.Any(l => l.Level == LogLevel.Debug));
    }

    private class TestSink : ILogSink
    {
        public List<(LogLevel Level, string Message)> Logs = new();

        public void Write(LogLevel level, string message, Exception? exception = null)
        {
            Logs.Add((level, message));
        }

        public void Dispose()
        { }
    }
    
    public static IEnumerable<object[]> LoggerTestData =>
        new List<object[]>
        {
            new object[] { LogLevel.Error, true, false, false, false },
            new object[] { LogLevel.Warning, true, true, false, false },
            new object[] { LogLevel.Information, true, true, true, false },
            new object[] { LogLevel.Debug, true, true, true, true },
        };
}

