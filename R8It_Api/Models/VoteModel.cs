using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class VoteModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UploadId { get; set; }
        public string Comment { get; set; }
        [Required]
        public int RateChoiceId { get; set; }
    }
}
