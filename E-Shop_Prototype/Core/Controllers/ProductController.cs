﻿using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public ProductController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public Product Get()
        {
            var product = _context.Product.Include(x => x.Category);
            return product.FirstOrDefault();
        }
    }
}