using System;
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
        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Product.Select(x => new ProductDto(x));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public ProductDto Get(Guid id)
        {
            return new ProductDto(_context.Product.FirstOrDefault(x => x.Id == id));
        }

        

    }
}
