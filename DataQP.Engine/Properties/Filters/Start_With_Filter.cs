using System;
using System.Collections.Generic;
using System.Text;

namespace DATAQP
{
    class Start_With_Filter : Simple_Filters
    {
        public string pattern ; 
        public Start_With_Filter(string name,string x):base(name)
        {
            this.pattern = x; 
        }
        public override bool filter_function(object input)
        {
            bool b = input.ToString().StartsWith(pattern);
            if (b)
                this.count++; 
            return b; 
        }
    }
}
