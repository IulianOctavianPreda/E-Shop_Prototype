using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public UserController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public User Get()
        {
            var user = _context.User;
            return user.FirstOrDefault();
        }
    }
}
