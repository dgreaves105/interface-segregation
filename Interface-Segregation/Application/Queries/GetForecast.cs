using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API;
using MediatR;

namespace Application.Queries
{
    public class GetForecast
    {
        public class Query : IRequest<IEnumerable<WeatherForecast>>
        {

        }

        public class Handler : IRequestHandler<Query, IEnumerable<WeatherForecast>>
        {
            private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            public Task<IEnumerable<WeatherForecast>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rng = new Random();
                return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = rng.Next(-20, 55),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    }));
            }
        }
    }
}