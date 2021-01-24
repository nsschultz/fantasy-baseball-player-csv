using System.Collections.Generic;
using FantasyBaseball.CommonModels.Player;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for writing the CSV file.</summary>
    public interface ICsvFileWriterService
    {
        /// <summary>Reads in data from the given CSV file.</summary>
        /// <param name="fileName">The file name to process.</param>
        /// <param name="players">All of the players to upsert into the source.</param>
        void WriteCsvData(string fileName, List<BaseballPlayer> players);
    }
}