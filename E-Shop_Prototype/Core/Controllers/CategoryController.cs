﻿using System;
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
        public IEnumerable<Category> GetAll()
        {
            return _context.Category;
        }

        [HttpGet]
        [Route("dashboard")]
        public IEnumerable<CategoryDto> GetDashboardCategories()
        {

            var category = _context.Category.Include(x =>x.Products).Select(x => new CategoryDto(x));
            return category;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public Category Get(Guid id)
        {
            return _context.Category.FirstOrDefault(x => x.Id == id);
        }
    }
}
