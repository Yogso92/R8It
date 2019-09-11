using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UploadId { get; set; }
        public string Comment { get; set; }
        public int RateChoiceId { get; set; }
    }
}
