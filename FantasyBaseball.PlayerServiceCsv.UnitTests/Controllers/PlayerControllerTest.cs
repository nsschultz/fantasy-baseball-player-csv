using System.Collections.Generic;
using FantasyBaseball.CommonModels.Exceptions;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.PlayerServiceCsv.Controllers;
using FantasyBaseball.PlayerServiceCsv.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Controllers
{
    public class PlayerControllerTest
    {
        [Fact] public void GetPlayersTest() 
        {
            var returnData = new List<BaseballPlayer> { new BaseballPlayer() };
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("players.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PlayerFile")).Returns(section.Object);
            var service = new Mock<ICsvFileReaderService>();
            service.Setup(o => o.ReadCsvData("players.csv")).Returns(returnData);
            Assert.NotNull(new PlayerController(service.Object, null, config.Object, null, null).GetPlayers());
            service.VerifyAll();
        }

        [Fact] public void UpsertPlayersTest() 
        {
            var data = new PlayerCollection { Players = new List<BaseballPlayer> { new BaseballPlayer() } };
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("players.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PlayerFile")).Returns(section.Object);
            var cleanService = new Mock<IDataCleanerService>();
            cleanService.Setup(o => o.CleanData(It.Is<List<BaseballPlayer>>(p => p.Count == 1))).Returns(new List<BaseballPlayer> { new BaseballPlayer() });
            var sortService = new Mock<ISortService>();
            sortService.Setup(o => o.SortPlayers(It.Is<List<BaseballPlayer>>(p => p.Count == 1))).Returns(new List<BaseballPlayer> { new BaseballPlayer() });
            var service = new Mock<ICsvFileWriterService>();
            service.Setup(o => o.WriteCsvData("players.csv", It.Is<List<BaseballPlayer>>(p => p.Count == 1)));
            new PlayerController(null, service.Object, config.Object, sortService.Object, cleanService.Object).UpsertPlayers(data);
            service.VerifyAll();
        }

        [Fact] public void UpsertPlayersTestNullPlayerCollection() => 
            Assert.Throws<BadRequestException>(() => new PlayerController(null, null, null, null, null).UpsertPlayers(null));

        [Fact] public void UpsertPlayersTestNullPlayerList() => 
            Assert.Throws<BadRequestException>(() => 
                new PlayerController(null, null, null, null, null).UpsertPlayers(new PlayerCollection { Players = null }));
    }
}