using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class NPC :Character
    {
        public NPC()
        {

        }


        public NPC(string name, string shortN)
        {
            Name = name;
            Short = shortN;
        }

        public string Long { get; set; }
   
        public string Gender { get; set; }

        public string Race { get; set; }

        public List<Weapon> EqWeap { get; set; }

        public Weapon WeaponInHand { get; set; }
    }
}
