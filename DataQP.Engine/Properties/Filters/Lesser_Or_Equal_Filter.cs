using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Lesser_Or_Equal_Filter : Lesser_Filter
    {
        public Lesser_Or_Equal_Filter(string name, double max):base(name,max){}

        public override bool filter_function(object input)
        {
            if ((double)input <= this.max)
            {
                this.count++; 
                return true;
            }
            return false;
        }
    }
}
