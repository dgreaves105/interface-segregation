using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Application.Abstractions;
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
            private readonly IWeatherService _weatherService;

            public Handler(IWeatherService weatherService)
            {
                _weatherService = weatherService ?? throw new ArgumentNullException(nameof(weatherService));
            }

            public async Task<IEnumerable<WeatherForecast>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _weatherService.GetForecast(5);
            }
        }
    }
}