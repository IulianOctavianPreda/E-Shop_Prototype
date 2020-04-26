using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public OrderController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public Order Get()
        {
            var order = _context.Order;
            return order.FirstOrDefault();
        }
    }
}
