using NUnit.Framework;
using excercise_api.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace excercise_api.UnitTests.Controllers
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
            string[] validWeathers = new string[] {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            //Act
            IEnumerable<WeatherForecast> myWeatherForecast = myWeatherForecastController.Get();

            //Assert
            Assert.Contains(myWeatherForecast.First().Summary, validWeathers);
        }
    }
}