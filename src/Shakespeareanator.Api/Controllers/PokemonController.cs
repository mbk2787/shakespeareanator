namespace Shakespeareanator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Shakespeareanator.Services;
    using Shakespeareanator.Services.Models;
    using System;
    using System.Diagnostics;

    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        #region Constants

        private const string GetPokemonDescriptionByNameRoute = "{name}";

        #endregion

        #region Fields

        private readonly IShakespeareanatorService shakespeareanatorService;

        private readonly IMemoryCache memoryCache;

        private readonly ILogger<PokemonController> logger;

        private readonly IConfiguration configuration;

        #endregion

        public PokemonController(IShakespeareanatorService shakespeareanatorService, IMemoryCache memoryCache, ILogger<PokemonController> logger, IConfiguration configuration)
        {
            this.shakespeareanatorService = shakespeareanatorService;
            this.memoryCache = memoryCache;
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet(GetPokemonDescriptionByNameRoute)]
        public IActionResult Get(string name)
        {
            // retrieve current activity id for correlation id
            var correlationId = Activity.Current?.RootId;

            logger.LogInformation($"Getting pokemon translation for '{name}'. [{correlationId}]");

            // Try to get translation value from cache
            if (!memoryCache.TryGetValue(name, out ShakespeareanatorResult result))
            {
                // Get pokemon translated description
                result = shakespeareanatorService.GetShakespeareanPokemonDescription(name);

                // Set cache
                memoryCache.Set(name, result, TimeSpan.FromHours(1));

                logger.LogInformation($"Added '{name}' translation to the cache.");
            }

            logger.LogInformation($"Translation for '{name}' pokemon successfully retrieved.");

            return Ok(result);
        }
    }
}