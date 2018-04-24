using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Lesser_Filter : Simple_Filters
    {
        public double max; 
        public Lesser_Filter(string name,double max):base(name)
        {
            this.max = max;
        }
        public override bool filter_function(object input)
        {
            if ((double)input < this.max)
            {
                this.count++; 
                return true;
            }
            return false;
        }
    }
}
