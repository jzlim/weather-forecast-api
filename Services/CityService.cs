using Microsoft.EntityFrameworkCore;
using WeatherForecastApi.Models;

namespace WeatherForecastApi.Services
{
  public class CityService
  {
    private readonly WeatherForecastDbContext _context;

    public CityService(WeatherForecastDbContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<CityDTO>> GetCities()
    {
      var cities = await _context.Cities.Include(x => x.State).ToListAsync();
      return cities.Select(ItemToDTO);
    }

    public static CityDTO ItemToDTO(City item)
    {
      return new CityDTO
      {
        Id = item.Id,
        StateId = item.StateId,
        StateName = item.State.Name,
        CityName = item.Name,
        Latitude = item.Latitude,
        Longitude = item.Longitude,
      };
    }
  }
}