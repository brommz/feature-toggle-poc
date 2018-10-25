using FeatureTogglePoc.Models;
using MediatR;

namespace FeatureTogglePoc.Queries
{
    public class NumberQuery : IRequest<GameForecasts>
    {
        public int Number { get; set; }
    }
}
