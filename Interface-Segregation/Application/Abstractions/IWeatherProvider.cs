using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Abstractions
{
    public interface IWeatherProvider
    {
        Task<List<WeatherForecast>> GetForecast(int days);
        Task<LunarPhase> GetLunarPhase(DateTime date);
        Task<DateTime> GetSunrise(DateTime date);
        Task<DateTime> GetSunSet(DateTime date);
    }
}