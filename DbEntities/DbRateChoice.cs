using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbRateChoice
    {
        public int Id { get; set; }
        public int RatingTypeId { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
