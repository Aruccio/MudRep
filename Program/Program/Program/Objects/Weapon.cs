using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Weapon : Item
    {
        public Weapon()
        {
          
        }
        public int Hand { get; set; }

        public int Speed { get; set; }
    }
}
