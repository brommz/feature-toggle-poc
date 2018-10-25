using System.Collections.Generic;
using FeatureTogglePoc.Models;

namespace FeatureTogglePoc.LogicQueries
{
    public class EmptyForecast : IReturnForecasts
    {
        public GameForecasts GetCurrentForecasts(int number)
        {
            return new GameForecasts()
            {
                Result = new List<GameForecast>()
            };
        }
    }
}
