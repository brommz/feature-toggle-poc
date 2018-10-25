using System.Threading.Tasks;
using FeatureTogglePoc.Models;
using FeatureTogglePoc.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FeatureTogglePoc.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<GameForecasts> Forecasts(NumberQuery query)
        {
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
