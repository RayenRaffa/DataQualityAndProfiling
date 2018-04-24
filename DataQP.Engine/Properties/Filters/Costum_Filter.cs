using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATAQP
{
    class Costum_Filter 
    {
        public List< List<Simple_Filters>  > Filters;
        public string name;
        public int count; 
        public Costum_Filter(string name = "NoName")
        {
            this.name = name;
            this.Filters = new List<List<Simple_Filters>>();
            this.count = 0; 
        }
        public void add_to_colomun(Simple_Filters new_filter,int col_id)
        {
            this.Filters[col_id].Add(new_filter); 
        }
        public void create_new_conjunctions(Simple_Filters simple_Filter)
        {
            List<Simple_Filters> new_entery = new List<Simple_Filters>();
            new_entery.Add(simple_Filter);
            this.Filters.Add(new_entery); 
        }
        public bool apply_filter(object entery)
        {
            bool val = false; 
            foreach (var row in this.Filters)
            {
                bool ival = true; 
                foreach(Simple_Filters filter in row)
                {
                    ival = ival & filter.filter_function(entery); 
                }
                val = val | ival; 
            }
            if (val)
                this.count++; 
            return val; 
        }
    }
}
