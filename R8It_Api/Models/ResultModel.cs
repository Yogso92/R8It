using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace R8It_Api.Models
{
    public class ResultModel
    {
        public string FileString { get; set; }
        public string Context { get; set; }
        public double Result { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
