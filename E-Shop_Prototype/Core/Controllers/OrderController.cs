using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Database;
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
        public IEnumerable<Order> GetAllForUser(Guid userId)
        {
            return _context.Order.Include(x => x.OrderItems).Where(x => x.UserId == userId);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public Order Get(Guid id)
        {
            return _context.Order.FirstOrDefault(x => x.Id == id);
        }
    }
}
