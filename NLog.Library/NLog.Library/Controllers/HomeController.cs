using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NLog.Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_logger.LogDebug(1, "NLog injected into HomeController");
        }
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            //_logger.LogInformation("Hello, this is GetApi Log!");
            int x = 0;
            int y = 0;
            try
            {
                int result = x / y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hata");
                return BadRequest();

            }

            return NoContent();
        }
        [HttpPost("[action]")]
        public IActionResult Post()
        {
            int x = 0;
            int y = 0;
            try
            {
                int result = x / y;
                // Burada POST isteğiyle ilgili işlemler yapılır
                throw new Exception("An error occurred while processing the POST request");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in Post action for POST request");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
