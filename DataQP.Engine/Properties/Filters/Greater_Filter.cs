using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Greater_Filter : Simple_Filters
    {
        public double min; 
        public Greater_Filter(string name,double min):base(name)
        {
            this.min = min; 
        }
        public override bool filter_function(object input)
        {
            if ((double)input > this.min)
            {
                this.count++; 
                return true;
            }
            return false; 
        }
    }
}
