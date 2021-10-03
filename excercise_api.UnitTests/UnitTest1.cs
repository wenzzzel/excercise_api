using NUnit.Framework;
using excercise_api.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace excercise_api.UnitTests
{
    public class WeatherFOrecastControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_WhenCalled_WeatherSummaryIsHardcoded()
        {
            //Arrange
            WeatherForecastController myWeatherForecastController = new WeatherForecastController();

            //Act
            IEnumerable<WeatherForecast> myWeatherForecast = myWeatherForecastController.Get();
            string[] validWeathers = new string[] {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            //Assert
            Assert.Contains(myWeatherForecast.First().Summary, validWeathers);
        }
    }
}