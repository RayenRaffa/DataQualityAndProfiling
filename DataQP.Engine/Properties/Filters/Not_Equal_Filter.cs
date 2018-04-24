using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Not_Equal_Filter : Simple_Filters
    {
        public object value;
        public Not_Equal_Filter(string name, object x) : base(name)
        {
            this.value = x;
        }
        public override bool filter_function(object input)
        {
            if (!this.value.ToString().Equals(input.ToString()))
            {
                this.count++;
                return true;
            }
            return false;
        }
    }
}
