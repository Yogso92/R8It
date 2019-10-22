using R8It_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface IUploadService
    {
        Upload Get(int id);
        IEnumerable<Upload> GetAllFromUser(int userId);
        bool Delete(int id);
        Upload Update(Upload upload);
        Upload Insert(Upload upload);

    }
}
