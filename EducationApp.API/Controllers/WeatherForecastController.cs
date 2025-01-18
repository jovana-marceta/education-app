using EducationApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.API.Controllers
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
        private readonly EducationAppDbContext dbContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, EducationAppDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var courses = dbContext.Courses.ToList();
            return Ok(courses);
        }
    }
}
