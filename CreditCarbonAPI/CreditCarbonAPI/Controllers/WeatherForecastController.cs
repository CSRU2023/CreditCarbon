using Microsoft.AspNetCore.Mvc;
using CreditCarbonAPI.Models;
using CreditCarbonAPI.Repositories;

namespace CreditCarbonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private CarbonCreditEfRepository<ProjectCarbon> _carbonCreditEfRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            CarbonCreditEfRepository<ProjectCarbon> carbonCreditEfRepository)
        {
            _logger = logger;
            _carbonCreditEfRepository = carbonCreditEfRepository;
        }

        // [HttpGet(Name = "GetWeatherForecast")]
        // public IEnumerable<WeatherForecast> Get()
        // {
        //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //     {
        //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //         TemperatureC = Random.Shared.Next(-20, 55),
        //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //     })
        //     .ToArray();
        // }

        [HttpGet(Name = "GetCarbonCredit")]
        public IEnumerable<ProjectCarbon> GetCarbonCredit()
        {
            var listProjectCarbon = _carbonCreditEfRepository.GetProjectCarbon();

            return listProjectCarbon;
        }
    }
}