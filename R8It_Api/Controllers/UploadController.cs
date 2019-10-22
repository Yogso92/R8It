using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IClassToModelService _classToModelService;
        public UploadController(IUploadService uploadService, IClassToModelService classToModelService)
        {
            _uploadService = uploadService;
            _classToModelService = classToModelService;
        }

        [Authorize]
        [HttpGet("{n}")]
        public UploadModel Get(int n)
        {
            return _classToModelService.ToUploadModel(_uploadService.Get(n));
        }
        [Authorize]
        [HttpPut]
        public UploadModel Insert([FromBody] UploadModel model)
        {
            return _classToModelService.ToUploadModel(_uploadService.Insert(model.Map<Upload>()));
        }

    }
}