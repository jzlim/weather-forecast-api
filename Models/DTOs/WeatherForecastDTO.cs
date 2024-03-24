namespace WeatherForecastApi.Models;

public class WeatherForecastDTO
{
  public int Id { get; set; }
  public int CityId { get; set; }
  public required string CityName { get; set; }
  public required string StateName { get; set; }
  public DateOnly ValidDate { get; set; }
  public string? Summary { get; set; }
  public string? WeatherDescription { get; set; }
  public double MinTemperature { get; set; }
  public double MaxTemperature { get; set; }
}
