using FeatureTogglePoc.Models;

namespace FeatureTogglePoc.LogicQueries
{
    public interface IReturnForecasts
    {
        GameForecasts GetCurrentForecasts(int number);
    }
}
