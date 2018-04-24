using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Greater_Or_Equal_Filter : Greater_Filter
    {
        public Greater_Or_Equal_Filter(string name, double min):base(name,min)
        {}
        public override bool filter_function(object input)
        {
            if ((double)input >= this.min)
            {
                this.count++; 
                return true;
            }
            return false;
        }
    }
}
