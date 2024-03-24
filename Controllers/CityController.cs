using Microsoft.AspNetCore.Mvc;
using WeatherForecastApi.Models;
using WeatherForecastApi.Services;

namespace WeatherForecastApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private CityService _service;

    public CityController(WeatherForecastDbContext context)
    {
      _service = new CityService(context);
    }

    [HttpGet]
    public async Task<IEnumerable<CityDTO>> GetCities()
    {
      return await _service.GetCities();
    }
  }
}