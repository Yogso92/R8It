using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbUpload 
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string Context { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public byte[] File { get; set; }
        public DateTime LimitDate { get; set; }
        public int RatingTypeId { get; set; }
        public bool Anonymous { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
    }
}
