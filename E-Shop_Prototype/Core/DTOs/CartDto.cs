using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Core.DTOs
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public IEnumerable<CartItemDto> CartItems { get; set; }

        public CartDto(Cart cart)
        {
            Id = cart.Id;
            CartItems = cart.CartItems?.Select(x => new CartItemDto(x));
        }
    }
}
