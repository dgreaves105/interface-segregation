using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Application.Abstractions;

namespace Infrastructure
{
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<List<WeatherForecast>> GetForecast(int days)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList());
        }

        public async Task<double> AverageTemperatureC(int days)
        {
            var forecast = await GetForecast(days);

            return forecast.Average(f => f.TemperatureC);
        }

        public async Task<double> AverageTemperatureF(int days)
        {
            var forecast = await GetForecast(days);

            return forecast.Average(f => f.TemperatureF);
        }
    }
}