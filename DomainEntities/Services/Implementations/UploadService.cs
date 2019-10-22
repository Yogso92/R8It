using DAL;
using DbEntities;
using R8It_Domain.Entities;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace R8It_Domain.Services.Implementations
{
    public class UploadService : IUploadService
    {
        private readonly IUploadRepository _uploadRepository;

        public UploadService(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }

        public bool Delete(int id)
        {
            return _uploadRepository.Delete(id);
        }

        public Upload Get(int id)
        {
            return _uploadRepository.Get(id).Map<Upload>();
        }

        public IEnumerable<Upload> GetAllFromUser(int userId)
        {
            return _uploadRepository.GetAllFromUser(userId).Select(u => u.Map<Upload>());
        }

        public Upload Insert(Upload upload)
        {
            return _uploadRepository.Insert(upload.Map<DbUpload>()).Map<Upload>();
        }

        public Upload Update(Upload upload)
        {
            return _uploadRepository.Update(upload.Map<DbUpload>()).Map<Upload>();
        }
    }
}
