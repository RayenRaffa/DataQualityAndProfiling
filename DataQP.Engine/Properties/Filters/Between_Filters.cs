using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Between_Filters : Simple_Filters
    {
        public double min ; 
        public double max ; 
        public Between_Filters(string name ,double min , double max):base(name)
        {
            this.min = min;
            this.max = max; 
        }
        public override bool filter_function(object input)
        {
            if ((double)input <= this.max && (double)input >= this.min)
            {
                this.count++; 
                return true;
            }
            return false; 
        }
    }
}
