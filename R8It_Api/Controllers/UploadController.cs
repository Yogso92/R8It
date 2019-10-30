using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using R8It_Api.Models;
using R8It_Api.Utils;
using R8It_Domain.Entities;
using R8It_Domain.Services.Interfaces;
using Tools;

namespace R8It_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;
        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        //[Authorize]
        //[HttpGet("{n}")]
        //public Upload Get(int n)
        //{
        //    return _uploadService.Get(n);
        //}
        [HttpGet("bycategory/{n}")]
        [Authorize]
        public IEnumerable<UploadModel> GetUploadsFromCategory(int n)
        {
            var test = _uploadService.GetAllFromCategory(n).Select(s =>
            { 
                UploadModel retour = s.Map<UploadModel>();
                retour.FileString = Encoding.UTF8.GetString(retour.File);
                return retour;
            });
            return test;
        }
        [Authorize]
        [HttpPost]
        public Upload Insert([FromBody] UploadModel model)
        {
            model.UploadDate = DateTime.Now;
            model.LimitDate = DateTime.Now.AddDays(7);
            return _uploadService.Insert(model.Map<Upload>());
        }

    }
}