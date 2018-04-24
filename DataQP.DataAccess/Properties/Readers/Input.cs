using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DATAQP
{
    abstract class Input : StreamReader
    {

        public string input_path;
        public Input(String name) : base(name)
        {
            this.input_path = name;
        }
        public abstract Data read_file();
    }
}