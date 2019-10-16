﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DbEntities;
using DomainEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Domain.Services.Interfaces;
using Tools;

namespace R8It_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _CategoryService.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{n}", Name = "Get")]
        public Category Get(int n)
        {
            return _CategoryService.Get(n);
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            return;
        }

        // PUT: api/Category/5
        [HttpPut]
        public void Put([FromBody] Category category)
        {
            _CategoryService.Insert(category);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{n}")]
        public void Delete(int n)
        {
            return;
        }
    }
}
