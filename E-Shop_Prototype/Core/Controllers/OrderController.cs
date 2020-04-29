using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Database;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [Route("{userId:Guid}")]
        public IEnumerable<OrderDto> GetAllForUser(Guid userId)
        {
            return _context.Order.Include(x => x.OrderItems).ThenInclude(y => y.Product).Where(x => x.UserId == userId).Select(x => new OrderDto(x));
        }

        //[HttpGet]
        //[Route("{id:Guid}")]
        //public Order Get(Guid id)
        //{
        //    return _context.Order.FirstOrDefault(x => x.Id == id);
        //}
    }
}
