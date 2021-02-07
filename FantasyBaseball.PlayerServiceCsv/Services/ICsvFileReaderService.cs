using System.Collections.Generic;
using FantasyBaseball.Common.Models;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for reading the CSV file.</summary>
    public interface ICsvFileReaderService
    {
        /// <summary>Reads in data from the given CSV file.</summary>
        /// <param name="fileName">The file name to process.</param>
        /// <returns>All of the data within the given file.</returns>
        List<BaseballPlayer> ReadCsvData(string fileName);
    }
}