using FeatureTogglePoc.Models;
using System;
using System.Linq;

namespace FeatureTogglePoc.LogicQueries
{
    public class RandomForecast : IReturnForecasts
    {
        private static string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GameForecasts GetCurrentForecasts(int number)
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, number).Select(index => new GameForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            return new GameForecasts() { Result = forecasts.ToList() };
        }
    }
}
