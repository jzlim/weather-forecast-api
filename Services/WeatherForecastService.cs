using Microsoft.EntityFrameworkCore;
using WeatherForecastApi.Models;

namespace WeatherForecastApi.Services
{
  public class WeatherForecastService
  {
    private readonly WeatherForecastDbContext _context;

    public WeatherForecastService(WeatherForecastDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts()
    {
      // TODO: cache today's forecast when FIRST request in DB
      var weatherForecasts = await _context.WeatherForecasts.Include(x => x.City).ThenInclude(x => x.State).ToListAsync();
      return weatherForecasts.Select(ItemToDTO);
    }

    public static WeatherForecastDTO ItemToDTO(WeatherForecast item)
    {
      return new WeatherForecastDTO
      {
        Id = item.Id,
        CityId = item.CityId,
        CityName = item.City.Name,
        StateName = item.City.State.Name,
        ValidDate = item.ValidDate,
        Summary = item.Summary,
        WeatherDescription = item.Summary,
        MinTemperature = item.MinTemperature,
        MaxTemperature = item.MaxTemperature
      };
    }
  }
}
