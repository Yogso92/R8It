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
        //TODO lazy loading
        public IEnumerable<RateChoice> RateChoices { get; set; }
    }
}
