using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Contains_Filter : Simple_Filters
    {
        public string pattern;
        public Contains_Filter(string name, string x) : base(name)
        {
            this.pattern = x;
        }
        public override bool filter_function(object input)
        {
            bool b = input.ToString().Contains(pattern);
            if (b)
                this.count++;
            return b; 
        }
    }
}
