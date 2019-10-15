using DB;
using DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toolbox.Mappers;

namespace DAL
{
    public interface IVisibilityLimitRepository
    {
        DbVisibilityLimit Create(DbVisibilityLimit limit);
        IEnumerable<DbVisibilityLimit> GetAll();
        IEnumerable<DbVisibilityLimit> GetUploadLimits(int uploadId);
        bool Delete(DbVisibilityLimit limit);
    }
}
