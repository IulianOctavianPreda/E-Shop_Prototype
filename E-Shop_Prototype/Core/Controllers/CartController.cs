using System;
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
        [Route("{userId:Guid}")]
        public Cart Get(Guid userId)
        {
            return _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
        }

        public class CartUpdate
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost]
        [Route("{userId:Guid}")]
        public Cart Add(Guid userId, [FromBody] CartUpdate data)
        {
            var cart = _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
            _context.CartItems.Add(new CartItem {CartId = cart.Id, ProductId = data.ProductId, Quantity = data.Quantity});
            _context.SaveChanges();
            return _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
        }


        [HttpPost]
        [Route("{userId:Guid}")]
        public Cart Order(Guid userId)
        {
            var cart = _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                OrderItems = cart.CartItems.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                })
            };
            _context.Add(order);

            _context.SaveChanges();
            return _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
        }

    }
}
