using Forge.Core.Logger.Features.Sinks.ConsoleSink;
using Microsoft.Extensions.Logging;

namespace Forge.Core.Logger.Tests.Features.Sinks.ConsoleSink
{
    public class ConsoleSinkTests
    {
        [Fact]
        public void Write_PrintsMessageWithoutException()
        {
            // Arrange
            var sink = new Logger.Features.Sinks.ConsoleSink.ConsoleSink(new ConsoleSinkOptions
            {
                UseColors = false,
                ShortenLevel = true,
                Template = "{Level}: {Message}"
            });

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            sink.Write(LogLevel.Information, "Hello");

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("INF: Hello", output);
        }


        [Fact]
        public void Write_PrintsMessageWithException()
        {
            // Arrange
            var sink = new Logger.Features.Sinks.ConsoleSink.ConsoleSink(new ConsoleSinkOptions
            {
                UseColors = false,
                ShortenLevel = true,
                Template = "{Level}: {Message}"
            });

            using var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Act
            sink.Write(LogLevel.Error, "Error occurred", new Exception("Test exception"));

            // Assert
            var output = consoleOutput.ToString();
            Assert.Contains("ERR: Error occurred", output);
            Assert.Contains("Test exception", output);
        }
    }
}