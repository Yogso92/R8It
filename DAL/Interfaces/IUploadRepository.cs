﻿using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IUploadRepository
    {
        DbUpload Get(int id);
        IEnumerable<DbUpload> GetAllFromUser(int id);
        IEnumerable<DbUpload> GetAllFromCategory(int categoryId);
        IEnumerable<DbUpload> GetAll();
        DbUpload Update(DbUpload upload);
        bool Delete(int id);
        DbUpload Insert(DbUpload upload);

    }
}
