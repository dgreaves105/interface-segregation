using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.Queries
{
    public class GetSunset
    {
        public class Query : IRequest<DateTime>
        {
            public DateTime Date { get; set; }
        }

        public class Handler : IRequestHandler<Query, DateTime>
        {
            private readonly IWeatherProvider _weatherProvider;

            public Handler(IWeatherProvider weatherProvider)
            {
                _weatherProvider = weatherProvider ?? throw new ArgumentNullException(nameof(weatherProvider));
            }

            public async Task<DateTime> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _weatherProvider.GetSunSet(request.Date);
            }
        }
    }
}