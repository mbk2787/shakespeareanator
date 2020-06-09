namespace Shakespeareanator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class PokemonController : Controller
    {
        #region Fields

        private readonly ILogger<PokemonController> logger;

        private readonly IConfiguration configuration;

        #endregion

        public PokemonController(ILogger<PokemonController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}