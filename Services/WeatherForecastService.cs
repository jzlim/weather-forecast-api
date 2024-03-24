using Microsoft.EntityFrameworkCore;
using WeatherForecastApi.Models;

namespace WeatherForecastApi.Services
{
  public class WeatherForecastService
  {
    private readonly WeatherForecastDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string openWeatherApiKey = "YOUR_API_KEY";
    private readonly string openWeatherApiUrlParams = "?appid={0}&lat={1}&lon={2}&exclude=minutely,hourly&units=metric";

    public WeatherForecastService(WeatherForecastDbContext context, IHttpClientFactory httpClientFactory)
    {
      _context = context;
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<WeatherForecastDTO>> GetWeatherForecasts(int cityId)
    {
      var city = await _context.Cities.Include(x => x.State).FirstOrDefaultAsync(x => x.Id == cityId);
      if (city == null)
      {
        return [];
      }

      var todayDate = DateOnly.FromDateTime(DateTime.Now);

      // Steps to fetch weather forecasts
      // 1. Get today's forecast (cityId + validDate + forecastDate) from DB
      // 2.1 If found, return cached data
      // 2.2 If not found, establish http request to OpenWeather and fetch today's and next couple day's forecasts
      // 3. Store/Cache the forecasts data from OpenWeather

      var cachedForecasts = await _context.WeatherForecasts.Include(x => x.City).ThenInclude(x => x.State).Where(x => x.CityId == cityId && x.ValidDate == todayDate).ToListAsync();
      if (cachedForecasts != null && cachedForecasts.Count > 0)
      {
        return cachedForecasts.Select(ItemToDTO);
      }
      else
      {
        var resp = await GetForecastFromWeatherForecastApi(city);
        if (resp != null)
        {
          var weatherForecasts = new List<WeatherForecast>();
          var maxCount = 3;
          // Only retrieve first 3 records. Assumed the list is ordered by date already.
          for (var i = 0; i <= maxCount; i++)
          {
            var newItem = new WeatherForecast
            {
              City = city,
              CityId = city.Id,
              ForecastDate = todayDate.AddDays(i),
              ValidDate = todayDate,
              Summary = resp.daily[i].summary,
              WeatherDescription = resp.daily[i].weather!.description,
              MinTemperature = resp.daily[i].temp!.min,
              MaxTemperature = resp.daily[i].temp!.max
            };
            weatherForecasts.Add(newItem);
            _context.WeatherForecasts.Add(newItem);
          }
          await _context.SaveChangesAsync();
          return weatherForecasts.Select(ItemToDTO);
        }
      }
      return [];
    }

    private async Task<OpenWeatherForecastResponse?> GetForecastFromWeatherForecastApi(City city)
    {
      var httpClient = _httpClientFactory.CreateClient("OpenWeather");
      var response = await httpClient.GetAsync(
            string.Format(openWeatherApiUrlParams, openWeatherApiKey, city.Latitude, city.Longitude));

      if (response.IsSuccessStatusCode)
      {
        var jsonString = response.Content.ReadAsStringAsync().Result;
        OpenWeatherForecastResponse resp = new(jsonString);
        return resp;
      }
      else
      {
        return null;
      }
    }

    public static WeatherForecastDTO ItemToDTO(WeatherForecast item)
    {
      return new WeatherForecastDTO
      {
        Id = item.Id,
        CityId = item.CityId,
        CityName = item.City.Name,
        StateName = item.City.State.Name,
        ForecastDate = item.ForecastDate,
        ValidDate = item.ValidDate,
        Summary = item.Summary,
        WeatherDescription = item.Summary,
        MinTemperature = item.MinTemperature,
        MaxTemperature = item.MaxTemperature
      };
    }
  }
}
