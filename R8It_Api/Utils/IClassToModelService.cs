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
        public BaseUserModel ToBaseUserModel(User user);

        public FullUserModel GetFullUser(int id);
        public CategoryModel ToCategoryModel(Category category);
        public UploadModel ToUploadModel(Upload upload);
    }
}
