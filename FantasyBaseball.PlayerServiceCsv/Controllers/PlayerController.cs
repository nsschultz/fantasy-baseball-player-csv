using FantasyBaseball.CommonModels.Exceptions;
using FantasyBaseball.CommonModels.Player;
using FantasyBaseball.PlayerServiceCsv.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FantasyBaseball.PlayerServiceCsv.Controllers
{
    /// <summary>Endpoint for retrieving player data.</summary>
    [Route("api/player")] [ApiController] public class PlayerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICsvFileReaderService _readerService;
        private readonly IDataCleanerService _cleanService;
        private readonly ISortService _sortService;
        private readonly ICsvFileWriterService _writerService;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="readerService">The service for reading the CSV file.</param>
        /// <param name="writerService">The service for writting the CSV file.</param>
        /// <param name="configuration">The configuration for the application.</param>
        /// <param name="sortService">The service for sorting the players.</param>
        /// <param name="cleanService">The service for cleaning up the data to reduce chances of errors.</param>
        public PlayerController(ICsvFileReaderService readerService, 
                                ICsvFileWriterService writerService, 
                                IConfiguration configuration, 
                                ISortService sortService,
                                IDataCleanerService cleanService)
        {
            _readerService = readerService;
            _writerService = writerService;
            _configuration = configuration;
            _sortService = sortService;
            _cleanService = cleanService;
        }

        /// <summary>Gets all of the players from the source.</summary>
        /// <returns>All of the players from the source.</returns>
        [HttpGet] public PlayerCollection GetPlayers() => 
            new PlayerCollection { Players = _readerService.ReadCsvData(_configuration.GetValue<string>("CsvFiles:PlayerFile")) };

        /// <summary>Upserts all of the players into the source.</summary>
        /// <param name="players">All of the players to upsert into the source.</param>
        [HttpPost] public void UpsertPlayers(PlayerCollection players)
        {
            if (players == null || players.Players ==  null) throw new BadRequestException("Players not set");
            var playerList = _cleanService.CleanData(players.Players);
            playerList = _sortService.SortPlayers(playerList);
            _writerService.WriteCsvData(_configuration.GetValue<string>("CsvFiles:PlayerFile"), playerList);
        }
    }
}