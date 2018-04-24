using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Equal_Filter : Simple_Filters
    {
        public object value; 
        public Equal_Filter(string name,object x):base(name)
        {
            this.value = x; 
        }
        public override bool filter_function(object input)
        {
            if (this.value.ToString().Equals(input.ToString()))
            {
                this.count++; 
                return true;
            }
            return false; 
        }
    }
}
