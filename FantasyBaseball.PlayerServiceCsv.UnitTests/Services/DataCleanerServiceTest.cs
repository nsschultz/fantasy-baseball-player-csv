using System.Collections.Generic;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.PlayerServiceCsv.Services;
using Xunit;

namespace FantasyBaseball.PlayerServiceCsv.UnitTests.Services
{
    public class DataCleanerServiceTest
    {
        [Fact] public void CleanTest()
        {
            var playerList = new List<BaseballPlayer>
            {
                null,
                new BaseballPlayer { PlayerInfo = null },
                new BaseballPlayer { 
                    BhqScores = null,
                    CombinedBattingStats = null,
                    CombinedPitchingStats = null,
                    DraftInfo = null,
                    LeagueInfo = null,
                    ProjectedBattingStats = null,
                    ProjectedPitchingStats = null,
                    YearToDateBattingStats = null,
                    YearToDatePitchingStats = null
                },
                new BaseballPlayer()
            };
            var cleanedList = new DataCleanerService().CleanData(playerList);
            Assert.Equal(2, cleanedList.Count);
            Assert.NotNull(cleanedList[0].BhqScores);
            Assert.NotNull(cleanedList[0].CombinedBattingStats);
            Assert.NotNull(cleanedList[0].CombinedPitchingStats);
            Assert.NotNull(cleanedList[0].DraftInfo);
            Assert.NotNull(cleanedList[0].LeagueInfo);
            Assert.NotNull(cleanedList[0].ProjectedBattingStats);
            Assert.NotNull(cleanedList[0].ProjectedPitchingStats);
            Assert.NotNull(cleanedList[0].YearToDateBattingStats);
            Assert.NotNull(cleanedList[0].YearToDatePitchingStats);
            Assert.NotNull(cleanedList[1].BhqScores);
            Assert.NotNull(cleanedList[1].CombinedBattingStats);
            Assert.NotNull(cleanedList[1].CombinedPitchingStats);
            Assert.NotNull(cleanedList[1].DraftInfo);
            Assert.NotNull(cleanedList[1].LeagueInfo);
            Assert.NotNull(cleanedList[1].ProjectedBattingStats);
            Assert.NotNull(cleanedList[1].ProjectedPitchingStats);
            Assert.NotNull(cleanedList[1].YearToDateBattingStats);
            Assert.NotNull(cleanedList[1].YearToDatePitchingStats);
        }
    }
}