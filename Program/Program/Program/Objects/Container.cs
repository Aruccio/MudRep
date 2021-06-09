using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Management;

namespace Program.Objects
{
    public class Container : Item
    {
        public Container()
        {
        }

        public List<Item> Zawartosc { get; set; } = new List<Item>();

        public bool Closed { get; set; }
    }
}