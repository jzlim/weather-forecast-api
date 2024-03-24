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

        public WeatherForecastController(WeatherForecastDbContext context, IHttpClientFactory httpClientFactory)
        {
            _service = new WeatherForecastService(context, httpClientFactory);
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts(int cityId)
        {
            return await _service.GetWeatherForecasts(cityId);
        }
    }

}