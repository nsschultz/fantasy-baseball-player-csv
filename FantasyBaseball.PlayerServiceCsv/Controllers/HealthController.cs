using FantasyBaseball.CommonModels.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace FantasyBaseball.PlayerServiceCsv.Controllers
{
    /// <summary>Endpoint for checking the health of the service.</summary>
    [Route("api/health")] [ApiController] public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IFileProvider _provider;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="configuration">The configuration for the application.</param>
        public HealthController(IConfiguration configuration, IFileProvider provider) 
        {
             _configuration = configuration;
             _provider = provider;
        }
        
        /// <summary>Ensures that the system has access stats files.</summary>
        [HttpGet] public void GetHealth() 
        {
            if (!_provider.GetFileInfo(_configuration.GetValue<string>("CsvFiles:PlayerFile")).Exists) throw new CsvFileException("Player File Doesn't Exist");
        }
    }
}