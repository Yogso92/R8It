using System;
using System.Collections.Generic;
using System.Text;

namespace DbEntities
{
    public class DbCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string _Icon;
        public string Icon
        {
            get
            {
                return (_Icon == null ) ?  "placeholder.png" : _Icon;
            }
            set
            {
                _Icon = value;
            }
        }
        public bool Active { get; set; }
    }
}
