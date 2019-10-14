using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Interfaces;
using DbEntities;
using DomainEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<DbCategory> Get()
        {
            return _CategoryService.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{n}", Name = "Get")]
        public DbCategory Get(int n)
        {
            return _CategoryService.Get(n);
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{n}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{n}")]
        public void Delete(int n)
        {
        }
    }
}
