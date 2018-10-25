using FeatureTogglePoc.Models;
using LaunchDarkly.Client;

namespace FeatureTogglePoc.LogicQueries
{
    public class ForecastStrategy : IReturnForecasts
    {
        private static readonly LdClient _toggleRouterClient = new LdClient("sdk-fd0828f2-bebf-47e0-b55a-9a10cc4783e9");

        public GameForecasts GetCurrentForecasts(int number)
        {
            if (IsForecastEnabled())
            {
                return new RandomForecast().GetCurrentForecasts(number);
            }
            else
            {
                return new EmptyForecast().GetCurrentForecasts(number);
            }
        }

        private bool IsForecastEnabled()
        {
            User user = User
                .WithKey("user-proof-of-concept");
            bool value = _toggleRouterClient.BoolVariation("forecast", user, false);
            _toggleRouterClient.Flush();
            return value;
        }
    }
}
