using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain;

namespace Infrastructure
{
    public class WeatherProvider : IWeatherProvider
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private int SunrisePeriodAfter6AmMinutes = 120;
        private int SunsetPeriodBefore8PmMinutes = 180;

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

        public Task<LunarPhase> GetLunarPhase(DateTime date)
        {
            var rng = new Random();
            var value = rng.Next(0, Enum.GetValues(typeof(LunarPhase)).Length - 1);

            return Task.FromResult((LunarPhase) value);
        }

        public Task<DateTime> GetSunrise(DateTime date)
        {
            var rng = new Random();
            var value = rng.Next(0, SunrisePeriodAfter6AmMinutes);

            var result = date.Date;
            result = result.AddHours(6);
            result = result.AddMinutes(value);

            return Task.FromResult(result);
        }

        public Task<DateTime> GetSunSet(DateTime date)
        {
            var rng = new Random();
            var value = rng.Next(0, SunsetPeriodBefore8PmMinutes);

            var result = date.Date;
            result = result.AddHours(20);
            result = result.AddMinutes(-value);

            return Task.FromResult(result);
        }
    }
}