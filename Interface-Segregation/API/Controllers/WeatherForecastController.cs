using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return (await _mediator.Send(new GetForecast.Query()));
        }

        [HttpGet("sunrise")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public async Task<DateTime> GetSunrise(DateTime date)
        {
            return await _mediator.Send(new GetSunrise.Query { Date = date });
        }

        [HttpGet("sunset")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public async Task<DateTime> GetSunset(DateTime date)
        {
            return await _mediator.Send(new GetSunset.Query{Date = date});
        }

        [HttpGet("lunarphase")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public async Task<LunarPhase> GetLunarPhase(DateTime date)
        {
            return await _mediator.Send(new GetLunarPhase.Query{Date = date});
        }
    }
}
