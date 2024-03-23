
using Microsoft.EntityFrameworkCore;

namespace WeatherForecaseApi.Models;

public class WeatherForecastDbContext : DbContext
{
  public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
        : base(options)
  {
  }

  public DbSet<State> States { get; set; }
  public DbSet<City> Cities { get; set; }
  public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}