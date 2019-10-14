using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbVisibilityLimit : TEntity<int>
    {
        public int CountryId { get; set; }
        public int UploadId { get; set; }
    }
}
