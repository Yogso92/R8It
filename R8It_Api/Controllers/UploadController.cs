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
        private readonly IVoteService _voteService;
        public UploadController(IUploadService uploadService, IVoteService voteService)
        {
            _uploadService = uploadService;
            _voteService = voteService;
        }
        
        [HttpGet("bycategory/{n}")]
        [Authorize]
        public IEnumerable<UploadModel> GetUploadsFromCategory(int n)
        {
            var test = _uploadService.GetAllFromCategory(n).Select(s =>
            { 
                UploadModel retour = s.Map<UploadModel>();
                retour.FileString = Encoding.UTF8.GetString(retour.File);
                retour.Result = _voteService.GetResult(retour.Id);
                return retour;
            });
            return test;
        }

        [Authorize]
        [HttpPost]
        public bool Insert([FromBody] UploadModel model)
        {
            model.UploadDate = DateTime.Now;
            model.LimitDate = DateTime.Now.AddDays(7);
            model.File = Encoding.UTF8.GetBytes(model.FileString);
            try
            {
                _uploadService.Insert(model.Map<Upload>());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("byuser/{userId}")]
        [Authorize]
        
        public IEnumerable<UploadModel> GetAllFromUser(int userId)
        {
            return _uploadService.GetAllFromUser(userId).Select(s =>
            {
                UploadModel retour = s.Map<UploadModel>();
                retour.Result = _voteService.GetResult(retour.Id);
                retour.FileString = Encoding.UTF8.GetString(s.File);

                return retour;
            });
        }

    }
}