using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntities
{
    public class RatingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }

        //domain
        public IEnumerable<RateChoice> RateChoices { get; set; }

        public void UpdateNameAndDefinition(string name, string definition)
        {
            Name = name;
            Definition = definition;
            //todo : update through service
        }
    }
}
