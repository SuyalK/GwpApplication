using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gwp.Business;
using Gwp.Model;

namespace GwpApplication.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly ILogger<CountryGwpController> _logger;
        private readonly IGwpCalculation _gwpCalculation;

        public CountryGwpController(ILogger<CountryGwpController> logger, IGwpCalculation gwpCalculation)
        {
            _logger = logger;
            _gwpCalculation = gwpCalculation;
        }

        [HttpPost]
        [Route("server/api/gwp/avg")]
        public IActionResult CalculateAverageGwp(CalculateAverageGwpRequest calculateAverageGwpRequest)
        {
            try
            {
                var lobAverageGwp = _gwpCalculation.CalculateAverageGwp(calculateAverageGwpRequest.Country, calculateAverageGwpRequest.LineOfBusinesses);

                return Ok(lobAverageGwp);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
