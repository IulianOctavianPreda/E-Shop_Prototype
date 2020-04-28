using System;
using System.Collections.Generic;
using System.Linq;
using Core.Database;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly SqlServerContext _context;
        private readonly ILuceneService _luceneService;

        public ProductController(SqlServerContext context, ILuceneService luceneService)
        {
            _context = context;
            _luceneService = luceneService;

            //var products = _context.Product.ToList();
            //_luceneService.AddSpecificationToIndex(products);
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<ProductDto> Search([FromQuery] string search)
        {
            return _context.Product.Where(x => x.Name.Contains(search)).Select(x => new ProductDto(x));
        }

        [HttpGet]
        [Route("luceneSearch")]
        public IEnumerable<ProductDto> LuceneSearch([FromQuery] string search)
        {
            var results = _luceneService.Search(search).ToList();
            if (results.Count > 0)
            {
                var products = _context.Product.ToList();
                return products.Where(x => results.Any(y => y.Id == x.Id)).Select(x => new ProductDto(x) );
            }
            return new List<ProductDto>();
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
