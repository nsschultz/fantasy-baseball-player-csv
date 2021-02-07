using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.Common.Models;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for cleaning up the data to reduce chances of errors.</summary>
    public class DataCleanerService : IDataCleanerService
    {
        /// <summary>Cleans up the data to prevent errors.</summary>
        /// <param name="players">All of the players to clean.</param>
        /// <returns>The "cleaned" collection of players.</returns>
        public List<BaseballPlayer> CleanData(List<BaseballPlayer> players) => players.Where(p => p != null).Select(CleanPlayer).ToList();

        private static BaseballPlayer CleanPlayer(BaseballPlayer player)
        {
            player.CombinedBattingStats = player.CombinedBattingStats == null ? new BattingStats() : player.CombinedBattingStats;
            player.CombinedPitchingStats = player.CombinedPitchingStats == null ? new PitchingStats() : player.CombinedPitchingStats;
            player.ProjectedBattingStats = player.ProjectedBattingStats == null ? new BattingStats() : player.ProjectedBattingStats;
            player.ProjectedPitchingStats = player.ProjectedPitchingStats == null ? new PitchingStats() : player.ProjectedPitchingStats;
            player.YearToDateBattingStats = player.YearToDateBattingStats == null ? new BattingStats() : player.YearToDateBattingStats;
            player.YearToDatePitchingStats = player.YearToDatePitchingStats == null ? new PitchingStats() : player.YearToDatePitchingStats;
            return player;
        }
    }
}