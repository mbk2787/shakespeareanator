namespace Shakespeareanator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Shakespeareanator.Services;

    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        #region Constants

        private const string GetPokemonDescriptionByNameRoute = "{name}";

        #endregion

        #region Fields

        private readonly IShakespeareanatorService shakespeareanatorService;

        private readonly ILogger<PokemonController> logger;

        private readonly IConfiguration configuration;

        #endregion

        public PokemonController(IShakespeareanatorService shakespeareanatorService, ILogger<PokemonController> logger, IConfiguration configuration)
        {
            this.shakespeareanatorService = shakespeareanatorService;
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet(GetPokemonDescriptionByNameRoute)]
        public IActionResult Get(string name)
        {
            // Get pokemon translated description
            var result = shakespeareanatorService.GetShakespeareanPokemonDescription(name);

            return Ok(result);
        }
    }
}