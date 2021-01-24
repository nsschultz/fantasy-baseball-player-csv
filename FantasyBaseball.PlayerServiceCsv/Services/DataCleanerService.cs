using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.CommonModels.Stats;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for cleaning up the data to reduce chances of errors.</summary>
    public class DataCleanerService : IDataCleanerService
    {
        /// <summary>Cleans up the data to prevent errors.</summary>
        /// <param name="players">All of the players to clean.</param>
        /// <returns>The "cleaned" collection of players.</returns>
        public List<BaseballPlayer> CleanData(List<BaseballPlayer> players) =>
            players.Where(p => p != null).Where(p => p.PlayerInfo != null).Select(CleanPlayer).ToList();

        private static BaseballPlayer CleanPlayer(BaseballPlayer player)
        {
            player.BhqScores = player.BhqScores == null ? new BhqScores() : player.BhqScores;
            player.CombinedBattingStats = player.CombinedBattingStats == null ? new BattingStats() : player.CombinedBattingStats;
            player.CombinedPitchingStats = player.CombinedPitchingStats == null ? new PitchingStats() : player.CombinedPitchingStats;
            player.DraftInfo = player.DraftInfo == null ? new DraftInfo() : player.DraftInfo;
            player.LeagueInfo = player.LeagueInfo == null ? new LeagueInfo() : player.LeagueInfo;
            player.ProjectedBattingStats = player.ProjectedBattingStats == null ? new BattingStats() : player.ProjectedBattingStats;
            player.ProjectedPitchingStats = player.ProjectedPitchingStats == null ? new PitchingStats() : player.ProjectedPitchingStats;
            player.YearToDateBattingStats = player.YearToDateBattingStats == null ? new BattingStats() : player.YearToDateBattingStats;
            player.YearToDatePitchingStats = player.YearToDatePitchingStats == null ? new PitchingStats() : player.YearToDatePitchingStats;
            return player;
        }
    }
}