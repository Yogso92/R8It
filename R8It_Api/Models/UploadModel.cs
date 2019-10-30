using DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class UploadModel
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string Context { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public byte[] File { get; set; }
        public string FileString { get; set; }
        public DateTime LimitDate { get; set; }
        [Required]
        public int RatingTypeId { get; set; }
        public bool Anonymous { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public double Result { get; set; }
    }
}
