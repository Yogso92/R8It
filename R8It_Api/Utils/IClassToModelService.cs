using DomainEntities;
using R8It_Api.Models;
using R8It_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Utils
{
    public interface IClassToModelService
    {
        BaseUserModel ToBaseUserModel(User user);

        FullUserModel GetFullUser(int id);
        CategoryModel ToCategoryModel(Category category);
        UploadModel ToUploadModel(Upload upload);
        User BaseModelToDbUser(BaseUserModel model);
    }
}
