using System;
using System.Collections.Generic;
using System.Linq;
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
        [Route("search")]
        public IEnumerable<Product> Search([FromQuery] string search)
        {
            return _context.Product.Where(x => x.Name.Contains(search));
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetAll()
        {
            return _context.Product;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public Product Get(Guid id)
        {
            return _context.Product.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
    }
}
