using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Application.Queries;

namespace Application.Abstractions
{
    public interface IWeatherService
    {
        Task<List<WeatherForecast>> GetForecast(int days);
        Task<double> AverageTemperatureC(int days);
        Task<double> AverageTemperatureF(int days);
    }
}