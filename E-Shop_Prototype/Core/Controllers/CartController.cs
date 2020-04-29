using System;
using System.Collections.Generic;
using System.Linq;
using Core.Database;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
        public CartDto Get(Guid userId)
        {
            var cart = _context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            if (cart == null)
            {
                _context.Cart.Add(new Cart {UserId = userId});
                _context.SaveChanges();
                cart = _context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            }

            return new CartDto(cart);
        }

        public class CartUpdate
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpPost]
        [Route("{userId:Guid}/{productId:Guid}")]
        public void Add(Guid userId, Guid productId)
        {
            var cart = _context.Cart.Include(x => x.CartItems).FirstOrDefault(x => x.UserId == userId);
            if (cart == null)
            {
                cart = new Cart {UserId = userId, CartItems = new List<CartItem>()};
                _context.Cart.Add(cart);
            }
            var product = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);
            if (product == null)
            {
                _context.CartItems.Add(new CartItem { CartId = cart.Id, ProductId = productId, Quantity = 0});
            }
            else
            {
                product.Quantity++;
            }
            _context.SaveChanges();
        }


        [HttpPost]
        [Route("{userId:Guid}/update")]
        public CartDto Update(Guid userId, [FromBody] CartUpdate data)
        {
            var cart = _context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
            var product = cart.CartItems.FirstOrDefault(x => x.ProductId == data.ProductId);
            if (product == null)
            {
                _context.CartItems.Add(new CartItem { CartId = cart.Id, ProductId = data.ProductId, Quantity = data.Quantity });
            }
            else
            {
                product.Quantity = data.Quantity;
                if (data.Quantity == 0)
                {
                    _context.CartItems.Remove(product);
                }
            }
            _context.SaveChanges();
            return new CartDto(_context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId));
        }


        [HttpPost]
        [Route("{userId:Guid}/order")]
        public CartDto Order(Guid userId)
        {
            var cart = _context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                OrderItems = cart.CartItems.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity
                }).ToList()
            };
            _context.Order.Add(order);
            cart.CartItems = new List<CartItem>();
            _context.SaveChanges();
            return new CartDto(_context.Cart.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId));
        }

    }
}
