using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DbEntities;
using DomainEntities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Api.Models;
using R8It_Domain.Entities;
using R8It_Domain.Services.Interfaces;
using Tools;

namespace R8It_Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IUploadService _UploadService;
        public CategoryController(ICategoryService categoryService, IUploadService uploadService)
        {
            _CategoryService = categoryService;
            _UploadService = uploadService;
        }
        // GET: api/Category
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Category> Get()
        {
            return _CategoryService.GetAll();
        }

        // GET: api/Category/5
        //[HttpGet("{n}", Name = "Get")]
        //[Authorize]
        //public IEnumerable<Upload> GetUploadsFromCategory(int n)
        //{
        //    return _UploadService.GetAllFromCategory(n);
        //}

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] CategoryModel category)
        {
            return;
        }

        // PUT: api/Category
        [HttpPut]
        [Authorize]
        public void Put([FromBody] CategoryModel category)
        {
            _CategoryService.Insert(category.Map<Category>());
        }
        // DELETE: api/Category/5
        [HttpDelete("{n}")]
        [Authorize]
        public void Delete(int n)
        {
            return;
        }
        
    }
}
