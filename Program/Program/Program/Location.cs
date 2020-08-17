using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Location
    {
        int id;
        string shortN, longN;
        List<string[]> exits;
        List<string[]> things;


        public Location() { }

        public Location(int id)
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public List<string[]> Exits
        {
            get { return exits; }
            set { exits = value; }
        }
        public List<string[]> Things
        {
            get { return things; }
            set { things = value; }
        }



    }
}
