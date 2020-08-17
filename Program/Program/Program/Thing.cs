using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Thing:Object
    {
        string name, longN;
        public Thing(string name)
        {
            this.name = name;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LongN
        {
            get { return longN; }
            set { longN = value; }
        }


    }
}
