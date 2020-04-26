using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [ApiController]
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public CartController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public Cart Get()
        {
            var cart = _context.Cart.Include(x => x.CartItems);
            return cart.FirstOrDefault();
        }
    }
}
