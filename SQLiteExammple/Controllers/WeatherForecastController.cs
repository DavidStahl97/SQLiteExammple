using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SQLiteExammple.Controllers
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
        private readonly DatabaseContext _database;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DatabaseContext database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _database.WatherForecasts.ToListAsync();
        }
    }
}