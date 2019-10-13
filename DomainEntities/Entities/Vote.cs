using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntities
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UploadId { get; set; }
        public string Comment { get; set; }
        public int RateChoiceId { get; set; }

        //domain
        //TODO lazy loading
        public User Voter { get; set; }
        public RateChoice Rating { get; set; }
    }
}
