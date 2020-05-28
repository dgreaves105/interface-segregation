using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain;
using MediatR;

namespace Application.Queries
{
    public class GetLunarPhase
    {
        public class Query : IRequest<LunarPhase>
        {
            public DateTime Date { get; set; }
        }

        public class Handler : IRequestHandler<Query, LunarPhase>
        {
            private readonly IWeatherProvider _weatherProvider;

            public Handler(IWeatherProvider weatherProvider)
            {
                _weatherProvider = weatherProvider ?? throw new ArgumentNullException(nameof(weatherProvider));
            }

            public async Task<LunarPhase> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _weatherProvider.GetLunarPhase(request.Date);
            }
        }
    }
}