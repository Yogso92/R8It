using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntities
{
    public class Category
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public void UpdateInfos(Category category)
        {
            //TODO: changer infos
            category.Id = Id;

        }
    }
}
