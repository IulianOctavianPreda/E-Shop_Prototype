using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public WeatherForecastController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public User Get()
        {
            var user = _context.User.Where(x => x.Id != null);
            return user.FirstOrDefault();
        }
    }
}
