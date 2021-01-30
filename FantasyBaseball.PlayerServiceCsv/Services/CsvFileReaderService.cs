using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using FantasyBaseball.Common.Exceptions;
using FantasyBaseball.Common.Models;
using FantasyBaseball.PlayerServiceCsv.CsvMaps;

namespace FantasyBaseball.PlayerServiceCsv.Services
{
    /// <summary>Service for reading the CSV file.</summary>
    public class CsvFileReaderService : ICsvFileReaderService
    {
        private readonly CsvConfiguration _configuration = new CsvConfiguration(CultureInfo.CurrentCulture);

        /// <summary>Creates a new instance and configures the service.</summary>
        public CsvFileReaderService() => _configuration.RegisterClassMap<BaseballPlayerMap>();

        /// <summary>Reads in data from the given CSV file.</summary>
        /// <param name="fileName">The file name to process.</param>
        /// <returns>All of the data within the given file.</returns>
        public List<BaseballPlayer> ReadCsvData(string fileName)
        {
            if (!File.Exists(fileName)) throw new CsvFileException($"Unable to load file: {fileName}");
            using var stream = new StreamReader(fileName);
            using var csv = new CsvReader(stream, _configuration);
            return csv.GetRecords<BaseballPlayer>().ToList(); 
        }
    }
}