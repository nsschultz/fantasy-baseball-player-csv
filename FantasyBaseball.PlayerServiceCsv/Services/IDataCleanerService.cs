using System.Collections.Generic;
using FantasyBaseball.Common.Models;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for cleaning up the data to reduce chances of errors.</summary>
    public interface IDataCleanerService
    {
        /// <summary>Cleans up the data to prevent errors.</summary>
        /// <param name="players">All of the players to clean.</param>
        /// <returns>The "cleaned" collection of players.</returns>
        List<BaseballPlayer> CleanData(List<BaseballPlayer> players);
    }
}