using BlazorCrudApplication.Client.Interfaces;
using BlazorCrudApplication.Client.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase  // Corrected the name here
    {
        private readonly IWeatherForecastService _weatherforecastService;
        public WeatherForecastController(IWeatherForecastService weatherforecastService)
        {
            _weatherforecastService = weatherforecastService;
        }

        // GET: api/WeatherForecast
        [HttpGet]
        public async Task<ActionResult<WeatherForecast[]>> Get()
        {
         var forecasts =  _weatherforecastService.GetWeatherForecastDetails();
            return Ok(forecasts);
        }
    }
}
