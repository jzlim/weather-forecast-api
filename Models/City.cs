namespace WeatherForecaseApi.Models;

public class City
{
  public int Id { get; set; }
  public int StateId { get; set; }
  public required string Name { get; set; }
  public double Latitude { get; set; }
  public double Longitude { get; set; }

  public required State State { get; set; }
}
