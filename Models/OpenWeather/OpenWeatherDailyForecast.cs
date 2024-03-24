using System.Text.Json.Nodes;

namespace WeatherForecastApi.Models;

public class OpenWeatherDailyForecast
{
  public int dt { get; set; }
  public string? summary { get; set; }
  public OpenWeatherTemperature? temp { get; set; }
  public OpenWeatherWeather? weather { get; set; }

  public OpenWeatherDailyForecast(JsonNode jsonData)
  {
    dt = (int)jsonData!["dt"]!;
    summary = (string)jsonData!["summary"]!;
    temp = new OpenWeatherTemperature(jsonData["temp"]!);
    weather = new OpenWeatherWeather(jsonData["weather"]!);
  }
}

public class OpenWeatherTemperature
{
  public double min { get; set; }
  public double max { get; set; }
  public OpenWeatherTemperature(JsonNode jsonData)
  {
    min = (double)jsonData!["min"]!;
    max = (double)jsonData!["max"]!;
  }
}

public class OpenWeatherWeather
{
  public string? description { get; set; }
  public OpenWeatherWeather(JsonNode jsonData)
  {
    description = (string)jsonData.AsArray().First()!["description"]!;
  }
}