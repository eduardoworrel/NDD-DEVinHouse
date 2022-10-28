namespace test.api;
using Moq;
using Controllers;
using Microsoft.Extensions.Logging;
public class Tests
{
    [Test]
    public void TestGetWeatherForecast()
    {
        var mock = new Mock<ILogger<WeatherForecastController>>();
        
        var ctl = new WeatherForecastController(mock.Object);
        
        var result =  ctl.Get();
        
        Assert.IsNotEmpty(result);

        foreach(var item in result){
            Assert.LessOrEqual(item.TemperatureC,55);
            Assert.GreaterOrEqual(item.TemperatureC,-20);
        }
    }
}