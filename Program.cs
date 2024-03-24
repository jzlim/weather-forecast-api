using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using WeatherForecastApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("OpenWeather", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/3.0/onecall?");
    httpClient.DefaultRequestHeaders.Accept.Clear();
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});
builder.Services.AddControllers();
builder.Services.AddDbContext<WeatherForecastDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
