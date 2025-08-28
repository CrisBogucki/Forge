using Forge.Core.Logger.Abstractions;
using Moq;

namespace Forge.Core.Logger.Tests.Abstractions
{
    public class ForgeLoggerProviderTests
    {
        [Fact]
        public void CreateLogger_ReturnsAdapter()
        {
            var sink = new Mock<List<ILogSink>>();
            var realLogger = new ForgeLogger(sink.Object);
            var provider = new ForgeLoggerProvider(realLogger);

            var adapter = provider.CreateLogger("Category");

            Assert.NotNull(adapter);
            Assert.IsType<ForgeLoggerAdapter>(adapter);
        }
    }
}

