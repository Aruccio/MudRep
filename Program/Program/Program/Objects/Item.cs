using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Item
    {
        string name, shortN, longN;
        string[] odmianaPoj, odmianaMn;
        public Item()
        { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string ShortN
        {
            get { return shortN; }
            set { shortN = value; }
        }

        public string LongN
        {
            get { return longN; }
            set { longN = value; }
        }

        public string[] OdmianaPoj
        {
            get { return odmianaPoj; }
            set { odmianaPoj = value; }
        }

        public string[] OdmianaMn
        {
            get { return odmianaMn; }
            set { odmianaMn = value; }
        }
    }
}
