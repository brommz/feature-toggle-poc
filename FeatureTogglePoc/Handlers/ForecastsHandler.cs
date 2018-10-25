using FeatureTogglePoc.LogicQueries;
using FeatureTogglePoc.Models;
using FeatureTogglePoc.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FeatureTogglePoc.Handlers
{
    public class ForecastsHandler : IRequestHandler<NumberQuery, GameForecasts>
    {
        private readonly IReturnForecasts _forecast;

        public ForecastsHandler(IReturnForecasts forecast)
        {
            _forecast = forecast;
        }

        public Task<GameForecasts> Handle(NumberQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => _forecast.GetCurrentForecasts(request.Number));
        }
    }
}
