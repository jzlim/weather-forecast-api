namespace WeatherForecastApi.Models;

public class WeatherForecast
{
  public int Id { get; set; }
  public int CityId { get; set; }
  public DateOnly ForecastDate { get; set; }
  public DateOnly ValidDate { get; set; }
  public string? Summary { get; set; }
  public string? WeatherDescription { get; set; }
  public double MinTemperature { get; set; }
  public double MaxTemperature { get; set; }

  public required City City { get; set; }
}
