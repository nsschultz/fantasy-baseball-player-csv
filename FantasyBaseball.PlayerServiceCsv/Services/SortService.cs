using System.Collections.Generic;
using System.Linq;
using FantasyBaseball.CommonModels.Player;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for sorting the players.</summary>
    public class SortService : ISortService
    {
        /// <summary>Sorts the collection of players.</summary>
        /// <param name="players">All of the players to sort.</param>
        /// <returns>The sorted collection of players.</returns>
        public List<BaseballPlayer> SortPlayers(List<BaseballPlayer> players) => 
            players
                .OrderBy(p => p.PlayerInfo.Type)
                .ThenBy(p => p.PlayerInfo.LastName.ToUpper())
                .ThenBy(p => p.PlayerInfo.FirstName.ToUpper())
                .ThenBy(p => p.PlayerInfo.Id)
                .ToList();
    }
}