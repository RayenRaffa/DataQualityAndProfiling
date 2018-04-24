using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    abstract class Simple_Filters
    {
        public string name;
        public int count; 
        public Simple_Filters(string name)
        {
            this.count = 0; 
            this.name = name; 
        }
        abstract public bool filter_function(object input); 
    }
}
