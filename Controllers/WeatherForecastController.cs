using Microsoft.AspNetCore.Mvc;
using WeatherForecastApi.Models;
using WeatherForecastApi.Services;

namespace WeatherForecastApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private WeatherForecastService _service;

        public WeatherForecastController(WeatherForecastDbContext context)
        {
            _service = new WeatherForecastService(context);
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts()
        {
            return await _service.GetWeatherForecasts();
        }
    }

}