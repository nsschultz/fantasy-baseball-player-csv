using FantasyBaseball.Common.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.Controllers.UnitTests
{
    public class HealthControllerTest
    {
        [Fact] public void MissingPlayer() 
        {
            var playerSection = new Mock<IConfigurationSection>();
            playerSection.Setup(o => o.Value).Returns("players.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PlayerFile")).Returns(playerSection.Object);
            var fileInfo = new Mock<IFileInfo>();
            fileInfo.Setup(o => o.Exists).Returns(false);
            var provider = new Mock<IFileProvider>();
            provider.Setup(o => o.GetFileInfo("players.csv")).Returns(fileInfo.Object);
            var e = Assert.Throws<CsvFileException>(() => new HealthController(config.Object, provider.Object).GetHealth());
            Assert.Equal("Player File Doesn't Exist", e.Message);
        }

        [Fact] public void ValidFile() 
        {
            var playerSection = new Mock<IConfigurationSection>();
            playerSection.Setup(o => o.Value).Returns("players.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PlayerFile")).Returns(playerSection.Object);
            var fileInfo = new Mock<IFileInfo>();
            fileInfo.Setup(o => o.Exists).Returns(true);
            var provider = new Mock<IFileProvider>();
            provider.Setup(o => o.GetFileInfo("players.csv")).Returns(fileInfo.Object);
            new HealthController(config.Object, provider.Object).GetHealth();
            provider.VerifyAll();
        }
    }
}