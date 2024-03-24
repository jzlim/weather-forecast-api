namespace WeatherForecastApi.Models;

public class CityDTO
{
  public int Id { get; set; }
  public int StateId { get; set; }
  public required string StateName { get; set; }
  public required string CityName { get; set; }
  public double Latitude { get; set; }
  public double Longitude { get; set; }
}
