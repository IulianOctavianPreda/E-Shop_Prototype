using System.Linq;
using Core.Database;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly SqlServerContext _context;

        public CategoryController(SqlServerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public Category Get()
        {
            var category = _context.Category;
            return category.FirstOrDefault();
        }
    }
}
