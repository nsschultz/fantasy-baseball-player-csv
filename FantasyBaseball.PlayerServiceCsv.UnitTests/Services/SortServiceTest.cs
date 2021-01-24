using System.Collections.Generic;
using FantasyBaseball.CommonModels.Enums;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.PlayerServiceCsv.Services;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Services
{
    public class SortServiceTest
    {
        [Fact] public void SortTest()
        {
            var playerList = new List<BaseballPlayer>
            {
                BuildPlayer(0, "first", "Laster", PlayerType.P),
                BuildPlayer(1, "first", "Last", PlayerType.P),
                BuildPlayer(2, "Firster", "last", PlayerType.B),
                BuildPlayer(3, "first", "Last", PlayerType.U),
                BuildPlayer(4, "first", "Last", PlayerType.B),
                BuildPlayer(5, "first", "Last", PlayerType.U)
            };
            var sortedList = new SortService().SortPlayers(playerList);
            Assert.Equal(3, sortedList[0].PlayerInfo.Id);
            Assert.Equal(5, sortedList[1].PlayerInfo.Id);
            Assert.Equal(4, sortedList[2].PlayerInfo.Id);
            Assert.Equal(2, sortedList[3].PlayerInfo.Id);
            Assert.Equal(1, sortedList[4].PlayerInfo.Id);
            Assert.Equal(0, sortedList[5].PlayerInfo.Id);
        }

        private static BaseballPlayer BuildPlayer(int id, string first, string last, PlayerType type) =>
            new BaseballPlayer { PlayerInfo = new PlayerInfo { Id = id, FirstName = first, LastName = last, Type = type } };
    }
}