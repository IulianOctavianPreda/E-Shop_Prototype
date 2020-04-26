using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop_Mini.Database;
using E_Shop_Mini.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Shop_Mini.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {
        private SqlServerContext _context;

        public WeatherForecastController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public User Get()
        {
            var user = _context.User.Where(x => x.Id != null);
            return user.FirstOrDefault();
        }
    }
}
