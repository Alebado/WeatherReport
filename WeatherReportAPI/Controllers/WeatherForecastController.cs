using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WeatherReportBL;
using WeatherReportBL.Interface;
using WeatherReportModel;

namespace WeatherReport.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> GetWeatherForecastAsync([FromQuery] float latitude, [FromQuery] float longitude)
        {
            return Ok(await _weatherService.GetWeatherForecastAsync(new Coordinates() { Latitude = latitude, Longitude = longitude}));
        }
    }
}