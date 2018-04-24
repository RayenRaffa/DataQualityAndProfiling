using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions; 

namespace DATAQP
{
    class Regular_expression_Filter : Simple_Filters
    {
        public Regex reg_exp;
        public Regular_expression_Filter(string pattern, string name):base(name)
        {
            this.reg_exp = new Regex(pattern); 
        }
        public override bool filter_function(object input)
        {
            if (this.reg_exp.IsMatch(input.ToString()))
            {
                this.count++;
                return true;
            }
            return false;
        }
    }
}
