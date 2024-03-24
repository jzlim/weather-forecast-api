using System.Text.Json.Nodes;

namespace WeatherForecastApi.Models;

public class OpenWeatherForecastResponse
{
  public List<OpenWeatherDailyForecast> daily { get; set; } = [];
  public OpenWeatherForecastResponse(string jsonResponse)
  {
    var jsonData = JsonObject.Parse(jsonResponse);
    foreach (var dailyWeather in jsonData!["daily"]!.AsArray())
    {
      daily.Add(new OpenWeatherDailyForecast(dailyWeather!));
    }
  }
}