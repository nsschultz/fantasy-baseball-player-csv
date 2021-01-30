using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerServiceCsv.CsvMaps;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for writing the CSV file.</summary>
    public class CsvFileWriterService : ICsvFileWriterService
    {
        private readonly CsvConfiguration _configuration = new CsvConfiguration(CultureInfo.CurrentCulture);

        /// <summary>Creates a new instance and configures the service.</summary>
        public CsvFileWriterService() => _configuration.RegisterClassMap<BaseballPlayerMap>();

        /// <summary>Reads in data from the given CSV file.</summary>
        /// <param name="fileName">The file name to process.</param>
        /// <param name="players">All of the players to upsert into the source.</param>
        public void WriteCsvData(string fileName, List<BaseballPlayer> players)
        {
            if (!File.Exists(fileName)) throw new CsvFileException($"Unable to load file: {fileName}");
            using var writer = new StreamWriter(fileName);
            using var csv = new CsvWriter(writer, _configuration); 
            csv.WriteRecords(players);
        }
    }
}