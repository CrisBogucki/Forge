using Forge.Core.Logger.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Forge.Core.Logger.Tests.Abstractions
{
    public class ForgeLoggerTests
    {
        [Fact]
        public void Log_CallsAllSinks()
        {
            // Arrange
            var mockSink1 = new Mock<ILogSink>();
            var mockSink2 = new Mock<ILogSink>();
            var logger = new ForgeLogger([mockSink1.Object, mockSink2.Object]);

            // Act
            logger.Log(LogLevel.Information, "Test message");

            // Assert
            mockSink1.Verify(s => s.Write(LogLevel.Information, "Test message", null), Times.Once());
            mockSink2.Verify(s => s.Write(LogLevel.Information, "Test message", null), Times.Once());
        }

        [Fact]
        public void Dispose_CallsDisposeOnSinksOnlyOnce()
        {
            // Arrange
            var mockSink = new Mock<ILogSink>();
            var logger = new ForgeLogger([mockSink.Object]);

            // Act
            logger.Dispose();
            logger.Dispose();

            // Assert
            mockSink.Verify(s => s.Dispose(), Times.Once());
        }
    }
}